using Microsoft.EntityFrameworkCore;
using ASP_app.Contexts;
using ASP_app.Models;
using ASP_app.Types;
using static ASP_app.Helpers.FilterHelper;

namespace ASP_app.Repositories;

public class BlogRepo(AppDbContext context)
{
  public async Task<IEnumerable<Blog>> FindAll(BlogFilter filter)
  {
    return await context.Blogs
            .Include(b => b.Comments)
            .WhereHasValue(filter.Author, b => b.Author.Contains(filter.Author!))
            .WhereHasValue(filter.Rating, b => b.AverageRating >= filter.Rating!.Value)
            .ToListAsync();
  }
}