using Blog;
using Calculator;
using Dummy;
using Greet;
using Grpc.Core;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        //const string target = "127.0.0.1:50052";

        static async Task Main(string[] args)
        {
            var clientCertificate = File.ReadAllText("ssl/client.crt");
            var clientKey = File.ReadAllText("ssl/client.key");
            var caCertificate = File.ReadAllText("ssl/ca.crt");

            var channelCredentials = new SslCredentials(caCertificate, new KeyCertificatePair(clientCertificate, clientKey));

            //Channel channel = new Channel(target, channelCredentials);
            Channel channel = new Channel("localhost", 50052, ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("The client connected successfully");
                }
            });

            var dummyClient = new DummyService.DummyServiceClient(channel);

            var greetingClient = new GreetingService.GreetingServiceClient(channel);
            Greet(greetingClient);
            //await GreetMany(greetingClient);
            //await LongGreet(greetingClient);
            //await GreetEveryOne(greetingClient);
            //GreetWithDeadline(greetingClient);

            var calculatorClient = new CalculatorService.CalculatorServiceClient(channel);
            //Add(calculatorClient);
            //await PrimeNoDecomp(calculatorClient);
            //await ComputeAverage(calculatorClient);
            //await FindMaximum(calculatorClient);
            //Sqrt(calculatorClient);

            var blogClient = new BlogService.BlogServiceClient(channel);
            //var newBlog = CreateBlog(blogClient);
            //ReadBlog(blogClient);
            //UpdateBlog(blogClient, newBlog);
            //DeleteBlog(blogClient, newBlog);
            await ListBlog(blogClient);

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }

        private static void GreetWithDeadline(GreetingService.GreetingServiceClient greetingClient)
        {
            var greeting = new Greeting()
            {
                FirstName = "Kevin Hayes",
                LastName = "Anderson"
            };
            try
            {
                var response = greetingClient.GreetWithDeadline(
                    new GreetDeadlineRequest() { Greeting = greeting },
                    deadline: DateTime.UtcNow.AddMilliseconds(500));
                Console.WriteLine(response.Result);
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
            {
                Console.WriteLine($"Error: {ex.Status.Detail}");
                Console.WriteLine($"Error Status: {ex.Status.StatusCode}, Error Status Code: {(int)ex.Status.StatusCode}");
            }
        }

        private static void Sqrt(CalculatorService.CalculatorServiceClient calculatorClient)
        {
            try
            {
                var response = calculatorClient.Sqrt(new SqrtRequest() { Square = 16 });
                Console.WriteLine(response.SquareRoot);
            }
            catch (RpcException ex)
            {

                Console.WriteLine($"Error: {ex.Status.Detail}");
                Console.WriteLine($"Error Status: {ex.Status.StatusCode}, Error Status Code: {(int)ex.Status.StatusCode}");
                if (ex.Status.StatusCode == StatusCode.InvalidArgument) { }
            }
        }

        private static async Task FindMaximum(CalculatorService.CalculatorServiceClient calculatorClient)
        {
            var findMaxStream = calculatorClient.FindMaximum();
            var findMaxResponseReader = Task.Run(async () =>
            {
                while (await findMaxStream.ResponseStream.MoveNext())
                {
                    Console.WriteLine(findMaxStream.ResponseStream.Current.Max);
                }
            });
            int[] inputNumbers = { 1, 5, 3, 6, 2, 20 };
            foreach (var inputNumber in inputNumbers)
            {
                await findMaxStream.RequestStream.WriteAsync(new FindMaxRequest() { InputNumber = inputNumber });
            }
            await findMaxStream.RequestStream.CompleteAsync();
            await findMaxResponseReader;
        }

        private static async Task ComputeAverage(CalculatorService.CalculatorServiceClient calculatorClient)
        {
            var averageStream = calculatorClient.ComputeAverage();
            foreach (var no in Enumerable.Range(1, 4))
            {
                await averageStream.RequestStream.WriteAsync(new AverageRequest() { Input = no });
            }
            await averageStream.RequestStream.CompleteAsync();
            var averageResponse = await averageStream.ResponseAsync;
            Console.WriteLine(averageResponse.Average);
        }

        private static async Task PrimeNoDecomp(CalculatorService.CalculatorServiceClient calculatorClient)
        {
            var primeNoDecompRequest = new PrimeNoDecompRequest() { Number = 120 };
            var PrimeNoDecompResponse = calculatorClient.PrimeNoDecomp(primeNoDecompRequest);
            while (await PrimeNoDecompResponse.ResponseStream.MoveNext())
            {
                Console.WriteLine(PrimeNoDecompResponse.ResponseStream.Current.Factor);
                await Task.Delay(200);
            }
        }

        private static void Add(CalculatorService.CalculatorServiceClient calculatorClient)
        {
            var addRequest = new AddRequest() { A = 32, B = 23 };
            var addResponse = calculatorClient.Add(addRequest);
            Console.WriteLine(addResponse.Result);
        }

        private static async Task GreetEveryOne(GreetingService.GreetingServiceClient greetingClient)
        {
            var greetEveryOneStream = greetingClient.GreetEveryOne();
            var greetEveryOneResponseReader = Task.Run(async () =>
            {
                while (await greetEveryOneStream.ResponseStream.MoveNext())
                {
                    Console.WriteLine(greetEveryOneStream.ResponseStream.Current.Result);
                }
            });
            Greeting[] greetings =
            {
                new Greeting(){FirstName="Kevin Hayes", LastName ="Anderson"},
                new Greeting(){FirstName="John", LastName ="Doe"},
                new Greeting(){FirstName="Ford", LastName ="Henry"},
                new Greeting(){FirstName="Bob", LastName ="Miller"},
                new Greeting(){FirstName="Clive", LastName ="Gerald"},
            };
            foreach (var greeting in greetings)
            {
                await greetEveryOneStream.RequestStream.WriteAsync(new GreetEveryOneRequest() { Greeting = greeting });
            }
            await greetEveryOneStream.RequestStream.CompleteAsync();
            await greetEveryOneResponseReader;
        }

        private static async Task LongGreet(GreetingService.GreetingServiceClient greetingClient)
        {
            var greeting = new Greeting()
            {
                FirstName = "Kevin Hayes",
                LastName = "Anderson"
            };
            var longGreetRequest = new LongGreetRequest() { Greeting = greeting };
            var longStream = greetingClient.LongGreet();
            foreach (var i in Enumerable.Range(1, 10))
            {
                await longStream.RequestStream.WriteAsync(longGreetRequest);
            }
            await longStream.RequestStream.CompleteAsync();
            var longGreetResponse = await longStream.ResponseAsync;
            Console.WriteLine(longGreetResponse.Result);
        }

        private static async Task GreetMany(GreetingService.GreetingServiceClient greetingClient)
        {
            var greeting = new Greeting()
            {
                FirstName = "Kevin Hayes",
                LastName = "Anderson"
            };
            var greetManyRequest = new GreetManyRequest() { Greeting = greeting };
            var greetmanyResponse = greetingClient.GreetMany(greetManyRequest);
            while (await greetmanyResponse.ResponseStream.MoveNext())
            {
                Console.WriteLine(greetmanyResponse.ResponseStream.Current.Result);
                await Task.Delay(200);
            }
        }

        private static void Greet(GreetingService.GreetingServiceClient greetingClient)
        {
            var greeting = new Greeting()
            {
                FirstName = "Kevin Hayes",
                LastName = "Anderson"
            };
            var greetRequest = new GreetingRequest() { Greeting = greeting };
            var greetResponse = greetingClient.Greet(greetRequest);
            Console.WriteLine(greetResponse.Result);
        }

        private static async Task ListBlog(BlogService.BlogServiceClient client)
        {
            var response = client.ListBlog(new ListBlogRequest() { });
            while (await response.ResponseStream.MoveNext())
            {
                Console.WriteLine(response.ResponseStream.Current.Blog.ToString());
            }
        }

        private static void DeleteBlog(BlogService.BlogServiceClient client, Blog.Blog blog)
        {
            try
            {
                var response = client.DeleteBlog(new DeleteBlogRequest() { BlogId = blog.Id });
                Console.WriteLine($"The blog with id {blog.Id} was deleted !");
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Status.Detail);
            }
        }

        private static void UpdateBlog(BlogService.BlogServiceClient client, Blog.Blog blog)
        {
            try
            {
                blog.AuthorId = "updated author";
                blog.Title = "updated title";
                blog.Content = "updated content";
                var response = client.UpdateBlog(new UpdateBlogRequest()
                {
                    Blog = blog
                });
                Console.WriteLine(response.Blog.ToString());
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Status.Detail);
            }
        }

        private static void ReadBlog(BlogService.BlogServiceClient client)
        {
            try
            {
                var response = client.ReadBlog(new ReadBlogRequest() { BlogId = "5f43d20c3f7f04ca26460d27" });
                Console.WriteLine(response.Blog.ToString());
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                Console.WriteLine(ex.Status.Detail);
            }
        }

        private static Blog.Blog CreateBlog(BlogService.BlogServiceClient client)
        {
            var response = client.CreateBlog(new CreateBlogRequest()
            {
                Blog = new Blog.Blog
                {
                    AuthorId = "Kevin",
                    Title = "New Blog!",
                    Content = "Hello World, this is a new blog!!"
                }
            });
            Console.WriteLine($"The Blog with id {response.Blog.Id} was created !");
            return response.Blog;
        }
    }
}
