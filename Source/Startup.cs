[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace DotnetLambdaDemo;

/// <summary>
/// Runs on startup. In this case, it only adds the serializer.
/// </summary>
public class Startup
{
}