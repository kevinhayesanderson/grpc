using Calculator;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using static Calculator.CalculatorService;

namespace server
{
    public class CalculatorServiceImpl : CalculatorServiceBase
    {
        public override Task<AddResponse> Add(AddRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AddResponse() { Result = (request.A + request.B) });
        }

        public override async Task PrimeNoDecomp(PrimeNoDecompRequest request, IServerStreamWriter<PrimeNoDecompResponse> responseStream, ServerCallContext context)
        {
            int k = 2;
            int N = request.Number;
            while (N > 1)
            {
                if (N % k == 0) // if k evenly divides into N 
                {
                    await responseStream.WriteAsync(new PrimeNoDecompResponse() { Factor = k });    // this is a factor
                    N /= k; // divide N by k so that we have the rest of the number left.
                }
                else
                    k += 1;
            }
        }

        public override async Task<AverageResponse> ComputeAverage(IAsyncStreamReader<AverageRequest> requestStream, ServerCallContext context)
        {
            int N = default;
            double sum = default;
            while (await requestStream.MoveNext())
            {
                sum += requestStream.Current.Input;
                N++;
            }
            return new AverageResponse() { Average = sum / N };
        }

        public override async Task FindMaximum(IAsyncStreamReader<FindMaxRequest> requestStream, IServerStreamWriter<FindMaxResponse> responseStream, ServerCallContext context)
        {
            int max = default;
            while (await requestStream.MoveNext())
            {
                if (requestStream.Current.InputNumber > max)
                {
                    max = requestStream.Current.InputNumber;
                    await responseStream.WriteAsync(new FindMaxResponse()
                    {
                        Max = max
                    });
                }
            }
        }

        public override async Task<SqrtResponse> Sqrt(SqrtRequest request, ServerCallContext context)
        {
            int square = request.Square;
            if(square >= 0)
            {
                return new SqrtResponse() { SquareRoot = Math.Sqrt(square) };
            }
            else
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "number(square) < 0"));
            }
        }
    }
}
