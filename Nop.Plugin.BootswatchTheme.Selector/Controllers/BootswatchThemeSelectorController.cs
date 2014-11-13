using System.Web.Mvc;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Core.Data;
using Nop.Plugin.BootswatchTheme.Selector.Domain;
using Nop.Plugin.BootswatchTheme.Selector.Data;
using Nop.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace Nop.Plugin.BootswatchTheme.Selector.Controllers
{
    public class BootswatchThemeSelectorController : Controller
    {
        private IBootswatchThemeSelectorRepository _bootswatchThemeSelectorRepository;
        private ISettingService _settingService;
        public BootswatchThemeSelectorController(IBootswatchThemeSelectorRepository bootswatchThemeSelectorRepository, ISettingService settingService)
        {
            _bootswatchThemeSelectorRepository = bootswatchThemeSelectorRepository;
            _settingService = settingService;
            //bootswatchThemeSelectorSetting = _bootswatchThemeSelectorSetting;
        }

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            //var connectionString = new DataSettingsManager().LoadSettings().DataConnectionString;
            //var _context = new SelectorObjectContext(connectionString);
            //System.IO.File.WriteAllText(@"D:\WriteText.txt", str.ToString());
            var model = _bootswatchThemeSelectorRepository.GetAll();
            return View("Nop.Plugin.BootswatchTheme.Selector.Views.BootswatchThemeSelector.Configure", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(int current_theme_id, int new_theme_id)
        {
            Session["CURRENT_THEME_ID"] = new_theme_id;
            var current_them = _bootswatchThemeSelectorRepository.GetById(current_theme_id);
            current_them.ActiveStatus = false;
            var new_theme = _bootswatchThemeSelectorRepository.GetById(new_theme_id);
            new_theme.ActiveStatus = true;
            _bootswatchThemeSelectorRepository.Update(new_theme);

            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone)
        {
            return View("Nop.Plugin.BootswatchTheme.Selector.Views.BootswatchThemeSelector.PublicInfo");
        }

    }
}