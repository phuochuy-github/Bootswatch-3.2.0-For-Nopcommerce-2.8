using Nop.Plugin.BootswatchTheme.Selector.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Nop.Plugin.BootswatchTheme.Selector.Map
{
    public class SelectorRecordMap : EntityTypeConfiguration<SelectorRecord>
    {
        public SelectorRecordMap()
        {
            ToTable("BootswatchTheme_Selector");
            this.Ignore(d => d.Id);
            HasKey(m => m.ThemeId);
            Property(m => m.ThemeId).HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.ThemeName).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            Property(m => m.ActiveStatus).HasColumnType("bit");
        }
    }
}