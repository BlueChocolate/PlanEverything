using CommunityToolkit.Mvvm.ComponentModel;

namespace PlanEverything.ViewModels
{
    internal partial class LogViewModel: ObservableObject
    {
        [ObservableProperty]
        private string? _logText;
    }
}
