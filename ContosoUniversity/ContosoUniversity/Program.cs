using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<ContosoUniversityContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ContosoUniversityContext") ?? throw new InvalidOperationException("Connection string 'ContosoUniversityContext' not found.")));
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found.")));



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    SeedData.Initialize(services);
//}
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

app.Run();
