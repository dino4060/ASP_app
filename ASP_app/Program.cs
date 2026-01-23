using ASP_app.Data;
using ASP_app.Repositories;
using ASP_app.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddTransient<BlogRepo>();
builder.Services.AddScoped<BlogService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
  try
  {
    // Lệnh này chỉ kiểm tra server có phản hồi hay không, không quan tâm bảng biểu
    if (await context.Database.CanConnectAsync())
    {
      Console.WriteLine("------------------------------------------");
      Console.WriteLine("DATABASE CONNECTION: SUCCESS (Đã thông!)");
      Console.WriteLine("------------------------------------------");
    }
  }
  catch (Exception ex)
  {
    Console.WriteLine("------------------------------------------");
    Console.WriteLine($"DATABASE CONNECTION: FAILED!");
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine("------------------------------------------");
  }
}

if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}
app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/", () => "Hello Nhân handsome!").WithTags("Hello");
app.Run();
