namespace DotnetLambdaDemo;

using DotnetLambdaDemo.UseCases;

using System.Text.Json;
using System.Text.Json.Serialization;
using Amazon.Lambda.APIGatewayEvents;

/// <summary>
/// Lambda handler for getting books.
/// </summary>
public class GetHandler
{
  public async Task<APIGatewayHttpApiV2ProxyResponse> Get(APIGatewayHttpApiV2ProxyRequest request)
  {
    string name = GetName(request);

    if (name != null)
    {
      var result = await GetBookUseCase.Execute(name);

      return new APIGatewayHttpApiV2ProxyResponse
      {
        Body = result,
        StatusCode = 200
      };
    }

    return new APIGatewayHttpApiV2ProxyResponse
    {
      Body = "Invalid input. Please add 'name' field.",
      StatusCode = 400
    };
  }

  private string GetName(APIGatewayHttpApiV2ProxyRequest request)
  {
    var serializationOptions = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true,
      NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    var dto = JsonSerializer.Deserialize<BookDTO>(request.Body, serializationOptions);

    return dto.name ?? null;
  }
}