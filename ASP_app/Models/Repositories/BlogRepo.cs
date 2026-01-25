using Microsoft.EntityFrameworkCore;
using ASP_app.Config.Database;
using ASP_app.Models.Types;
using static ASP_app.Helpers.FilterHelper;

namespace ASP_app.Models.Repositories;

public class BlogRepo(AppDbContext context)
{
  public async Task<IEnumerable<Blog>> FindAll(BlogFilter filter)
  {
    return await context.Blogs
            .Include(b => b.Comments)
            .WhereHasValue(filter.Author, b => b.Author.Contains(filter.Author!))
            // .WhereHasValue(filter.Rating, b => b.AverageRating >= filter.Rating!.Value)
            .WhereHasValue(filter.Rating, b => b.Comments.Average(c => (double?)c.Rating) >= filter.Rating!.Value)
            .ToListAsync();
  }
}