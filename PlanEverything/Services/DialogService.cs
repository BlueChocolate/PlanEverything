using Panuon.WPF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlanEverything.Services
{
    public interface IDialogService
    {
        void ShowDialog(string info, string title);
    }

    public class DialogService: IDialogService
    {
        private readonly WindowX _windowsX;

        public void ShowDialog(string info, string title)
        {
            throw new NotImplementedException();
        }

        public DialogService(WindowX windowsX)
        {
            _windowsX = windowsX ?? throw new ArgumentNullException(nameof(windowsX));
        }
    }
}
