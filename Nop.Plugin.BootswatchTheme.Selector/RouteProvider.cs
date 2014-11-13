using Nop.Web.Framework.Mvc.Routes;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nop.Plugin.BootswatchTheme.Selector
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute("Nop.Plugin.BootswatchTheme.Selector.Configure",
                 "Plugins/BootswatchThemeSelector/Configure",
                 new { controller = "BootswatchThemeSelector", action = "Configure" },
                 new[] { "Nop.Plugin.BootswatchTheme.Selector.Controllers" }
            );

            routes.MapRoute("Nop.Plugin.BootswatchTheme.Selector.PublicInfo",
                 "Plugins/BootswatchThemeSelector/PublicInfo",
                 new { controller = "BootswatchThemeSelector", action = "PublicInfo" },
                 new[] { "Nop.Plugin.BootswatchTheme.Selector.Controllers" }
            );
        }
        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
