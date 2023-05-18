using CommonLibrary;
using MVCPractice.Services;
using Microsoft.AspNetCore.Identity;
using MVCPrcatice.Models;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using MongoDB.Bson;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

var connectionString = AppConfiguration.connectionString;
var databaseName = AppConfiguration.databaseName;

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
       .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
       (connectionString, databaseName);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddMemoryCache();

//builder.Services.AddScoped<ICustomerService, CustomerRepository>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AccessDenied", policy =>
        policy.RequireAuthenticatedUser()
              .RequireRole("Admin")); // You can modify this policy as per your requirements
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/Customer/AccessDenied");
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
