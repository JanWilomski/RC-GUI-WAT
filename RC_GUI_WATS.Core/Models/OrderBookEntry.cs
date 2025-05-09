using System;
using System.Linq;

namespace RC_GUI_WATS.Core.Models
{
    public class OrderBookEntry
    {
        public string   ClOrdID      { get; set; } = "";
        public DateTime TransactTime { get; set; }
        public string   Side         { get; set; } = "";
        public string   Symbol       { get; set; } = "";
        public decimal  Price        { get; set; }
        public int      OrderQty     { get; set; }
        public int      CumQty       { get; set; }
        public string   Text         { get; set; } = "";
        public string   ISIN         { get; set; } = "";

        /// <summary>
        /// Parsuje Message.Content na OrderBookEntry.
        /// Zakłada, że wartości są spacjami rozdzielone w kolejności:
        /// ClOrdID TransactTime Side Symbol Price OrderQty CumQty [Text] [ISIN]
        /// Dostosuj do swojego formatu.
        /// </summary>
        public static OrderBookEntry? FromMessage(Message msg)
        {
            var parts = msg.Content.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 7)
                return null;

            if (!DateTime.TryParse(parts[1], out var time))
                return null;

            var obe = new OrderBookEntry
            {
                ClOrdID      = parts[0],
                TransactTime = time,
                Side         = parts[2],
                Symbol       = parts[3],
                Price        = decimal.TryParse(parts[4], out var p) ? p : 0,
                OrderQty     = int.TryParse(parts[5], out var oq) ? oq : 0,
                CumQty       = int.TryParse(parts[6], out var cq) ? cq : 0,
                Text         = parts.Length > 7 ? string.Join(' ', parts.Skip(7)) : "",
                ISIN         = parts.Length > 8 ? parts[8] : parts[3] // jeśli nie ma ISIN, użyj symbolu
            };
            return obe;
        }
    }
}
