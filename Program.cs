using Microsoft.AspNetCore.Identity;
using UmutYapi.Models.Context;
using UmutYapi.Models.Tablolar;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache(); // Session için memory cache servisi eklenir.

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(30); // Session timeout süresi.
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // GDPR için gerekli cookie ayarý
});
// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<YapiMalzemeContext>();
builder.Services.AddIdentity<Kullanici, UserRole>()
    .AddEntityFrameworkStores<YapiMalzemeContext>()
    .AddSignInManager()
    .AddTokenProvider<DataProtectorTokenProvider<Kullanici>>(TokenOptions.DefaultProvider);

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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
