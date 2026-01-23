namespace ASP_app.Models;

public class Blog(int id, string title, string content, string author, DateTime createdAt, List<Comment> comments)
{
  public int Id { get; set; } = id;
  public string Title { get; set; } = title;
  public string Content { get; set; } = content;
  public string Author { get; set; } = author;
  public DateTime CreatedAt { get; set; } = createdAt;
  public List<Comment> Comments { get; set; } = comments;

  public double AverageRating => Comments.Count != 0
    ? Math.Round(Comments.Average(c => c.Rating), 1)
    : 0;
}