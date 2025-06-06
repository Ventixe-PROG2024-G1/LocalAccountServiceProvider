// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/accountprofile.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace LocalAccountServiceProvider.Services {
  public static partial class ProfileContract
  {
    static readonly string __ServiceName = "ProfileContract";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LocalAccountServiceProvider.Services.CreateProfileRequest> __Marshaller_CreateProfileRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LocalAccountServiceProvider.Services.CreateProfileRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LocalAccountServiceProvider.Services.ActionResponse> __Marshaller_ActionResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LocalAccountServiceProvider.Services.ActionResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LocalAccountServiceProvider.Services.GetProfileRequest> __Marshaller_GetProfileRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LocalAccountServiceProvider.Services.GetProfileRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LocalAccountServiceProvider.Services.ProfileResponse> __Marshaller_ProfileResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LocalAccountServiceProvider.Services.ProfileResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LocalAccountServiceProvider.Services.GetAllProfilesRequest> __Marshaller_GetAllProfilesRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LocalAccountServiceProvider.Services.GetAllProfilesRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LocalAccountServiceProvider.Services.AllProfilesResponse> __Marshaller_AllProfilesResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LocalAccountServiceProvider.Services.AllProfilesResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::LocalAccountServiceProvider.Services.CreateProfileRequest, global::LocalAccountServiceProvider.Services.ActionResponse> __Method_CreateProfile = new grpc::Method<global::LocalAccountServiceProvider.Services.CreateProfileRequest, global::LocalAccountServiceProvider.Services.ActionResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateProfile",
        __Marshaller_CreateProfileRequest,
        __Marshaller_ActionResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::LocalAccountServiceProvider.Services.GetProfileRequest, global::LocalAccountServiceProvider.Services.ProfileResponse> __Method_GetProfile = new grpc::Method<global::LocalAccountServiceProvider.Services.GetProfileRequest, global::LocalAccountServiceProvider.Services.ProfileResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetProfile",
        __Marshaller_GetProfileRequest,
        __Marshaller_ProfileResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::LocalAccountServiceProvider.Services.GetAllProfilesRequest, global::LocalAccountServiceProvider.Services.AllProfilesResponse> __Method_GetAllProfiles = new grpc::Method<global::LocalAccountServiceProvider.Services.GetAllProfilesRequest, global::LocalAccountServiceProvider.Services.AllProfilesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllProfiles",
        __Marshaller_GetAllProfilesRequest,
        __Marshaller_AllProfilesResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::LocalAccountServiceProvider.Services.AccountprofileReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ProfileContract</summary>
    public partial class ProfileContractClient : grpc::ClientBase<ProfileContractClient>
    {
      /// <summary>Creates a new client for ProfileContract</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ProfileContractClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ProfileContract that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ProfileContractClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ProfileContractClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ProfileContractClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::LocalAccountServiceProvider.Services.ActionResponse CreateProfile(global::LocalAccountServiceProvider.Services.CreateProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateProfile(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::LocalAccountServiceProvider.Services.ActionResponse CreateProfile(global::LocalAccountServiceProvider.Services.CreateProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::LocalAccountServiceProvider.Services.ActionResponse> CreateProfileAsync(global::LocalAccountServiceProvider.Services.CreateProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateProfileAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::LocalAccountServiceProvider.Services.ActionResponse> CreateProfileAsync(global::LocalAccountServiceProvider.Services.CreateProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::LocalAccountServiceProvider.Services.ProfileResponse GetProfile(global::LocalAccountServiceProvider.Services.GetProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetProfile(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::LocalAccountServiceProvider.Services.ProfileResponse GetProfile(global::LocalAccountServiceProvider.Services.GetProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::LocalAccountServiceProvider.Services.ProfileResponse> GetProfileAsync(global::LocalAccountServiceProvider.Services.GetProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetProfileAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::LocalAccountServiceProvider.Services.ProfileResponse> GetProfileAsync(global::LocalAccountServiceProvider.Services.GetProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::LocalAccountServiceProvider.Services.AllProfilesResponse GetAllProfiles(global::LocalAccountServiceProvider.Services.GetAllProfilesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllProfiles(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::LocalAccountServiceProvider.Services.AllProfilesResponse GetAllProfiles(global::LocalAccountServiceProvider.Services.GetAllProfilesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllProfiles, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::LocalAccountServiceProvider.Services.AllProfilesResponse> GetAllProfilesAsync(global::LocalAccountServiceProvider.Services.GetAllProfilesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllProfilesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::LocalAccountServiceProvider.Services.AllProfilesResponse> GetAllProfilesAsync(global::LocalAccountServiceProvider.Services.GetAllProfilesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllProfiles, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ProfileContractClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ProfileContractClient(configuration);
      }
    }

  }
}
#endregion
