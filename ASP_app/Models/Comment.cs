namespace ASP_app.Models;

public class Comment
{
  public int Id { get; set; }
  public string User { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public int Rating { get; set; }

  public int BlogId { get; set; }
  public Blog? Blog { get; set; }
}