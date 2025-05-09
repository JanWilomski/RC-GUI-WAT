using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace RC_GUI_WATS.UI.ViewModels
{
    public class FiltersViewModel : ObservableObject
    {
        public ObservableCollection<string> Filters { get; } = new();
        // TODO: logika dodawania/usuwania filtrów
    }
}