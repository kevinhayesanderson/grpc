using Blog;
using Calculator;
using Greet;
using Grpc.Core;
using Grpc.Reflection;
using Grpc.Reflection.V1Alpha;
using System;
using System.Collections.Generic;
using System.IO;

namespace server
{
    class Program
    {
        const int port = 50052;
        static void Main(string[] args)
        {
            Server server = null;
            try
            {
                var serverCertificate = File.ReadAllText("ssl/server.crt");
                var serverKey = File.ReadAllText("ssl/server.key");
                var keyCertificatePair = new KeyCertificatePair(serverCertificate, serverKey);
                var caCertificate = File.ReadAllText("ssl/ca.crt");

                var credentials = new SslServerCredentials(new List<KeyCertificatePair>() { keyCertificatePair }, caCertificate, true);

                // ./evans.exe -r -p 50051
                var greetingServiceReflectionServiceImpl = new ReflectionServiceImpl(GreetingService.Descriptor, ServerReflection.Descriptor);
                var calculatorServiceReflectionServiceImpl = new ReflectionServiceImpl(CalculatorService.Descriptor, ServerReflection.Descriptor);
                var blogServiceReflectionServiceImpl = new ReflectionServiceImpl(BlogService.Descriptor, ServerReflection.Descriptor);

                server = new Server()
                {
                    Services =
                    {
                        BlogService.BindService(new BlogServiceImpl()),
                        ServerReflection.BindService(blogServiceReflectionServiceImpl),
                        GreetingService.BindService(new GreetingServiceImpl()),
                        //ServerReflection.BindService(greetingServiceReflectionServiceImpl),
                        CalculatorService.BindService(new CalculatorServiceImpl()),
                        //ServerReflection.BindService(calculatorServiceReflectionServiceImpl)
                    },
                    Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine("The server is listening on the port :" + port);
                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine("The server failed to start:" + e.Message);
                throw;
            }
            finally
            {
                if (server != null)
                {
                    server.ShutdownAsync().Wait();
                }
            }
        }
    }
}
