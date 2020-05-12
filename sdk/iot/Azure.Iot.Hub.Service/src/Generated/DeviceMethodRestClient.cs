// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service
{
    internal partial class DeviceMethodRestClient
    {
        private string host;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of DeviceMethodRestClient. </summary>
        public DeviceMethodRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "https://fully-qualified-iothubname.azure-devices.net", string apiVersion = "2020-03-13")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            this.host = host;
            this.apiVersion = apiVersion;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateInvokeDeviceMethodRequest(string deviceId, CloudToDeviceMethod directMethodRequest)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/twins/", false);
            uri.AppendPath(deviceId, true);
            uri.AppendPath("/methods", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(directMethodRequest);
            request.Content = content;
            return message;
        }

        /// <summary> Invoke a direct method on a device. See https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-direct-methods for more information. </summary>
        /// <param name="deviceId"> The String to use. </param>
        /// <param name="directMethodRequest"> The CloudToDeviceMethod to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<CloudToDeviceMethodResult>> InvokeDeviceMethodAsync(string deviceId, CloudToDeviceMethod directMethodRequest, CancellationToken cancellationToken = default)
        {
            if (deviceId == null)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }
            if (directMethodRequest == null)
            {
                throw new ArgumentNullException(nameof(directMethodRequest));
            }

            using var message = CreateInvokeDeviceMethodRequest(deviceId, directMethodRequest);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CloudToDeviceMethodResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = CloudToDeviceMethodResult.DeserializeCloudToDeviceMethodResult(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Invoke a direct method on a device. See https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-direct-methods for more information. </summary>
        /// <param name="deviceId"> The String to use. </param>
        /// <param name="directMethodRequest"> The CloudToDeviceMethod to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<CloudToDeviceMethodResult> InvokeDeviceMethod(string deviceId, CloudToDeviceMethod directMethodRequest, CancellationToken cancellationToken = default)
        {
            if (deviceId == null)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }
            if (directMethodRequest == null)
            {
                throw new ArgumentNullException(nameof(directMethodRequest));
            }

            using var message = CreateInvokeDeviceMethodRequest(deviceId, directMethodRequest);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CloudToDeviceMethodResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = CloudToDeviceMethodResult.DeserializeCloudToDeviceMethodResult(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateInvokeModuleMethodRequest(string deviceId, string moduleId, CloudToDeviceMethod directMethodRequest)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/twins/", false);
            uri.AppendPath(deviceId, true);
            uri.AppendPath("/modules/", false);
            uri.AppendPath(moduleId, true);
            uri.AppendPath("/methods", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(directMethodRequest);
            request.Content = content;
            return message;
        }

        /// <summary> Invoke a direct method on a module of a device. See https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-direct-methods for more information. </summary>
        /// <param name="deviceId"> The String to use. </param>
        /// <param name="moduleId"> The String to use. </param>
        /// <param name="directMethodRequest"> The CloudToDeviceMethod to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<CloudToDeviceMethodResult>> InvokeModuleMethodAsync(string deviceId, string moduleId, CloudToDeviceMethod directMethodRequest, CancellationToken cancellationToken = default)
        {
            if (deviceId == null)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }
            if (moduleId == null)
            {
                throw new ArgumentNullException(nameof(moduleId));
            }
            if (directMethodRequest == null)
            {
                throw new ArgumentNullException(nameof(directMethodRequest));
            }

            using var message = CreateInvokeModuleMethodRequest(deviceId, moduleId, directMethodRequest);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CloudToDeviceMethodResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = CloudToDeviceMethodResult.DeserializeCloudToDeviceMethodResult(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Invoke a direct method on a module of a device. See https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-direct-methods for more information. </summary>
        /// <param name="deviceId"> The String to use. </param>
        /// <param name="moduleId"> The String to use. </param>
        /// <param name="directMethodRequest"> The CloudToDeviceMethod to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<CloudToDeviceMethodResult> InvokeModuleMethod(string deviceId, string moduleId, CloudToDeviceMethod directMethodRequest, CancellationToken cancellationToken = default)
        {
            if (deviceId == null)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }
            if (moduleId == null)
            {
                throw new ArgumentNullException(nameof(moduleId));
            }
            if (directMethodRequest == null)
            {
                throw new ArgumentNullException(nameof(directMethodRequest));
            }

            using var message = CreateInvokeModuleMethodRequest(deviceId, moduleId, directMethodRequest);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CloudToDeviceMethodResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = CloudToDeviceMethodResult.DeserializeCloudToDeviceMethodResult(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
