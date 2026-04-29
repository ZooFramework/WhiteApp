using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ZooFramework.ApiService;
using ZooFramework.WhiteApp.ApiService.SignalR;

namespace ZooFramework.WhiteApp.ApiService
{
    public class ApiStartup : ZooFrameworkApiStartupBase
    {
        protected override void RegisterExtraServicesBeforeSession(IServiceCollection services)
        {
        }

        protected override void RegisterExtraServicesAfterSession(IServiceCollection services)
        {
        }

        protected override void ConfigureExtraBeforeAll(IApplicationBuilder app)
        {
            app.UseFileServer();
            app.UseStaticFiles();
        }

        protected override IEnumerable<Type> GetHubsToInit()
        {
            yield return typeof(ChatHub);
        }

        protected override IEnumerable<JsonConverter> ExtraJsonConverters()
        {
            yield break;
        }
    }
}