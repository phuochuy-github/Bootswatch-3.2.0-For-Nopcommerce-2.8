using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nop.Plugin.BootswatchTheme.Selector.Map;
using Nop.Plugin.BootswatchTheme.Selector.Domain;
using Nop.Data;
using System.Data.Entity.Infrastructure;
using System.Data;
using Nop.Core;
using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;

namespace Nop.Plugin.BootswatchTheme.Selector.Data
{
    public class SelectorObjectContext : DbContext, IDbContext
    {
        public SelectorObjectContext(string nameConnectionString)
            : base(nameConnectionString)
        {
            Database.SetInitializer<SelectorObjectContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SelectorRecordMap());
            base.OnModelCreating(modelBuilder);
        }

        public string CreateDatabaseInstallationScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        public void Install()
        {
            Database.SetInitializer<SelectorObjectContext>(null);
            Database.ExecuteSqlCommand(CreateDatabaseInstallationScript());
            SaveChanges();
        }

        public void Uninstall()
        {

            var dbScript = "DROP TABLE BootswatchTheme_Selector";
            Database.ExecuteSqlCommand(dbScript);
            SaveChanges();
        }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Core.BaseEntity
        {
            return base.Set<TEntity>();
        }


        public int ExecuteSqlCommand(string sql, int? timeout = null, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}