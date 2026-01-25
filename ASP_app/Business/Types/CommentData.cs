namespace ASP_app.Business.Types;

public class CommentData
{
  public int Id { get; set; }
  public string User { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public int Rating { get; set; }
}