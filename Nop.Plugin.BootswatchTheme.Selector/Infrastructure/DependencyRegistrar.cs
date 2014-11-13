using Autofac;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Core.Data;
using Autofac.Core;
using Nop.Plugin.BootswatchTheme.Selector.Domain;
using Nop.Plugin.BootswatchTheme.Selector.Data;

namespace Nop.Plugin.BootswatchTheme.Selector.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_bootswatch_selector";

        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<BootswatchThemeSelectorRepository>()
                .As<IBootswatchThemeSelectorRepository>()
                .InstancePerLifetimeScope();
            ////data layer
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();

            if (dataProviderSettings != null && dataProviderSettings.IsValid())
            {
                //register named context
                builder.Register<IDbContext>(c => new SelectorObjectContext(dataProviderSettings.DataConnectionString))
                    .Named<IDbContext>("nop_object_context_bootswatch_selector")
                    .InstancePerLifetimeScope();

                builder.Register<SelectorObjectContext>(c => new SelectorObjectContext(dataProviderSettings.DataConnectionString))
                    .InstancePerLifetimeScope();
            }
            else
            {
                //register named context
                builder.Register<IDbContext>(c => new SelectorObjectContext(c.Resolve<DataSettings>().DataConnectionString))
                    .Named<IDbContext>("nop_object_context_bootswatch_selector")
                    .InstancePerLifetimeScope();

                builder.Register<SelectorObjectContext>(c => new SelectorObjectContext(c.Resolve<DataSettings>().DataConnectionString))
                    .InstancePerLifetimeScope();
            }
            builder.RegisterType<EfRepository<SelectorRecord>>()
                .As<IRepository<SelectorRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            

            
        }

        public int Order
        {
            get { return 1; }
        }
    }
}