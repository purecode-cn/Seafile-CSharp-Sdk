using SeafileClient.Common.Attributes;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SeafileClient
{
    public interface IStarItemApi
    {
        /// <summary>
        /// List Starred Items
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/starred-items.md#user-content-List%20Starred%20Items">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        IEnumerable<StarredItem> ListStarredItems(string accessToken);
        /// <summary>
        /// Star a Library/Folder/File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/starred-items.md#user-content-Star%20a%20Library/Folder/File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        StarredItem StarItem(string accessToken, string repoId, string path);
        /// <summary>
        /// Unstar a Library/Folder/File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/starred-items.md#user-content-Unstar%20a%20Library/Folder/File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        bool RemoveStar(string accessToken, string repoId, string path);
    }
    public partial class Api
    {
        [Get("/api/v2.1/starred-items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("starred_item_list")]
        public IEnumerable<StarredItem> ListStarredItems(
            [ForHeader]
            string accessToken
        ) => throw forbidCallingDirectly;
        [Post("/api/v2.1/starred-items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public StarredItem StarItem(
            [ForHeader]
            string accessToken, 
            [ForParameter("repo_id")]
            string repoId, 
            [ForParameter]
            string path
        ) => throw forbidCallingDirectly;
        [Delete("/api/v2.1/starred-items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool RemoveStar(
            [ForHeader]
            string accessToken, 
            [ForQueryString("repo_id")]
            string repoId, 
            [ForQueryString]
            string path
        ) => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{
    public class StarredItem
    {
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("mtime")]
        public string ModifiedTime { get; set; }
        [JsonPropertyName("obj_name")]
        public string ObjName { get; set; }
        [JsonPropertyName("path")]
        public string Path { get; set; }
        [JsonPropertyName("is_dir")]
        public bool IsDir { get; set; }
        [JsonPropertyName("user_email")]
        public string UserEmail { get; set; }
        [JsonPropertyName("user_contact_email")]
        public string UserContactEmail { get; set; }
        [JsonPropertyName("repo_name")]
        public string RepoName { get; set; }
        [JsonPropertyName("repo_encrypted")]
        public bool IsEncryptedRepo { get; set; }
    }
}
