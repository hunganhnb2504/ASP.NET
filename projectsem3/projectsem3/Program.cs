using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using projectsem3.Data;
using projectsem3.Repositories;
using projectsem3.Data;
using projectsem3.Models;
using projectsem3.Repositories;
using System.Text;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddIdentity<ApplicationsUser, IdentityRole>()
        .AddEntityFrameworkStores<StarSecurityServicesContext>()
        .AddDefaultTokenProviders();
builder.Services.AddDbContext<StarSecurityServicesContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("StarSecurityServicesContext"));
});
builder.Services.AddScoped<IAccountRepostitory, AccountRepository>();
builder.Services.AddAuthentication(Options =>
{
    Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    Options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
    Options =>
    {
        Options.SaveToken = true;
        Options.RequireHttpsMetadata = false;
        Options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["JWT:ValidateIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidateAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("vi-VN");
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("vi-VN") };
    options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("vi-VN") };
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
