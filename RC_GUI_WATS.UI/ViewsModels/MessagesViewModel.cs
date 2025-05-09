using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using RC_GUI_WATS.Core.Models;
using RC_GUI_WATS.Core.Services;

namespace RC_GUI_WATS.UI.ViewModels
{
    public class MessagesViewModel : ObservableObject
    {
        // sekcja 1
        public decimal OpenCapital     { get; set; }
        public decimal AccruedCapital  { get; set; }
        public decimal TotalCapital    { get; set; }
        public int     UsedMessages    { get; set; }  // procent
        public int     UsedCapital     { get; set; }  // procent

        // sekcja 2
        public ObservableCollection<Message> CcgMessages { get; }
            = new ObservableCollection<Message>();

        // sekcja 3 – potrzebujesz definicji klasy OrderBookEntry w Core.Models
        public ObservableCollection<OrderBookEntry> OrderBook { get; }
            = new ObservableCollection<OrderBookEntry>();

        // sekcja 4 – możesz użyć modelu Instrument, rozbudowując go o pola Net, OpenLong, OpenShort
        public ObservableCollection<Instrument> ActiveInstruments { get; }
            = new ObservableCollection<Instrument>();

        private readonly RiskCheckerClient _client;

        public MessagesViewModel()
        {
            // przykładowe inicjalne wartości
            OpenCapital    = 66475.37m;
            AccruedCapital = 2719.32m;
            TotalCapital   = 66475.37m;
            UsedMessages   = 4;    // 4%
            UsedCapital    = 6;    // 6%

            _client = new RiskCheckerClient();
            _client.MessageReceived += OnMessageReceived;
            _ = _client.StartAsync("127.0.0.1", 9000);
        }

        private void OnMessageReceived(Message msg)
        {
            // dodajemy do listy CCG
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                CcgMessages.Add(msg);

                // 3) symulacja tworzenia wpisu do order book
                var ob = OrderBookEntry.FromMessage(msg);
                if (ob != null) OrderBook.Add(ob);

                // 4) aktualizacja listy aktywnych instrumentów
                var instr = ActiveInstruments.FirstOrDefault(i => i.ISIN == ob?.ISIN);
                if (instr == null && ob != null)
                {
                    ActiveInstruments.Add(new Instrument
                    {
                        ISIN      = ob.ISIN,
                        Symbol    = ob.Symbol,
                        Name      = ob.Symbol
                        //Net       = ob.CumQty,
                        //OpenLong  = ob.Side == "Buy"  ? ob.CumQty : 0,
                        //OpenShort = ob.Side == "Sell" ? ob.CumQty : 0
                    });
                }
            });
        }
    }
}
