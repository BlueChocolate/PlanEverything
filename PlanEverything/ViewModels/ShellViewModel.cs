using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Panuon.WPF.UI;
using PlanEverything.Helpers;
using PlanEverything.Models;
using PlanEverything.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace PlanEverything.ViewModels
{
    internal partial class ShellViewModel : ObservableObject
    {
        private readonly IShellService _shellService;
        public DashboardViewModel DashboardViewModel { get; private set; }
        public SettingsViewModel SettingsViewModel { get; private set; }
        public LogViewModel LogViewModel { get; private set; }
        public PlanViewModel PlanViewModel { get; private set; }
        public ObservableCollection<Plan> PlanItems { get; }

        public ShellViewModel()
        {
            _shellService = App.ServiceProvider.GetRequiredService<IShellService>();

            DashboardViewModel = new DashboardViewModel();
            SettingsViewModel = new SettingsViewModel();
            LogViewModel = new LogViewModel();
            PlanViewModel = new PlanViewModel();

            PlanItems = new ObservableCollection<Plan>()
            {
                new Plan
                {
                     Category = "工作",
                     Description = "这是一个测试计划",
                     EndDate = new System.DateTime(2021, 12, 31),
                     Name = "备份电影",
                     Notes = "这是一个测试计划",
                     Priority = "高",
                     StartDate = new System.DateTime(2021, 1, 1),
                     Status = "未开始",
                     Tags = "测试"
                },
                new Plan
                {
                    Category = "学习",
                    Description = "这是一个测试计划",
                    EndDate = new System.DateTime(2021, 12, 31),
                    Name = "百度贴吧签到",
                    Notes = "这是一个测试计划",
                    Priority = "高",
                    StartDate = new System.DateTime(2021, 1, 1),
                    Status = "未开始",
                    Tags = "屁用没有"
                }
            };

            IsMenuOpen = true;
            MenuButtonIcon = "\uf100";

            PlanSelectedIndex = -1;

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
        private void DeletePlan(object? parameter)
        {
            if (parameter is Plan plan)
            {
                if (_shellService.ShowConfirmDialog($"你确定要删除“{plan.Name}”吗？", "删除计划"))
                {
                    PlanItems.Remove(plan);
                    PlanSelectedIndex = -1;
                    MenuSelectedIndex = 0;
                }
            }
        }


        #region 窗体控制命令
        [RelayCommand]
        private static void MinimizeWindow(object? parameter)
        {
            if (parameter is WindowX windowX)
            {
                windowX.Minimize();
            }
        }

        [RelayCommand]
        private static void MaximizeOrRestore(object? parameter)
        {
            if (parameter is WindowX windowX)
            {
                //window.MaximizeOrRestore();
                if (windowX.WindowState == WindowState.Maximized)
                {
                    windowX.Normalmize();
                }
                else
                {
                    windowX.Maximize();
                }
            }
        }

        [RelayCommand]
        private static void CloseWindow(object? parameter)
        {
            if (parameter is WindowX windowX)
            {
                windowX.Close();
            }
        }

        [RelayCommand]
        private void OpenOrCloseMenu()
        {
            DebugLog += "SwitchMenu\n";
            IsMenuOpen = !IsMenuOpen;
            MenuButtonIcon = IsMenuOpen ? "\uf100" : "\uf101;";
        }
        #endregion

        [RelayCommand]
        private void ShowAbout(object? parameter)
        {
            _shellService.ShowInfoDialog("计划一切 - PlaneEverything\n版本：0.0.1\n作者：傻逼", "关于");
        }

        #region 左侧菜单控制方法
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
            DebugLog += $"PlanSelectionChanged: {value}\n";
            if (PlanSelectedIndex != -1)
            {
                MenuSelectedIndex = -1;
                ViewSelectedIndex = 3;

                PlanViewModel.CurrentPlan = PlanItems[PlanSelectedIndex];
            }
        }
        #endregion

    }
}
