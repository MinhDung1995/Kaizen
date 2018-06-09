using System;
using System.Collections.Generic;
using Kaizen.Server.Common.Enums;

namespace Kaizen.Server.Service.Interface.Models
{
    public class ChineseChessOnlineMatchModel
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public ChessResult Result { get; set; }

        public long Coin { get; set; }
    }
}
