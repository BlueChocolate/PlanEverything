using System.Text;
using System.Windows;
using Panuon.WPF.UI;

namespace PlanEverything.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowX
    {
        private void AboutButtonOnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxX.Show(this, "计划一切 - PlaneEverything\n版本：0.0.1\n作者：傻逼", "关于", MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK);
        }
    }
}