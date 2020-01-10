using SeafileClient.Common.Attributes;
using SeafileClient.Common.Converters;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SeafileClient
{
    public interface IDeviceApi
    {
        /// <summary>
        /// List the logined devices
        /// <para>
        /// <see cref="https://download.seafile.com/published/web-api/v2.1/devices.md#user-content-List%20Devices">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        IEnumerable<DeviceInfo> ListDevices(string accessToken);
        /// <summary>
        /// Remove one device
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/devices.md#user-content-Unlink%20Device">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="platform"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        bool UnlinkDevice(string accessToken, string platform, string deviceId);
    }

    public partial class Api
    {
        [Get("/api2/devices/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<DeviceInfo> ListDevices(
            [ForHeader]
            string accessToken
        ) => throw forbidCallingDirectly;

        [Delete("/api2/devices/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public bool UnlinkDevice(
            [ForHeader]
            string accessToken, 
            [ForParameter]
            string platform, 
            [ForParameter("device_id")]
            string deviceId
        ) => throw forbidCallingDirectly;
    }

}

namespace SeafileClient.Responses
{
    public class DeviceInfo { 
        [JsonPropertyName("synced_repos")]
        public IEnumerable<SyncedRepo> SyncedRepos { get; set; }
        [JsonPropertyName("last_accessed")]
        public DateTime LastAccessedTime { get; set; }
        [JsonPropertyName("device_name")]
        public string DeviceName { get; set; }
        [JsonPropertyName("platform_version")]
        public string PlatformVersion { get; set; }
        [JsonPropertyName("platform")]
        public string Platform { get; set; }
        [JsonPropertyName("user")]
        public string User { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("client_version")]
        public string ClientVersion { get; set; }
        [JsonPropertyName("last_login_ip")]
        public string LastLoginIp { get; set; }
        [JsonPropertyName("device_id")]
        public string DeviceId { get; set; }
    }
    public class SyncedRepo
    {
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("sync_time")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime SyncTime { get; set; }
        [JsonPropertyName("repo_name")]
        public string RepoName { get; set; }
    }
}
