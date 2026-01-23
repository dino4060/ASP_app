namespace ASP_app.Models;

public class Comment(string user, string content, int rating)
{
  public string User { get; set; } = user;
  public string Content { get; set; } = content;
  public int Rating { get; set; } = rating;
}