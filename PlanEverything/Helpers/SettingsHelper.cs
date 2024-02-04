using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PlanEverything.Helpers
{
    public static class SettingsHelper
    {
        private static string _settingsFilePath;

        static SettingsHelper()
        {
            _settingsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.json");
        }

        private static void Load()
        {
            
        }

        private static void Save(object settings)
        {
            
        }
    }
}
