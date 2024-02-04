using Panuon.WPF.UI;
using PlanEverything.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlanEverything.Services
{
    public interface IShellService
    {
        public void ShowInfoDialog(string message, string title);
        public bool ShowConfirmDialog(string message, string title);
        public ShellWindow GetShell();
    }

    public class ShellService : IShellService
    {
        private readonly ShellWindow _shellWindow;

        public ShellService()
        {
            _shellWindow = new ShellWindow();
        }

        public void ShowInfoDialog(string message, string title)
        {
            MessageBoxX.Show(_shellWindow, message, title, MessageBoxButton.OK, MessageBoxIcon.Info, DefaultButton.YesOK);
        }

        public bool ShowConfirmDialog(string message, string title)
        {
            var result = MessageBoxX.Show(_shellWindow, message, title, MessageBoxButton.OKCancel, MessageBoxIcon.Question, DefaultButton.YesOK);
            if (result == MessageBoxResult.OK || result == MessageBoxResult.Yes)
            {
                return true;
            }
            return false;
        }

        public ShellWindow GetShell()
        {
            return _shellWindow;
        }
    }
}
