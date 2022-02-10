using FenziBill.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FenziBill.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FenziBillController : AbpControllerBase
{
    protected FenziBillController()
    {
        LocalizationResource = typeof(FenziBillResource);
    }
}
