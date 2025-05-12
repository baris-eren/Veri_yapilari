using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AnketApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ⬇️ JsonStore'u DI sistemine ekle
builder.Services.AddSingleton<AnketApp.Data.JsonStore>();

// Session servisi için gerekli ayarlar:
builder.Services.AddDistributedMemoryCache(); // <-- GEREKLİ
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // HTTPS'ye yönlendirme
app.UseStaticFiles();      // Statik dosyaların sunulması için bu satır gerekiyor

app.UseRouting();

app.UseAuthentication();  // Eğer kimlik doğrulama kullanıyorsanız
app.UseAuthorization();   // Yetkilendirme işlemleri

app.UseSession();         // Session yönetimi için burası önemli

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Survey}/{action=Index}/{id?}");

app.Run();
