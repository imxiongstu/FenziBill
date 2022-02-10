using Volo.Abp.Settings;

namespace FenziBill.Settings;

public class FenziBillSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FenziBillSettings.MySetting1));
    }
}
