using System;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VegunSoft.Framework.Api.DtoClient.Token.Provider.Services;

namespace VSoft.Common.UI.APP.Base.View.Main.Methods;

public static class IServiceCollectionMethods
{
    public static void RegisterApp(this IServiceCollection services, WebAssemblyHostConfiguration configuration, string baseAddress, string jsonFileConfig = "appsettings.json")
    {
        services.AddSingleton<IConfigurationRoot>(configuration);


        services.AddBlazoredToast();
        services.AddSingleton(new TokenService().Init(string.Empty));
        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });


    }


}
