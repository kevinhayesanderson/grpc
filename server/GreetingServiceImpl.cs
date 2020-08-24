using Greet;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Greet.GreetingService;

namespace server
{
    public class GreetingServiceImpl : GreetingServiceBase
    {
        public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
        {
            string result = $"hello {request.Greeting.FirstName} {request.Greeting.LastName}";
            return Task.FromResult(new GreetingResponse() { Result = result });
        }

        public override async Task GreetMany(GreetManyRequest request, IServerStreamWriter<GreetManyResponse> responseStream, ServerCallContext context)
        {
            string result = $"hello {request.Greeting.FirstName} {request.Greeting.LastName}";
            foreach (int _ in Enumerable.Range(1, 10))
            {
                await responseStream.WriteAsync(new GreetManyResponse() { Result = result });
            }
        }

        public override async Task<LongGreetResponse> LongGreet(IAsyncStreamReader<LongGreetRequest> requestStream, ServerCallContext context)
        {
            var result = "";
            while (await requestStream.MoveNext())
            {
                result += $"hello {requestStream.Current.Greeting.FirstName} {requestStream.Current.Greeting.LastName} {Environment.NewLine}";
            }
            return new LongGreetResponse() { Result = result };
        }

        public override async Task GreetEveryOne(IAsyncStreamReader<GreetEveryOneRequest> requestStream, IServerStreamWriter<GreetEveryOneResponse> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                await responseStream.WriteAsync(new GreetEveryOneResponse()
                {
                    Result = $"hello {requestStream.Current.Greeting.FirstName} {requestStream.Current.Greeting.LastName}"
                });
            }
        }

        public override async Task<GreetDeadlineResponse> GreetWithDeadline(GreetDeadlineRequest request, ServerCallContext context)
        {
            await Task.Delay(300);
            return new GreetDeadlineResponse() { Result = $"hello {request.Greeting.FirstName} {request.Greeting.LastName}" };
        }
    }
}
