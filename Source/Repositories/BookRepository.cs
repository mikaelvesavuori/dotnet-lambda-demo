namespace DotnetLambdaDemo.Repositories;

using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

using Amazon.Lambda.Core;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

/// <summary>
/// Book repository, running on DynamoDB.
///
/// See https://docs.aws.amazon.com/sdk-for-net/v3/developer-guide/csharp_dynamodb_code_examples.html
/// </summary>
public class BookRepository
{
  internal string tableName = "BookDemo";
  internal static AmazonDynamoDBClient client = new AmazonDynamoDBClient();

  public async Task<bool> Add(Book book)
  {
    var item = new Dictionary<string, AttributeValue>
    {
      ["book"] = new AttributeValue { S = book.Name },
      ["year"] = new AttributeValue { N = book.Year.ToString() },
    };

    var command = new PutItemRequest
    {
      Item = item,
      TableName = tableName
    };

    var response = await client.PutItemAsync(command);
    return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
  }

  public async Task<string> Get(string bookName)
  {
    var item = new Dictionary<string, AttributeValue>
    {
      ["book"] = new AttributeValue { S = bookName }
    };

    var command = new GetItemRequest
    {
      Key = item,
      TableName = tableName
    };

    var response = await client.GetItemAsync(command);

    var name = ((response.Item.TryGetValue("book", out AttributeValue bookAttr) && bookAttr.S != null)) ? bookAttr.S : null;
    var year = ((response.Item.TryGetValue("year", out AttributeValue yearAttr) && yearAttr.N != null)) ? yearAttr.N : null;

    if (name != null && year != null) return $"'{name}' from the year {year}";
    else return "Unknown book...";
  }
}