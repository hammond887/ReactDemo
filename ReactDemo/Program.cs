using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddReact();

//make sure a js engine is registered, or you will get error
builder.Services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName).AddV8();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//initialise reactjs.net. must be before static files
app.UseReact(config =>
{
    //if you want to use server-side rendering of react components, add all necessary js files here. including components as well as dependicies
    //example: config .AddScript("~/js/First.jsx") .AddScript("~/js/Second.jsx");
    //if you use external build too (babel,gulp) you can improve performance by disabling reactjs.net version of babel + loading pre- transpiled script
    //example config.SetLoadBabel(false)  .sddscriptwithouttransform("~/js/bundle.server.js");
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
