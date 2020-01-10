using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeafileClient.Common.Attributes;
using SeafileClient.Responses;

namespace SeafileClient
{
    public interface IServerApi
    {
        /// <summary>
        /// Ping server
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/home.md#user-content-Quick%20Start">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <returns></returns>
        string Ping();

        /// <summary>
        /// Get server information
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/server-info.md#user-content-Get%20Server%20Information">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <returns></returns>
        ServerInfo GetServerInfo();
    }

    public partial class Api
    {
        [Get("/api2/ping")]
        public string Ping() => throw forbidCallingDirectly;
        [Get("/api2/server-info")]
        public ServerInfo GetServerInfo() => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{
    public class ServerInfo
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("encrypted_library_version")]
        public int EncryptedLibraryVersion { get; set; }
        [JsonPropertyName("features")]
        public IEnumerable<string> Features { get; set; }
    }
}
