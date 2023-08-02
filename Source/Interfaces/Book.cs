namespace DotnetLambdaDemo;

/// <summary>
/// Authoritative Book entity.
/// </summary>
public class Book
{
  public string Name { get; set; }
  public int Year { get; set; }

  public Book(string name, int year)
  {
    Name = name;
    Year = year;
  }
}

/// <summary>
/// The book as provided in user input.
/// </summary>
public class BookDTO
{
  public string name { get; init; }
  public int year { get; init; }
}