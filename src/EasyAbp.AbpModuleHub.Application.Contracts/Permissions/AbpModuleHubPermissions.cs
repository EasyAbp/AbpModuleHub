namespace EasyAbp.AbpModuleHub.Permissions
{
    public static class AbpModuleHubPermissions
    {
        public const string GroupName = "AbpModuleHub";

        public static class UserManagement
        {
            public const string Default = GroupName + ".UserManagement";
            public const string Management = Default + ".Management";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class HubModuleManagement
        {
            public const string Default = GroupName + ".HubModuleManagement";
            public const string Management = Default + ".Management";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class HubModuleTypeManagement
        {
            public const string Default = GroupName + ".HubModuleTypeManagement";
            public const string Management = Default + ".Management";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
    }
}