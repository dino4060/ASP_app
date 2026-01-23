using System.Linq.Expressions;

namespace ASP_app.Helpers;

public static class FilterHelper
{
  public static IQueryable<T> WhereHasValue<T>(
    this IQueryable<T> query, string? value,
    Expression<Func<T, bool>> predicate
  ) => string.IsNullOrWhiteSpace(value)
      ? query
      : query.Where(predicate);

  public static IQueryable<T> WhereHasValue<T>(
    this IQueryable<T> query, double? value,
    Expression<Func<T, bool>> predicate
  ) => !value.HasValue
      ? query
      : query.Where(predicate);
}