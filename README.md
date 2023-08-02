# Demo: C# (.NET) serverless on AWS

Small demo project on how one could set up serverless C# (.NET 6, ARM architecture) functions on AWS.

The infrastructure is simply an API Gateway with two functions behind it, for adding and getting books from DynamoDB.

It also contains:

- [Serverless Framework](https://www.serverless.com) to deploy your application
- VS Code configuration files to run tasks for building and testing
- A demo test using XUnit
- Also: [Amazon.Lambda.TestTool] support as a launch task, but there's something wonky going on with the JSON serializer...

**Note that this project has been created and run in a MacOS 13 environment and Windows compatibility is not guaranteed.**

## Prerequisites

This assumes you have a recent Node version (19+) and Dotnet stuff installed already.

See:

- [Node.js](https://nodejs.org/en)
- [.NET](https://dotnet.microsoft.com/en-us/download)
- [Amazon.Lambda.Tools](https://www.nuget.org/packages/Amazon.Lambda.Tools)
- [Amazon.Lambda.TestTool](https://www.nuget.org/packages/Amazon.Lambda.TestTool-6.0)

## Instructions

### Installation

Run `npm install` to install Node dependencies.

#### Note on Node usage

The only real usage for Node here is to keep the dependency on Serverless Framework explicit and localized. You might want to simply do a global install of it instead, if you prefer.

### Configuration

Set your own values in `serverless.yml` for `custom.awsAccountNumber`.

### Testing

Run `npm test` or the Bash script `scripts/test.sh`. You can also use the VS Code task.

### Building

Run `npm test` or the Bash script `scripts/test.sh`. You can also use the VS Code task (Mac shortcut: CMD + SHIFT + B).

### Deploying

Run `npm run deploy` or the Bash script `scripts/deploy.sh`. You can also use the VS Code task.

### Teardown (remove project)

Run `npm run teardown` or the Bash script `scripts/teardown.sh`.

## API calls

_Make sure to substitute `RANDOM` and `REGION` with your own values._

Add a book with:

```bash
curl https://RANDOM.execute-api.REGION.amazonaws.com/book -X POST -d '{"name":"The new book", "year": 2023}' -H 'Content-Type: application/json'
```

And get it with:

```bash
curl https://RANDOM.execute-api.REGION.amazonaws.com/book -d '{"name":"The new book"}' -H 'Content-Type: application/json'
```

## References

- [serverless-dotnet-demo](https://github.com/aws-samples/serverless-dotnet-demo)
- [The AWS .NET Mock Lambda Test Tool (Preview)](https://github.com/aws/aws-lambda-dotnet/tree/master/Tools/LambdaTestTool)
- [Lambda Function URLs - triggering .NET 6 Lambda functions with a HTTPS Request](https://nodogmablog.bryanhogan.net/2022/04/lambda-function-urls-triggering-net-6-lambda-functions-with-a-https-request/)