using Microsoft.EntityFrameworkCore;
using real_estate.Data;
using Microsoft.AspNetCore.Identity;
using real_estate_user.Data;
using real_estate.Areas.Identity.Data;
using real_estate.Controllers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();


builder.Services.AddDbContext<real_estateContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<real_estateUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<real_estateContext>();
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
