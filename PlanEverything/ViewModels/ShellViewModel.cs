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

            IsMenuOpen = true;
            MenuButtonIcon = "\uf100";

            DebugLog = "ShellViewModel created\n";
        }

        [ObservableProperty]
        private int _viewSelectedIndex;

        [ObservableProperty]
        private int _menuSelectedIndex;

        [ObservableProperty]
        private int _planSelectedIndex;

        [ObservableProperty]
        private bool _isMenuOpen;

        [ObservableProperty]
        private string _menuButtonIcon;

        [ObservableProperty]
        private string? _debugLog;

        [RelayCommand]
        private void SwitchMenu()
        {
            DebugLog += "SwitchMenu\n";
            IsMenuOpen = !IsMenuOpen;
            MenuButtonIcon = IsMenuOpen ? "\uf100" : "\uf101;";
        }

        partial void OnMenuSelectedIndexChanged(int value)
        {
            DebugLog += $"MenuSelectionChanged: {value}\n";
            if (MenuSelectedIndex != -1)
            {
                PlanSelectedIndex = -1;
                ViewSelectedIndex = MenuSelectedIndex;
            }
        }

        partial void OnPlanSelectedIndexChanged(int value)
        {
            DebugLog += $"MenuSelectionChanged: {value}\n";
            if (MenuSelectedIndex != -1)
            {
                PlanSelectedIndex = -1;
                ViewSelectedIndex = MenuSelectedIndex;
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
