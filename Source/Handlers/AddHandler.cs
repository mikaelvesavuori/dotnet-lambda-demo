namespace DotnetLambdaDemo;

using DotnetLambdaDemo.UseCases;

using System.Text.Json;
using System.Text.Json.Serialization;
using Amazon.Lambda.APIGatewayEvents;

/// <summary>
/// Lambda handler for adding books.
/// </summary>
public class AddHandler
{
  public async Task<APIGatewayHttpApiV2ProxyResponse> Add(APIGatewayHttpApiV2ProxyRequest request)
  {
    BookDTO bookDTO = GetBookDTO(request);

    var name = bookDTO.name ?? null;
    var year = bookDTO.year;

    if (name != null && year > 0)
    {
      var book = new Book(name, year);
      var result = await AddBookUseCase.Execute(book);

      return new APIGatewayHttpApiV2ProxyResponse
      {
        Body = $"Added '{name}' from the year '{year}'!",
        StatusCode = 200
      };
    }

    return new APIGatewayHttpApiV2ProxyResponse
    {
      Body = "Invalid input. Please add 'name' and 'year' fields.",
      StatusCode = 400
    };
  }

  private BookDTO GetBookDTO(APIGatewayHttpApiV2ProxyRequest request)
  {
    var serializationOptions = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true,
      NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    return JsonSerializer.Deserialize<BookDTO>(request.Body, serializationOptions);
  }
}