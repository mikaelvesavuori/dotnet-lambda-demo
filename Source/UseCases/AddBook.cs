namespace DotnetLambdaDemo.UseCases;

using DotnetLambdaDemo.Repositories;

/// <summary>
/// This orchestrates anything to do with adding books.
/// </summary>
public class AddBookUseCase
{
  static public async Task<bool> Execute(Book book)
  {
    var repository = new BookRepository();
    return await repository.Add(book);
  }
}
