using Microsoft.Win32;
using Panuon.WPF.UI;
using System.Windows.Interop;
using System.Windows;
using System.Runtime.InteropServices;

namespace PlanEverything.Helpers
{
    public static class ThemeHelper
    {
        private static Timer _timer;
        private static ThemeMode _currentTheme;
        private static ThemeMode _currentSystemTheme;

        public static ThemeMode CurrentTheme { get => _currentTheme; private set => _currentTheme = value; }
        public static Action<ThemeMode>? ThemeChanged { get; set; }

        // 修改主题并触发主题变更事件
        public static void ChangeTheme(ThemeMode theme)
        {
            // 执行主题变更相关的逻辑
            switch (theme)
            {
                case ThemeMode.Default:

                    break;
                case ThemeMode.Light:
                    CurrentTheme = ThemeMode.Light;
                    GlobalSettings.ChangeTheme("Light");
                    break;
                case ThemeMode.Dark:
                    CurrentTheme = ThemeMode.Dark;
                    GlobalSettings.ChangeTheme("Dark");
                    break;
                default:
                    break;
            }

            // 触发主题变更事件
            OnThemeChanged(theme);
        }

        private static void OnThemeChanged(ThemeMode theme)
        {
            ThemeChanged?.Invoke(theme);
        }

        public static ThemeMode GetSystemTheme()
        {
            const string registryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

            // 获取注册表中的 "AppsUseLightTheme" 值
            object? lightThemeValue = Registry.GetValue(registryKey, "AppsUseLightTheme", null);

            // 如果值存在并且为 1，则系统使用亮色主题；否则使用暗色主题
            if (lightThemeValue == null || (int)lightThemeValue == 1)
            {
                return ThemeMode.Light;
            }
            else
            {
                return ThemeMode.Dark;
            }
        }

        private static void OnSystemThemeChanged(object? state)
        {
            // 获取系统主题并与当前主题进行比较
            ThemeMode newSystemTheme = GetSystemTheme();

            if (newSystemTheme != _currentSystemTheme)
            {
                _currentSystemTheme = newSystemTheme;
            }
        }

        static ThemeHelper()
        {
            // 监听系统主题变更计时器
            _timer = new Timer(OnSystemThemeChanged, null, 0, 1000);
        }
    }

    public enum ThemeMode
    {
        Default = 0,
        Light,
        Dark
    }
}
