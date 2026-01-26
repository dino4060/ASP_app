using ASP_app.Business;
using ASP_app.Config.Database;
using ASP_app.Config.Mapper;
using ASP_app.Models;
using ASP_app.Models.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// 1. Identity Setup
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
  options.Password.RequireDigit = true;
  options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<AppDbContext>();

// 2. JWT Setup
builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme =
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuer = true,
    ValidIssuer = builder.Configuration["JWT:Issuer"],
    ValidateAudience = true,
    ValidAudience = builder.Configuration["JWT:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(
          System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]!)
      )
  };
});

// 3. Authorization Policies (Cho User cấp 2, Admin...)
builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
  options.AddPolicy("PowerUser", policy => policy.RequireRole("Admin", "UserLevel2"));
});

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(typeof(AppMapperProfile).Assembly);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddTransient<BlogRepo>();
builder.Services.AddScoped<BlogService>();

var app = builder.Build();

app.UseHttpsRedirection();

// 1. Phải đặt Authentication trước Authorization
app.UseAuthentication();
app.UseAuthorization();

// 2. Cấu hình Route Mapping
app.MapControllers();

// 3. Bypass cho trang chủ "/" nếu bạn không dùng Controller cho nó
app.MapGet("/", () => "Public API is running").AllowAnonymous();

await app.CheckDatabaseConnection();

if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.Run();
