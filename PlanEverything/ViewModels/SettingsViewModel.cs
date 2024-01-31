using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Panuon.WPF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanEverything.ViewModels
{
    internal partial class SettingsViewModel: ObservableObject
    {
        [ObservableProperty]
        private Theme _theme;

        [RelayCommand]
        private void ChangeTheme(Theme theme)
        {
            switch (theme)
            {
                case Theme.Default:
                    GlobalSettings.ChangeTheme("OrangeLight");
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
    }

    public enum Theme
    {
        Default,
        Light,
        Dark
    }
}
