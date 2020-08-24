// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: calculator.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Calculator {
  public static partial class CalculatorService
  {
    static readonly string __ServiceName = "calculator.CalculatorService";

    static readonly grpc::Marshaller<global::Calculator.AddRequest> __Marshaller_calculator_AddRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.AddRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculator.AddResponse> __Marshaller_calculator_AddResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.AddResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculator.PrimeNoDecompRequest> __Marshaller_calculator_PrimeNoDecompRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.PrimeNoDecompRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculator.PrimeNoDecompResponse> __Marshaller_calculator_PrimeNoDecompResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.PrimeNoDecompResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculator.AverageRequest> __Marshaller_calculator_AverageRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.AverageRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculator.AverageResponse> __Marshaller_calculator_AverageResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.AverageResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculator.FindMaxRequest> __Marshaller_calculator_FindMaxRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.FindMaxRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculator.FindMaxResponse> __Marshaller_calculator_FindMaxResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.FindMaxResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculator.SqrtRequest> __Marshaller_calculator_SqrtRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.SqrtRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculator.SqrtResponse> __Marshaller_calculator_SqrtResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculator.SqrtResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Calculator.AddRequest, global::Calculator.AddResponse> __Method_Add = new grpc::Method<global::Calculator.AddRequest, global::Calculator.AddResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Add",
        __Marshaller_calculator_AddRequest,
        __Marshaller_calculator_AddResponse);

    static readonly grpc::Method<global::Calculator.PrimeNoDecompRequest, global::Calculator.PrimeNoDecompResponse> __Method_PrimeNoDecomp = new grpc::Method<global::Calculator.PrimeNoDecompRequest, global::Calculator.PrimeNoDecompResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "PrimeNoDecomp",
        __Marshaller_calculator_PrimeNoDecompRequest,
        __Marshaller_calculator_PrimeNoDecompResponse);

    static readonly grpc::Method<global::Calculator.AverageRequest, global::Calculator.AverageResponse> __Method_ComputeAverage = new grpc::Method<global::Calculator.AverageRequest, global::Calculator.AverageResponse>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "ComputeAverage",
        __Marshaller_calculator_AverageRequest,
        __Marshaller_calculator_AverageResponse);

    static readonly grpc::Method<global::Calculator.FindMaxRequest, global::Calculator.FindMaxResponse> __Method_FindMaximum = new grpc::Method<global::Calculator.FindMaxRequest, global::Calculator.FindMaxResponse>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "FindMaximum",
        __Marshaller_calculator_FindMaxRequest,
        __Marshaller_calculator_FindMaxResponse);

    static readonly grpc::Method<global::Calculator.SqrtRequest, global::Calculator.SqrtResponse> __Method_Sqrt = new grpc::Method<global::Calculator.SqrtRequest, global::Calculator.SqrtResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Sqrt",
        __Marshaller_calculator_SqrtRequest,
        __Marshaller_calculator_SqrtResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Calculator.CalculatorReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CalculatorService</summary>
    [grpc::BindServiceMethod(typeof(CalculatorService), "BindService")]
    public abstract partial class CalculatorServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Calculator.AddResponse> Add(global::Calculator.AddRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task PrimeNoDecomp(global::Calculator.PrimeNoDecompRequest request, grpc::IServerStreamWriter<global::Calculator.PrimeNoDecompResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Calculator.AverageResponse> ComputeAverage(grpc::IAsyncStreamReader<global::Calculator.AverageRequest> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task FindMaximum(grpc::IAsyncStreamReader<global::Calculator.FindMaxRequest> requestStream, grpc::IServerStreamWriter<global::Calculator.FindMaxResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Calculator.SqrtResponse> Sqrt(global::Calculator.SqrtRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for CalculatorService</summary>
    public partial class CalculatorServiceClient : grpc::ClientBase<CalculatorServiceClient>
    {
      /// <summary>Creates a new client for CalculatorService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public CalculatorServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CalculatorService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public CalculatorServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected CalculatorServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected CalculatorServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Calculator.AddResponse Add(global::Calculator.AddRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Add(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Calculator.AddResponse Add(global::Calculator.AddRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Add, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Calculator.AddResponse> AddAsync(global::Calculator.AddRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Calculator.AddResponse> AddAsync(global::Calculator.AddRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Add, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::Calculator.PrimeNoDecompResponse> PrimeNoDecomp(global::Calculator.PrimeNoDecompRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PrimeNoDecomp(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Calculator.PrimeNoDecompResponse> PrimeNoDecomp(global::Calculator.PrimeNoDecompRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_PrimeNoDecomp, null, options, request);
      }
      public virtual grpc::AsyncClientStreamingCall<global::Calculator.AverageRequest, global::Calculator.AverageResponse> ComputeAverage(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ComputeAverage(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncClientStreamingCall<global::Calculator.AverageRequest, global::Calculator.AverageResponse> ComputeAverage(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_ComputeAverage, null, options);
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::Calculator.FindMaxRequest, global::Calculator.FindMaxResponse> FindMaximum(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FindMaximum(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::Calculator.FindMaxRequest, global::Calculator.FindMaxResponse> FindMaximum(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_FindMaximum, null, options);
      }
      public virtual global::Calculator.SqrtResponse Sqrt(global::Calculator.SqrtRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Sqrt(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Calculator.SqrtResponse Sqrt(global::Calculator.SqrtRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Sqrt, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Calculator.SqrtResponse> SqrtAsync(global::Calculator.SqrtRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SqrtAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Calculator.SqrtResponse> SqrtAsync(global::Calculator.SqrtRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Sqrt, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override CalculatorServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CalculatorServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(CalculatorServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Add, serviceImpl.Add)
          .AddMethod(__Method_PrimeNoDecomp, serviceImpl.PrimeNoDecomp)
          .AddMethod(__Method_ComputeAverage, serviceImpl.ComputeAverage)
          .AddMethod(__Method_FindMaximum, serviceImpl.FindMaximum)
          .AddMethod(__Method_Sqrt, serviceImpl.Sqrt).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CalculatorServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Add, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Calculator.AddRequest, global::Calculator.AddResponse>(serviceImpl.Add));
      serviceBinder.AddMethod(__Method_PrimeNoDecomp, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Calculator.PrimeNoDecompRequest, global::Calculator.PrimeNoDecompResponse>(serviceImpl.PrimeNoDecomp));
      serviceBinder.AddMethod(__Method_ComputeAverage, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::Calculator.AverageRequest, global::Calculator.AverageResponse>(serviceImpl.ComputeAverage));
      serviceBinder.AddMethod(__Method_FindMaximum, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::Calculator.FindMaxRequest, global::Calculator.FindMaxResponse>(serviceImpl.FindMaximum));
      serviceBinder.AddMethod(__Method_Sqrt, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Calculator.SqrtRequest, global::Calculator.SqrtResponse>(serviceImpl.Sqrt));
    }

  }
}
#endregion
