using FluentValidation;
using Nop.Core;
using Nop.Services.Localization;
using Nop.Web.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nop.Plugin.BootswatchTheme.Selector.Domain
{
    public class SelectorRecordValidator : AbstractValidator<SelectorRecord>
    {
        public SelectorRecordValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ThemeId)
                .NotNull().WithMessage(localizationService.GetResource("Nop.Plugin.BootswatchTheme.Selector.ThemeIdNotNullError"))
                .NotEmpty().WithMessage(localizationService.GetResource("Nop.Plugin.BootswatchTheme.Selector.ThemeIdNotEmptyError"));
        }
    }


}