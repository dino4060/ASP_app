using ASP_app.Database;
using ASP_app.Repositories;
using ASP_app.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddOpenApi();
builder.Services.AddControllers()
  .AddJsonOptions(options =>
  {
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
  });
builder.Services.AddTransient<BlogRepo>();
builder.Services.AddScoped<BlogService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
  try
  {
    if (await context.Database.CanConnectAsync())
    {
      Console.WriteLine("------------------------------------------");
      Console.WriteLine("DATABASE CONNECTION: SUCCESS <3");
      Console.WriteLine("------------------------------------------");
    }
  }
  catch (Exception ex)
  {
    Console.WriteLine("------------------------------------------");
    Console.WriteLine($"DATABASE CONNECTION: FAILED :((");
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
