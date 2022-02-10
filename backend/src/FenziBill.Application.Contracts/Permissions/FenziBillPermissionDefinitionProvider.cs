using FenziBill.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FenziBill.Permissions;

public class FenziBillPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FenziBillPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(FenziBillPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FenziBillResource>(name);
    }
}
