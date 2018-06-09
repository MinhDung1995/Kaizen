using System;
using Microsoft.EntityFrameworkCore;
using Kaizen.Server.Repository.Interface;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;

namespace Kaizen.Server.Repository
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        protected readonly DbContext _dbContext;
        private IDbContextTransaction _transaction;
        private IsolationLevel? _isolationLevel;
        private Dictionary<string, IRepository> _repositories = new Dictionary<string, IRepository>();
        
        public UnitOfWork(T dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private void StartNewTransactionIfNeeded()
        {
            if (_transaction == null)
            {
                if (_isolationLevel.HasValue)
                    _transaction = _dbContext.Database.BeginTransaction(_isolationLevel.GetValueOrDefault());
                else
                    _transaction = _dbContext.Database.BeginTransaction();
            }
        }

        public void ForceBeginTransaction()
        {
            StartNewTransactionIfNeeded();
        }

        public void CommitTransaction()
        {
            //do not open transaction here, because if during the request
            //nothing was changed (only select queries were run), we don't
            //want to open and commit an empty transaction - calling SaveChanges()
            //on _transactionProvider will not send any sql to database in such case
            _dbContext.SaveChanges();

            if (_transaction != null)
            {
                _transaction.Commit();

                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction == null) return;

            _transaction.Rollback();

            _transaction.Dispose();
            _transaction = null;
        }

        public int SaveChanges()
        {
            StartNewTransactionIfNeeded();

            return _dbContext.SaveChanges();
        }

        public void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            _isolationLevel = isolationLevel;
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            _transaction = null;
        }

        public GenericRepository<Y> Repository<Y>() where Y : class
        {
            if (!_repositories.ContainsKey(typeof(Y).ToString()))
            {
                _repositories.Add(typeof(Y).ToString(), new GenericRepository<Y>(_dbContext));
            }

            return _repositories[typeof(Y).ToString()] as GenericRepository<Y>;
        }
    }
}
