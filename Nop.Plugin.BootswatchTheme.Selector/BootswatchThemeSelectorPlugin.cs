using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using System.Web.Routing;
using System.Collections.Generic;
using Nop.Services.Common;
using System.Data.SqlClient;
using Nop.Core.Data;
using System;
using Nop.Plugin.BootswatchTheme.Selector.Data;
using Nop.Plugin.BootswatchTheme.Selector.Domain;

namespace Nop.Plugin.BootswatchTheme.Selector
{
    public class BootswatchThemeSelectorPlugin : BasePlugin, IWidgetPlugin
    {
        private SelectorObjectContext _context;

        public BootswatchThemeSelectorPlugin(SelectorObjectContext context)
        {
            _context = context;
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "BootswatchThemeSelector";
            routeValues = new System.Web.Routing.RouteValueDictionary();
            routeValues["NameSpaces"] = "Nop.Plugin.BootswatchTheme.Selector.Controllers";
            routeValues["area"] = null;
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "BootswatchThemeSelector";
            routeValues = new RouteValueDictionary()
            {
                {"Namespaces", "Nop.Plugin.BootswatchTheme.Selector.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }

        public bool Authenticate()
        {
            return true;
        }

        public override void Install()
        {
            _context.Install();
            var selector = _context.Set<SelectorRecord>();
            selector.Add(new SelectorRecord() { ThemeName = "default", ActiveStatus = true });
            selector.Add(new SelectorRecord() { ThemeName = "yeti", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "flaty", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "sandstone", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "united", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "darkly", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "united", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "cosmo", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "lumen", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "paper", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "readable", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "simplex", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "slate", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "spacelab", ActiveStatus = false });
            selector.Add(new SelectorRecord() { ThemeName = "superhero", ActiveStatus = false });
            _context.SaveChanges();
            base.Install();
        }


        public override void Uninstall()
        {
            _context.Uninstall();
            base.Uninstall();
        }

        public System.Collections.Generic.IList<string> GetWidgetZones()
        {
            return new List<string>() { "home_page_top" };
        }

        protected string CreateTable()
        {
            try
            {
                var connectionString = new DataSettingsManager().LoadSettings().DataConnectionString;
                //parse database name
                var builder = new SqlConnectionStringBuilder(connectionString);
                var tableName = builder.InitialCatalog;
                //now create connection string to 'master' dabatase. It always exists.
                var masterCatalogConnectionString = builder.ToString();
                string sql = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~\Plugins\BootswatchTheme.Selector\App_Data\BootswatchTheme_Selector_Plugin_CreateTable.sql"));
                string query = string.Format(sql);
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Format("can't create to table: " + ex.Message);
            }
        }

        protected string DropTable()
        {
            try
            {
                var connectionString = new DataSettingsManager().LoadSettings().DataConnectionString;
                //parse database name
                var builder = new SqlConnectionStringBuilder(connectionString);
                var tableName = builder.InitialCatalog;
                //now create connection string to 'master' dabatase. It always exists.
                var masterCatalogConnectionString = builder.ToString();
                string sql = "DROP TABLE BootswatchTheme_Selector";
                string query = string.Format(sql);
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Format("can't drop to table: " + ex.Message);
            }
        }
    }
}