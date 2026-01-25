namespace ASP_app.Business.Types;

public class BlogData
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public string Author { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public List<CommentData> Comments { get; set; } = [];
  public double AverageRating { get; set; }
}