using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TimeUtil.BlazorWasmClient;
using TimeUtil.BlazorWasmClient.Services;
using TimeUtil.Components;
using TimeUtil.Shared.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTimeUtilComponents();
builder.Services.AddSingleton<IOutlookCalendarCSVParseService, OutlookCSVParseService>();

await builder.Build().RunAsync();
