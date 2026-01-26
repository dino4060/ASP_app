using ASP_app.Business;
using ASP_app.Config.Database;
using ASP_app.Config.Mapper;
using ASP_app.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(typeof(AppMapperProfile).Assembly);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddTransient<BlogRepo>();
builder.Services.AddScoped<BlogService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/", () => "Hello Nhân handsome!").WithTags("Hello");

await app.CheckDatabaseConnection();

if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.Run();
