namespace ASP_app.Models;

public class Blog
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public string Author { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; } = DateTime.Now;

  public List<Comment> Comments { get; set; } = [];

  public double AverageRating => Comments.Count != 0
      ? Math.Round(Comments.Average(c => c.Rating), 1)
      : 0;
}