using Microsoft.Net.Http.Headers;
using WingineersMeasureItAll.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("Wingineers", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://azurecandidatetestapi.azurewebsites.net/api/v1/");
    httpClient.DefaultRequestHeaders.Add("ApiKey", "test1234");
});
builder.Services.AddTransient<IWingineersApiProxy, WingineersApiProxy>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SalesPeople}/{action=Index}/{id?}");

app.Run();

