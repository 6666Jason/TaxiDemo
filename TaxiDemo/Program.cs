using Microsoft.EntityFrameworkCore;
using TaxiDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connecStringName = builder.Configuration.GetConnectionString("ConnectDatabase");
builder.Services.AddDbContext<DatabaseContext>(option =>
{
    option.UseSqlServer(connecStringName);
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
