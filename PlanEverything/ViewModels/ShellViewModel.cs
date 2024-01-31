using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlanEverything.ViewModels
{
    internal partial class ShellViewModel : ObservableObject
    {
        public DashboardViewModel DashboardViewModel { get; private set; }
        public SettingsViewModel SettingsViewModel { get; private set; }

        //public ObservableCollection<> PlanPages { get; }

        public ShellViewModel()
        {
            DashboardViewModel = new DashboardViewModel();
            SettingsViewModel = new SettingsViewModel();

            DebugLog = "ShellViewModel created\n";
        }

        

        [ObservableProperty]
        private int _viewSelectedIndex;

        [ObservableProperty]
        private int _menuSelectedIndex;

        [ObservableProperty]
        private int _planSelectedIndex;

        [ObservableProperty]
        private bool _isPaneOpen;

        [ObservableProperty]
        private string? _debugLog;


        [RelayCommand]
        private void MenuSelectionChanged()
        {
            DebugLog += "MenuSelectionChanged\n";
            if (MenuSelectedIndex != -1)
            {
                PlanSelectedIndex = -1;
                ViewSelectedIndex = MenuSelectedIndex;
            }
        }

        [RelayCommand]
        private void PlanSelectionChanged()
        {
            DebugLog += "PlanSelectionChanged\n";
            if (PlanSelectedIndex != -1)
            {
                MenuSelectedIndex = -1;
                ViewSelectedIndex = 5;
            }
        }

        [RelayCommand]
        private void CloseButtonClicked()
        {
            DebugLog += "CloseButtonClicked\n";
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
