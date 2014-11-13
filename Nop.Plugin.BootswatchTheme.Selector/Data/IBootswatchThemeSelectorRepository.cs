using Nop.Plugin.BootswatchTheme.Selector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Plugin.BootswatchTheme.Selector.Data
{
    public interface IBootswatchThemeSelectorRepository
    {
        IList<SelectorRecord> GetAll();
        void Add(SelectorRecord Entity);
        SelectorRecord GetById(int id);
        void Update(SelectorRecord Entity);
    }
}