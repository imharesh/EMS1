﻿using System.Threading.Tasks;
using EMS.Localization;
using EMS.MultiTenancy;
using EMS.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace EMS.Web.Menus;

public class EMSMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<EMSResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                EMSMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        context.Menu.AddItem(
    new ApplicationMenuItem(
        "EMS",
        l["Menu:EMS"],
        icon: "fa fa-users"
    ).AddItem(
        new ApplicationMenuItem(
            "EMS.Employees",
            l["Menu:Employees"],
            url: "/Employees"
        ).RequirePermissions(EMSPermissions.Employees.Default)
    ).AddItem( // ADDED THE NEW "AUTHORS" MENU ITEM UNDER THE "BOOK STORE" MENU
        new ApplicationMenuItem(
            "EMS.Departments",
            l["Menu:Departments"],
            url: "/Departments"
        ).RequirePermissions(EMSPermissions.Employees.Default)
    )
);


        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
