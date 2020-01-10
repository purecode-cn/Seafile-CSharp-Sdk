using SeafileClient.Common.Attributes;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SeafileClient
{

    public interface IFileHistoryApi
    {
        /// <summary>
        /// Get File History
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-history.md#user-content-Get%20File%20History">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="startCommitId"></param>
        /// <returns></returns>
        PagedHistory GetFileHistory(string accessToken, string repoId, string path, string startCommitId = null);
        /// <summary>
        /// Restore File From History
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-history.md#user-content-Restore%20File%20From%20History">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="commitId"></param>
        /// <returns></returns>
        bool RestoreFile(string accessToken, string repoId, string path, string commitId);
        /// <summary>
        /// Download File From a Revision
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-history.md#user-content-Download%20File%20From%20a%20Revision">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="commitId"></param>
        /// <returns></returns>
        string GetHistoryFileDownloadLink(string accessToken, string repoId, string path, string commitId);
    }

    public partial class Api
    {
        [Get("api/v2.1/repos/{repo_id}/file/history/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public PagedHistory GetFileHistory(
            [ForHeader]
            string accessToken, 
            [ForUrlSegment]
            string repoId,
            [ForQueryString]
            string path, 
            [ForQueryString("commit_id")]
            string startCommitId = null
        ) => throw forbidCallingDirectly;

        [Post("/api/v2.1/repos/{repo_id}/file/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("operation", "revert")]
        [Destructure("success")]
        public bool RestoreFile(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString]
            string path,
            [ForParameter("commit_id")]
            string commitId
        ) => throw forbidCallingDirectly;
        [Get("/api2/repos/{repo-id}/file/revision/")]
        public string GetHistoryFileDownloadLink(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString]
            string path,
            [ForQueryString("commit_id")]
            string commitId
        ) => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{

    public class PagedHistory
    {
        [JsonPropertyName("next_start_commit")]
        public string NextCommitId { get; set; }
        [JsonPropertyName("data")]
        public IEnumerable<HistoryItem> Items { get; set; }
    }

    public class HistoryItem
    {
        [JsonPropertyName("commit_id")]
        public string CommitId { get; set; }
        [JsonPropertyName("rev_file_id")]
        public string RevFileId { get; set; }
        [JsonPropertyName("ctime")]
        public DateTime CreatedTime { get; set; }
        [JsonPropertyName("creator_name")]
        public string CreatorName { get; set; }
        [JsonPropertyName("creator_email")]
        public string CreatorEmail { get; set; }
        [JsonPropertyName("rev_rename_old_path")]
        public string RevRenamedOldPath { get; set; }
        [JsonPropertyName("creator_avatar_url")]
        public string CreatorAvatarUrl { get; set; }
        [JsonPropertyName("path")]
        public string Path { get; set; }
        [JsonPropertyName("creator_contact_email")]
        public string CreatorContactEmail { get; set; }
        [JsonPropertyName("size")]
        public long Size { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}