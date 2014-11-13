using FluentValidation.Attributes;
using Nop.Core;
using Nop.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Plugin.BootswatchTheme.Selector.Domain
{
    [Validator(typeof(SelectorRecord))]
    public class SelectorRecord : BaseEntity
    {
        public int ThemeId { set; get; }
        public string ThemeName { set; get; }
        public bool ActiveStatus { set; get; }
    }


}