namespace ASP_app.Helpers;

public static class FilterHelper
{
  public static bool IsPassed(string? value, Func<bool> predicate)
  {
    return string.IsNullOrWhiteSpace(value) || predicate();
  }

  public static bool IsPassed<T>(T? value, Func<bool> predicate) where T : struct
  {
    return !value.HasValue || predicate();
  }
}