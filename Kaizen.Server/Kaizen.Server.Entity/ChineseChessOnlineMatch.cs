using System;
using Kaizen.Server.Common.Enums;

namespace Kaizen.Server.Entity
{
    public class ChineseChessOnlineMatch
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public ChessResult Result { get; set; }

        public long Coin { get; set; }
    }
}