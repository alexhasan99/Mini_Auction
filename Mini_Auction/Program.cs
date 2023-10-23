using Mini_Auction.Core.Interfaces;
using Mini_Auction.Core;
using Mini_Auction.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Mini_Auction.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using System.Configuration;
using Mini_Auction.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPersistense>();

builder.Services.AddDbContext<AuctionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionDbConnection")));

//Identity Configration
builder.Services.AddDefaultIdentity<AuctionUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuctionIdentityContext>();

builder.Services.AddDbContext<AuctionIdentityContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionIdentityDbConnection")));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
 