using System.Collections.Generic;
using System.IO;
using RC_GUI_WATS.Core.Models;

namespace RC_GUI_WATS.Core.Services
{
    public static class InstrumentLoader
    {
        public static IEnumerable<Instrument> LoadFromCsv(string path)
        {
            using var reader = new StreamReader(path);
            _ = reader.ReadLine(); // nagłówek
            while (!reader.EndOfStream)
            {
                var parts = reader.ReadLine()!.Split(';');
                yield return new Instrument
                {
                    ISIN     = parts[0],
                    Symbol   = parts[1],
                    Name     = parts[2],
                    TickSize = decimal.Parse(parts[3])
                };
            }
        }
    }
}