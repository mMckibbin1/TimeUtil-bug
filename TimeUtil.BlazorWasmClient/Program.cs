using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TimeUtil.BlazorWasmClient;
using TimeUtil.BlazorWasmClient.Services;
using TimeUtil.Components;
using TimeUtil.Shared.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddTimeUtilComponents();
builder.Services.AddSingleton<IOutlookCalendarCSVParseService, OutlookCSVParseJS>();

await builder.Build().RunAsync();
