namespace ASP_app.Tests.Helpers;

using ASP_app.Helpers;
using Xunit;

public class FilterHelperTests
{
  private readonly IQueryable<MockModel> _data = new List<MockModel>
    {
        new() { Name = "Alpha", Score = 10.5 },
        new() { Name = "Beta", Score = 20.0 },
        new() { Name = "Gamma", Score = 30.5 }
    }.AsQueryable();

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  [InlineData("   ")]
  public void WhereHasValue_String_ShouldReturnOriginal_WhenValueIsNullOrEmpty(string? filterValue)
  {
    var result = _data.WhereHasValue(filterValue, x => x.Name == filterValue).ToList();

    Assert.Equal(_data.Count(), result.Count);
  }

  [Fact]
  public void WhereHasValue_String_ShouldFilter_WhenValueIsProvided()
  {
    string filterValue = "Alpha";

    var result = _data.WhereHasValue(filterValue, x => x.Name == filterValue).ToList();

    Assert.Single(result);
    Assert.Equal("Alpha", result[0].Name);
  }

  [Fact]
  public void WhereHasValue_Double_ShouldFilter_WhenValueHasValue()
  {
    double? filterValue = 20.0;

    var result = _data.WhereHasValue(filterValue, x => x.Score > filterValue).ToList();

    Assert.Single(result);
    Assert.Equal("Gamma", result[0].Name); // 30.5 > 20.0
  }

  [Fact]
  public void WhereHasValue_Double_ShouldReturnOriginal_WhenValueIsNull()
  {
    double? filterValue = null;

    var result = _data.WhereHasValue(filterValue, x => x.Score == filterValue).ToList();

    Assert.Equal(_data.Count(), result.Count);
  }

}

public class MockModel
{
  public string Name { get; set; } = string.Empty;
  public double Score { get; set; }
}