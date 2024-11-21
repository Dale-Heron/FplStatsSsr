using FplStatsSsr.Components;
using FplStatsSsr.Components.Services;

var builder = WebApplication.CreateBuilder(args);

AddServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


static void AddServices(IServiceCollection services)
{
    // Add services to the container.
    services.AddRazorComponents()
        .AddInteractiveServerComponents();

    services.AddHttpClient();

    services.AddSingleton<GetFplDataService>();
}
