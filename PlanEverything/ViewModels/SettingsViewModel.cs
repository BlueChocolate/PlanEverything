using CommunityToolkit.Mvvm.ComponentModel;
using Panuon.WPF.UI;
using PlanEverything.Helpers;

namespace PlanEverything.ViewModels
{
    internal partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ThemeMode _theme;

        partial void OnThemeChanged(ThemeMode value)
        {
            ThemeHelper.ChangeTheme(value);
        }

        public SettingsViewModel()
        {
            Theme = ThemeMode.Default;
        }
    }
}
