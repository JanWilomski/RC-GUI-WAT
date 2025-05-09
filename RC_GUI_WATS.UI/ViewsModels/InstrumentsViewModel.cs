using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using RC_GUI_WATS.Core.Models;
using RC_GUI_WATS.Core.Services;
using System.Collections.ObjectModel;

namespace RC_GUI_WATS.UI.ViewModels
{
    public class InstrumentsViewModel : ObservableObject
    {
        public ObservableCollection<Instrument> Instruments { get; } = new();
        public IRelayCommand LoadCommand { get; }

        public InstrumentsViewModel()
        {
            LoadCommand = new RelayCommand(() =>
            {
                Instruments.Clear();
                foreach (var inst in InstrumentLoader.LoadFromCsv("instruments.csv"))
                    Instruments.Add(inst);
            });
        }
    }
}