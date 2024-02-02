using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Panuon.WPF.UI;
using System.Windows;

namespace PlanEverything.ViewModels
{
    internal partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private Theme _theme;

        partial void OnThemeChanged(Theme value)
        {
            ChangeTheme(value);
        }

        private static void ChangeTheme(Theme theme)
        {
            switch (theme)
            {
                case Theme.Default:

                    break;
                case Theme.Light:
                    GlobalSettings.ChangeTheme("OrangeLight");
                    break;
                case Theme.Dark:
                    GlobalSettings.ChangeTheme("OrangeDark");
                    break;
                default:
                    break;
            }
        }

        public SettingsViewModel()
        {
            Theme = Theme.Default;
        }
    }

    public enum Theme
    {
        Default = 0,
        Light,
        Dark
    }
}
