using System;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VSoft.Common.UI.APP.Base.View.Main.Methods;

namespace VSoft.Common.UI.APP.Base.View.Main;

public class AppServices
{
    public static async void RunApp(Action<WebAssemblyHostBuilder>? action = null)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(null);
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.RegisterApp(builder.Configuration, builder.HostEnvironment.BaseAddress, "appsettings.json");
        action?.Invoke(builder);

        await builder.Build().RunAsync();

    }
}

