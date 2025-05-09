using CommunityToolkit.Mvvm.ComponentModel;

namespace RC_GUI_WATS.UI.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public MessagesViewModel MessagesVM    { get; } = new();
        public SettingsViewModel SettingsVM    { get; } = new();
        public FiltersViewModel FiltersVM      { get; } = new();
        public InstrumentsViewModel InstrumentsVM { get; } = new();
    }
}