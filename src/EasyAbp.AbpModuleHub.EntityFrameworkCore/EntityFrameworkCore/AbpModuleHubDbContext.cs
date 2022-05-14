using EasyAbp.AbpModuleHub.Authors;
using EasyAbp.AbpModuleHub.HubModules;
using EasyAbp.AbpModuleHub.Modules;
using EasyAbp.EShop.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using EasyAbp.EShop.Orders.EntityFrameworkCore;
using EasyAbp.EShop.Payments.EntityFrameworkCore;
using EasyAbp.EShop.Products.EntityFrameworkCore;
using EasyAbp.EShop.Stores.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace EasyAbp.AbpModuleHub.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class AbpModuleHubDbContext :
        AbpDbContext<AbpModuleHubDbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }

        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        // Hub Entities
        public DbSet<HubModule> ModuleProducts { get; set; }
        public DbSet<HubModuleType> ModuleTypes { get; set; }

        public AbpModuleHubDbContext(DbContextOptions<AbpModuleHubDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();
            builder.ConfigureEShop();

            /* Configure your own tables/entities inside here */

            builder.Entity<HubModule>(b =>
            {
                b.ToTable(AbpModuleHubConsts.DbTablePrefix + "HubModules", AbpModuleHubConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(e => e.Name).HasMaxLength(512).IsRequired();
                b.Property(e => e.Description).HasMaxLength(2048).IsRequired();
                b.Property(e => e.CoverUrl).HasMaxLength(256);
                b.Property(e => e.PayMethod).HasMaxLength(64).IsRequired();
                b.Property(e => e.OriginalPrice).HasColumnType("decimal(20,8)");
                b.Property(e => e.Price).HasColumnType("decimal(20,8)");
                b.Property(e => e.ProductId).IsRequired();
                b.Property(e => e.AuthorId).IsRequired();
            });

            builder.Entity<HubModuleType>(b =>
            {
                b.ToTable(AbpModuleHubConsts.DbTablePrefix + "HubModuleTypes", AbpModuleHubConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(e => e.Name).HasMaxLength(64).IsRequired();
                b.Property(e => e.Description).HasMaxLength(1024);
            });

            builder.Entity<Author>(b =>
            {
                b.ToTable(AbpModuleHubConsts.DbTablePrefix + "Authors", AbpModuleHubConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(e => e.Name).HasMaxLength(64).IsRequired();
                b.Property(e => e.Email).HasMaxLength(64).IsRequired();
                b.Property(e => e.Avatar).HasMaxLength(256).IsRequired();
            });
            builder.ConfigureEShopOrders();
            builder.ConfigureEShopPayments();
            builder.ConfigureEShopProducts();
            builder.ConfigureEShopStores();
        }
    }
}
