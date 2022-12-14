using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using IMS.WebApp.Data;
using IMS.Plugins.InMemory;
using IMS.UseCases;
using IMS.UseCases.Interfaces;
using IMS.UseCases.Inventories;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products;
using IMS.UseCases.Products.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IAddInventory, AddInventory>();
builder.Services.AddTransient<IEditInventory, EditInventory>();
builder.Services.AddTransient<IViewInventoryByName, ViewInventoryByName>();
builder.Services.AddTransient<IViewInventoryById, ViewInventoryById>();
builder.Services.AddTransient<IViewProductsByName, ViewProductsByName>();
builder.Services.AddTransient<IAddProduct, AddProduct>();

builder.Services.AddTransient<IViewInventoryByName, ViewInventoryByName>();

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