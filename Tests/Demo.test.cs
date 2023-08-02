using System;
using Xunit;

/// <summary>
/// Just a demo test.
/// </summary>
public class MyTestClass
{
  [Fact]
  public void PassingTest()
  {
    Assert.Equal(4, Add(2, 2));
  }

  int Add(int x, int y)
  {
    return x + y;
  }
}
