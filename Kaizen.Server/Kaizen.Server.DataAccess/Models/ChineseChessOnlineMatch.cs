using System;
using Kaizen.Server.DataAccess.Enums;

namespace Kaizen.Server.DataAccess.Models
{
    public class ChineseChessOnlineMatch
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public ChessResult Result { get; set; }

        public long Coin { get; set; }
    }
}