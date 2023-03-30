using EMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EMS.Permissions;

public class EMSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var eMSGroup = context.AddGroup(EMSPermissions.GroupName, L("Permission:EMS"));

        var employeePermission = eMSGroup.AddPermission(EMSPermissions.Employees.Default, L("Permission:Employees"));
        employeePermission.AddChild(EMSPermissions.Employees.Create, L("Permission:Employees.Create"));
        employeePermission.AddChild(EMSPermissions.Employees.Edit, L("Permission:Employees.Edit"));
        employeePermission.AddChild(EMSPermissions.Employees.Delete, L("Permission:Employees.Delete"));



        var departmentsPermission = eMSGroup.AddPermission(
    EMSPermissions.Departments.Default, L("Permission:Departments"));
        departmentsPermission.AddChild(
            EMSPermissions.Departments.Create, L("Permission:Departments.Create"));
        departmentsPermission.AddChild(
            EMSPermissions.Departments.Edit, L("Permission:Departments.Edit"));
        departmentsPermission.AddChild(
            EMSPermissions.Departments.Delete, L("Permission:Departments.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EMSResource>(name);
    }
}
