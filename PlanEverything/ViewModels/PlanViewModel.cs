using CommunityToolkit.Mvvm.ComponentModel;
using PlanEverything.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanEverything.ViewModels
{
    internal partial class PlanViewModel : ObservableObject
    {
        [ObservableProperty]
        public Plan _currentPlan;
    }
}
