using eStore.Data;
using eStore.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add configuration providers
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>()
	.AddEnvironmentVariables();

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddHttpClient();

//SQLite3
// var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
// if (defaultConnection != null)
// {
// 	builder.Services.AddDbContext(defaultConnection);
// }

//Azure SQL Server
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSqlConnection"), sqlOptions => sqlOptions.EnableRetryOnFailure()));


builder.Services.AddRepositories();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.MapControllerRoute(
	name: "pagination",
	pattern: "Products/Page{productPage}",
	defaults: new { Controller = "Home", action = "Index" });

app.MapDefaultControllerRoute();

app.MapHub<ChatHub>("/chathub");

SeedData.EnsurePopulate(app);

app.Run();