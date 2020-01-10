using SeafileClient.Common.Attributes;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SeafileClient
{
    public interface ISharedLinkApi
    {
        /// <summary>
        /// List all Share Links
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share-links.md#user-content-List%20all%20Share%20Links">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        IEnumerable<SharedLink> ListSharedLinks(string accessToken, string repoId = null, string path = null);
        /// <summary>
        /// Create Share Link
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share-links.md#user-content-Create%20Share%20Link">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="password"></param>
        /// <param name="expireDays"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        SharedLink CreateSharedLink(string accessToken, string repoId, string path, string password = null, int expireDays = 0, SharedLinkPermissions permissions = null);
        /// <summary>
        /// Delete Share Link
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share-links.md#user-content-Delete%20Share%20Link">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="linkToken"></param>
        /// <returns></returns>
        bool DeleteSharedLink(string accessToken, string linkToken);
    }

    public partial class Api
    {
        [Get("/api/v2.1/share-links/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<SharedLink> ListSharedLinks(
            [ForHeader]
            string accessToken,
            [ForQueryString("repo_id")]
            string repoId = null,
            [ForQueryString("path")]
            string path = null
        ) => throw forbidCallingDirectly;

        [Post("/api/v2.1/share-links/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public SharedLink CreateSharedLink(
            [ForHeader]
            string accessToken,
            [ForParameter("repo_id")]
            string repoId,
            [ForParameter("path")]
            string path, 
            [ForParameter("password")]
            string password = null, 
            [ForParameter("expire_days")]
            int expireDays = 0,
            [ForParameter("permissions")]
            SharedLinkPermissions permissions = null
        ) => throw forbidCallingDirectly;


        [Delete("/api/v2.1/share-links/{linkToken}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public bool DeleteSharedLink(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string linkToken
        ) => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{
    public class SharedLink
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("ctime")]
        public DateTime CreatedTime { get; set; }
        [JsonPropertyName("expire_date")]
        public DateTime? ExpireDate { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("view_cnt")]
        public long ViewCount { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("obj_name")]
        public string ObjName { get; set; }
        [JsonPropertyName("path")]
        public string Path { get; set; }
        [JsonPropertyName("is_dir")]
        public bool IsDir { get; set; }
        [JsonPropertyName("permissions")]
        public SharedLinkPermissions Permissions { get; set; }
        [JsonPropertyName("is_expired")]
        public bool IsExpired { get; set; }
        [JsonPropertyName("repo_name")]
        public string RepoName { get; set; }
    }
    public class SharedLinkPermissions
    {
        [JsonPropertyName("can_edit")]
        public bool? CanEdit { get; set; }
        [JsonPropertyName("can_download")]
        public bool? CanDownload { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, options: new JsonSerializerOptions { IgnoreNullValues = true });
        }
    }
}
