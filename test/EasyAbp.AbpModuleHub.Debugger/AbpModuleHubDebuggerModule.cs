using System;
using EasyAbp.AbpModuleHub.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NSubstitute;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.Users;

namespace EasyAbp.AbpModuleHub.Debugger
{
    [DependsOn(typeof(AbpModuleHubApplicationModule),
        typeof(AbpModuleHubEntityFrameworkCoreModule),
        typeof(AbpTestBaseModule),
        typeof(AbpAuthorizationModule),
        typeof(AbpAutofacModule))]
    public class AbpModuleHubDebuggerModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpIdentityServerBuilderOptions>(options => { options.AddDeveloperSigningCredential = false; });

            PreConfigure<IIdentityServerBuilder>(identityServerBuilder => { identityServerBuilder.AddDeveloperSigningCredential(false, System.Guid.NewGuid().ToString()); });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => { options.IsJobExecutionEnabled = false; });

            context.Services.AddAlwaysAllowAuthorization();

            var tempUser = Substitute.For<ICurrentUser>();
            tempUser.Id.Returns(Guid.NewGuid());

            context.Services.Replace(new ServiceDescriptor(typeof(ICurrentUser), tempUser));
        }
    }
}