using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PlanEverything.Services;
using PlanEverything.ViewModels;
using PlanEverything.Views;
using System;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PlanEverything
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 注册服务
            var services = new ServiceCollection();
            services.AddSingleton<IShellService, ShellService>();
            ServiceProvider = services.BuildServiceProvider();

            // 设置主窗口并显示
            var shellService = ServiceProvider.GetRequiredService<IShellService>();
            var shellWindow = shellService.GetShell();
            shellWindow.DataContext = new ShellViewModel();
            MainWindow = shellWindow;
            shellService.GetShell().Show();
        }
    }
}
