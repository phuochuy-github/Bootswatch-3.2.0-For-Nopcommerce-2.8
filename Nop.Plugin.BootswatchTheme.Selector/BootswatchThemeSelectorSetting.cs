using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Plugin.BootswatchTheme.Selector.Data;
using Nop.Plugin.BootswatchTheme.Selector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.BootswatchTheme.Selector
{
    public class BootswatchThemeSelectorSetting
    {
        
        public string GetThemeName()
        {
            var connectionString = new DataSettingsManager().LoadSettings().DataConnectionString;
            var _context = new SelectorObjectContext(connectionString);
            var dbset = _context.Set<SelectorRecord>();
            foreach (var item in dbset.ToList())
            {
                if (item.ActiveStatus)
                {
                    return item.ThemeName;
                }
            }
            return "yeti";
        }

    }
}
