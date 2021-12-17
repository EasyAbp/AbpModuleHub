namespace EasyAbp.AbpModuleHub.Permissions
{
    public static class AbpModuleHubPermissions
    {
        public const string GroupName = "AbpModuleHub";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static class UserManagement
        {
            public const string Default = GroupName + ".UserManagement";
            public const string Management = Default + ".Management";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class ModuleManagement
        {
            public const string Default = GroupName + ".ModuleManagement";
            public const string Management = Default + ".Management";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
    }
}