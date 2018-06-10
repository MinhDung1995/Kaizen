using Kaizen.Server.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kaizen.Server.DataAccess
{
    public class KaizenDbContext : DbContext
    {
        public KaizenDbContext(DbContextOptions<KaizenDbContext> options)
            : base(options)
        {
        }

        public DbSet<ChineseChessOnlineMatch> ChineseChessOnlineMatchs { get; set; }
    }
}