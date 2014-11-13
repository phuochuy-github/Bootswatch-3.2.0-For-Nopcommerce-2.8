using Nop.Core.Data;
using Nop.Data;
using Nop.Plugin.BootswatchTheme.Selector.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nop.Plugin.BootswatchTheme.Selector.Data
{
    public class BootswatchThemeSelectorRepository : IBootswatchThemeSelectorRepository
    {
        private IRepository<SelectorRecord> _selectorRepository;

        public BootswatchThemeSelectorRepository(IRepository<SelectorRecord> selectorRepository)
        {
            _selectorRepository = selectorRepository;
        }

        public IList<SelectorRecord> GetAll()
        {
            return _selectorRepository.Table.ToList();
        }

        public SelectorRecord GetById(int id)
        {
            return _selectorRepository.GetById(id);
        }

        public void Add(SelectorRecord Entity)
        {
            _selectorRepository.Insert(Entity);
        }

        public void Update(SelectorRecord Entity)
        {
            _selectorRepository.Update(Entity);
        }

    }
}