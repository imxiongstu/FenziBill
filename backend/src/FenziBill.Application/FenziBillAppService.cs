using System;
using System.Collections.Generic;
using System.Text;
using FenziBill.Localization;
using Volo.Abp.Application.Services;

namespace FenziBill;

/* Inherit your application services from this class.
 */
public abstract class FenziBillAppService : ApplicationService
{
    protected FenziBillAppService()
    {
        LocalizationResource = typeof(FenziBillResource);
    }
}
