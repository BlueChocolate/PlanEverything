using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Panuon.WPF.UI;
using System.Windows;

namespace PlanEverything.ViewModels
{
    internal partial class ShellViewModel : ObservableObject
    {
        public DashboardViewModel DashboardViewModel { get; private set; }
        public SettingsViewModel SettingsViewModel { get; private set; }
        public LogViewModel LogViewModel { get; private set; }

        //public ObservableCollection<> PlanPages { get; }


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
                ViewSelectedIndex = -1;
                ViewSelectedIndex = PlanSelectedIndex;
            }
        }

        [RelayCommand]
        private void SwitchMenu()
        {
            DebugLog += "SwitchMenu\n";
            IsMenuOpen = !IsMenuOpen;
            MenuButtonIcon = IsMenuOpen ? "\uf100" : "\uf101;";
        }

        [RelayCommand]
        private static void MinimizeWindow(object? parameter)
        {
            if (parameter is WindowX window)
            {
                window.Minimize();
            }
        }

        [RelayCommand]
        private static void MaximizeOrRestore(object? parameter)
        {
            if (parameter is WindowX window)
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    window.Normalmize();
                }
                else
                {
                    window.Maximize();
                }
            }
        }

        [RelayCommand]
        private static void CloseWindow(object? parameter)
        {
            if ( parameter is WindowX window)
            {
                window.Close();
            }
        }

        public ShellViewModel()
        {
            DashboardViewModel = new DashboardViewModel();
            SettingsViewModel = new SettingsViewModel();
            LogViewModel = new LogViewModel();

            IsMenuOpen = true;
            MenuButtonIcon = "\uf100";

            DebugLog = "ShellViewModel created\n";
        }
    }
}
