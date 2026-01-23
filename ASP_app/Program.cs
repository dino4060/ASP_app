using ASP_app.Repositories;
using ASP_app.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddTransient<BlogRepository>();
builder.Services.AddScoped<BlogService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}
app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/", () => "Hello Nhân handsome!").WithTags("Hello");
app.Run();
