using BlazorAppTestNetBeautyWithPdb.Data;
using ClassLibrary1;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

Class1.Test();

CleanDllAtRoot();

Class1.Test();



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


static void CleanDllAtRoot()
{
#if RELEASE
    File.Delete("ClassLibrary1.dll");
    File.Delete("ClassLibrary2.dll");
    File.Delete("ClassLibrary1.pdb");
    File.Delete("ClassLibrary2.pdb");
#endif
}