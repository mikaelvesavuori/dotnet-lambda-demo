namespace DotnetLambdaDemo.UseCases;

using DotnetLambdaDemo.Repositories;

/// <summary>
/// This orchestrates anything to do with getting books.
/// </summary>
public class GetBookUseCase
{
  static public async Task<string> Execute(string bookName)
  {
    var repository = new BookRepository();
    return await repository.Get(bookName);
  }
}
