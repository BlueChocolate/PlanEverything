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
        private int _themeFlag = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //关于如何配置主题和资源字典，请查看App.xaml中的pu:GlobalSettings
            if (_themeFlag == 0)
            {
                GlobalSettings.ChangeTheme("OrangeDark");
                _themeFlag = 1;
            }
            else
            {
                GlobalSettings.ChangeTheme("OrangeLight");
                _themeFlag = 0;
            }
        }

        private void AboutButtonOnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxX.Show(this, "计划一切 - PlaneEverything\n版本：0.0.1\n作者：傻逼", "关于", MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK);
        }
    }
}