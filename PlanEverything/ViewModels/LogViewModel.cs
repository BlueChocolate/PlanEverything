using CommunityToolkit.Mvvm.ComponentModel;
using Panuon.WPF.UI;
using System.Windows.Controls;

namespace PlanEverything.ViewModels
{
    internal partial class LogViewModel: ObservableObject
    {
        [ObservableProperty]
        private string? _logText;
    }
}
