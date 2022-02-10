using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FenziBill;

[Dependency(ReplaceServices = true)]
public class FenziBillBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FenziBill";
}
