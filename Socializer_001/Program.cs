using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Socializer_001.Areas.Identity.Data;
using Socializer_001.Email_Service;
using Socializer_001.Models;
using Socializer_001.Services;
using Services;
//using Socializer_001.Email_Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var configuration = builder.Configuration;
builder.Services.AddDbContext<SocialiazerDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SocializerDataBase")));
builder.Services.AddDbContext<AuthenticationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationDBContextConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;

}).AddEntityFrameworkStores<AuthenticationDBContext>();

builder.Services.AddAuthentication().AddGoogle(googleoptions =>
{
    googleoptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleoptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
    googleoptions.CallbackPath = "/signin-google";
});

builder.Services.AddTransient<IEmailSender<ApplicationUser>, EmailSender>();
builder.Services.AddScoped<GetUserOptionalDataAsync>();
builder.Services.AddScoped<CustomerDataService>();
builder.Services.AddScoped<CryptoDataService>();
builder.Services.AddScoped<OrderDataService>();
builder.Services.AddScoped<OrderItemsDataService>();


builder.Services.AddRazorPages();

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

app.MapStaticAssets();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
