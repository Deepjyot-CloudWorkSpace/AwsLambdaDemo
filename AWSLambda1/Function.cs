using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambda1;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<User> FunctionHandler(User  input, ILambdaContext context)
    {
        var dynamoDbContext = new DynamoDBContext(new AmazonDynamoDBClient());

        await dynamoDbContext.SaveAsync<User>(input);

        return input;
    }


    public class User {

        [DynamoDBProperty]
        public string Name { get; set; }

        [DynamoDBHashKey]
        public Guid Id { get; set; }

    }

}
