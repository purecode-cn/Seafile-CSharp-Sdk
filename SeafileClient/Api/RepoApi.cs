using SeafileClient.Common.Attributes;
using SeafileClient.Common.Converters;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SeafileClient
{
    public interface IRepoApi
    {
        /// <summary>
        /// Get Default Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Get%20Default%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        DefaultRepo GetDefaultRepo(string accessToken);
        /// <summary>
        /// Create Default Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Create%20Default%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        DefaultRepo CreateDefaultRepo(string accessToken);
        /// <summary>
        /// List Libraries
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-List%20Libraries">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type"></param>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <returns></returns>
        List<Repo> ListRepos(string accessToken, string type = null, string query = null, int page = 1, int perPage = 25);
        /// <summary>
        /// Create Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Create%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoName"></param>
        /// <param name="password"></param>
        /// <param name="storageId"></param>
        /// <returns></returns>
        NewRepo CreateRepo(string accessToken, string repoName, string password = null, string storageId = null);
        /// <summary>
        /// Create Encrypted Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Create%20Encrypted%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoName"></param>
        /// <param name="magic"></param>
        /// <param name="randomKey"></param>
        /// <param name="repoId"></param>
        /// <param name="encVersion"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        NewRepo CreateEncryptedRepo(string accessToken, string repoName, string magic, string randomKey, string repoId, string encVersion, string salt);
        /// <summary>
        /// Decrypt Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/library-encryption.md#user-content-Decrypt%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        string DecryptRepo(string accessToken, string repoId, string password);
        /// <summary>
        /// Delete Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Delete%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        bool DeleteRepo(string accessToken, string repoId);
        /// <summary>
        /// Rename Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Rename%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        bool RenameRepo(string accessToken, string repoId);
        /// <summary>
        /// Transfer Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Transfer%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="newOwer"></param>
        /// <returns></returns>
        bool TransferRepo(string accessToken, string repoId, string newOwer);
        /// <summary>
        /// Get Library Info
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Get%20Library%20Info">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        Repo GetRepoInfo(string accessToken, string repoId);
        /// <summary>
        /// Get Library Owner
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Get%20Library%20Owner">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        string GetRepoOwner(string accessToken, string repoId);
        /// <summary>
        /// Get Library History
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Library%20History%20and%20Trash">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <returns></returns>
        RepoHistory GetRepoHistory(string accessToken, string repoId, int page = 1, int perPage = 100);
        /// <summary>
        /// Get Library History Limit Days
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Get%20Library%20History%20Limit%20Days">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        int GetRepoHistoryLimitDays(string accessToken, string repoId);
        /// <summary>
        /// Set Library History Limit Days
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Set%20Library%20History%20Limit%20Days">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        int SetRepoHistoryLimitDays(string accessToken, string repoId, int days);
        /// <summary>
        /// Get Library Trash
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Get%20Library%20Trash">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        RepoTrash ListRepoTrash(string accessToken, string repoId);
        /// <summary>
        /// Clean Library Trash
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/libraries.md#user-content-Clean%20Library%20Trash">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        bool CleanRepoTrash(string accessToken, string repoId);
    }

    public partial class Api
    {
        [Post("/api2/default-repo/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public DefaultRepo CreateDefaultRepo(
            [ForHeader]
            string accessToken
        ) => throw forbidCallingDirectly;

        [Get("/api2/default-repo/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public DefaultRepo GetDefaultRepo(
            [ForHeader]
            string accessToken
        ) => throw forbidCallingDirectly;

        [Get("/api2/repos/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public List<Repo> ListRepos(
            [ForHeader]
            string accessToken,
            [ForQueryString]
            string type = null,
            [ForQueryString("nameContains")]
            string query = null,
            [ForQueryString]
            int page = 1,
            [ForQueryString("per_page")]
            int perPage = 25
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public NewRepo CreateRepo(
            [ForHeader]
            string accessToken,
            [ForParameter("name")]
            string repoName,
            [ForParameter("passwd")]
            string password = null,
            [ForParameter("storage_id")]
            string storageId = null
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public NewRepo CreateEncryptedRepo(
            [ForHeader]
            string accessToken,
            [ForParameter("name")]
            string repoName,
            [ForParameter]
            string magic,
            [ForParameter("random_key")]
            string randomKey,
            [ForParameter("repo_id")]
            string repoId,
            [ForParameter("enc_version")]
            string encVersion,
            [ForParameter]string salt
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/{repoId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public string DecryptRepo(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForParameter]
            string password
        ) => throw forbidCallingDirectly;

        [Delete("/api2/repos/{repoId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public bool DeleteRepo(
            [ForHeader]string accessToken,
            [ForUrlSegment]string repoId
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/{repoId}/?op=rename")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public bool RenameRepo(
            [ForHeader]string accessToken,
            [ForUrlSegment]string repoId
        ) => throw forbidCallingDirectly;

        [Put("/api2/repos/{repoId}/owner/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool TransferRepo(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForParameter("owner")]
            string newOwner
        ) => throw forbidCallingDirectly;

        [Get("/api2/repos/{repoId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public Repo GetRepoInfo(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId
        ) => throw forbidCallingDirectly;

        [Get("/api2/repos/{repoId}/owner/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("owner")]
        public string GetRepoOwner(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId
        ) => throw forbidCallingDirectly;

        [Get("/api2/repos/{repoId}/history/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public RepoHistory GetRepoHistory(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString]
            int page = 1,
            [ForQueryString("per_page")]
            int perPage = 100
        ) => throw forbidCallingDirectly;
        [Get("/api2/repos/{repoId}/history-limit/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("keep_days")]
        public int GetRepoHistoryLimitDays(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId
        ) => throw forbidCallingDirectly;

        [Put("/api2/repos/{repoId}/history-limit/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("keep_days")]
        public int SetRepoHistoryLimitDays(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForParameter("keep_days")]
            int keepDays
        ) => throw forbidCallingDirectly;

        [Get("/api2/repos/{repoId}/trash/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public RepoTrash ListRepoTrash(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId
        ) => throw forbidCallingDirectly;

        [Delete("/api2/repos/{repoId}/trash/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool CleanRepoTrash(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId
        ) => throw forbidCallingDirectly;

    }

    namespace Responses
    {

        public class DefaultRepo
        {
            [JsonPropertyName("repo_id")]
            public string Id { get; set; }
            [JsonPropertyName("exists")]
            public bool Exists { get; set; }
        }

        public class NewRepo
        {
            [JsonPropertyName("repo_id")]
            public string Id { get; set; }
            [JsonPropertyName("repo_name")]
            public string Name { get; set; }
            [JsonPropertyName("encrypted")]
            [JsonConverter(typeof(BoolProtectedConverter))]
            public bool Encrypted { get; set; }
            [JsonPropertyName("email")]
            public string OnwerEmail { get; set; }
            [JsonPropertyName("mtime")]
            [JsonConverter(typeof(TimestampConverter))]
            public DateTime CreatedTime { get; set; }
            [JsonPropertyName("repo_size")]
            public long Size { get; set; }
        }

        public class Repo
        {
            [JsonPropertyName("enc_version")]
            public int? EncVersion { get; set; }

            [JsonPropertyName("encrypted")]
            public bool Encrypted { get; set; }

            [JsonPropertyName("group_name")]
            public string GroupName { get; set; }

            [JsonPropertyName("group_id")]
            public string GroupId { get; set; }

            [JsonPropertyName("file_count")]
            public int? FileCount { get; set; }

            [JsonPropertyName("head_commit_id")]
            public string HeadCommitId { get; set; }

            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("is_admin")]
            public bool? IsAdmin { get; set; }

            [JsonPropertyName("magic")]
            public string Magic { get; set; }

            [JsonPropertyName("mtime")]
            [JsonConverter(typeof(TimestampConverter))]
            public DateTime ModifiedTime { get; set; }

            [JsonPropertyName("modifier_contact_email")]
            public string ModifierContactEmail { get; set; }
            [JsonPropertyName("modifier_name")]
            public string ModifierName { get; set; }
            [JsonPropertyName("modifier_email")]
            public string ModifierEmail { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("owner_name")]
            public string OwnerName { get; set; }
            [JsonPropertyName("owner")]
            public string Owner { get; set; }
            [JsonPropertyName("owner_contact_email")]
            public string OwnerContactEmail { get; set; }

            [JsonPropertyName("permission")]
            public string Permission { get; set; }

            [JsonPropertyName("random_key")]
            public string RandomKey { get; set; }

            [JsonPropertyName("root")]
            public string Root { get; set; }
            
            [JsonPropertyName("salt")]
            public string Salt { get; set; }

            [JsonPropertyName("share_from")]
            public string ShareFromEmail { get; set; }
            [JsonPropertyName("share_from_contact_email")]
            public string ShareFromContactEmail { get; set; }
            [JsonPropertyName("share_from_name")]
            public string ShareFromName { get; set; }
            [JsonPropertyName("share_type")]
            public string ShareType { get; set; }

            [JsonPropertyName("size")]
            public long Size { get; set; }

            [JsonPropertyName("size_formatted")]
            public string SizeFormatted { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("version")]
            public int Version { get; set; }
        }

        public class RepoHistory
        {
            [JsonPropertyName("data")]
            public IEnumerable<RepoHistoryItem> Items { get; set; }
            [JsonPropertyName("more")]
            public bool HasMore { get; set; }
        }

        public class RepoHistoryItem
        {
            [JsonPropertyName("commit_id")]
            public string CommitId { get; set; }
            [JsonPropertyName("time")]
            public DateTime Time { get; set; }
            [JsonPropertyName("description")]
            public string Description { get; set; }
            [JsonPropertyName("creator")]
            public string Creator { get; set; }
        }

        public class RepoTrash
        {
            [JsonPropertyName("scan_stat")]
            public string ScanStat { get; set; }
            [JsonPropertyName("data")]
            public IEnumerable<RepoTrashItem> Items { get; set; }
            [JsonPropertyName("more")]
            public bool HasMore { get; set; }
        }

        public class RepoTrashItem
        {
            [JsonPropertyName("commit_id")]
            public string CommitId { get; set; }
            [JsonPropertyName("scan_stat")]
            public string ScanStat { get; set; }
            [JsonPropertyName("obj_id")]
            public string ObjId { get; set; }
            [JsonPropertyName("deleted_time")]
            public DateTime DeletedTime { get; set; }
            [JsonPropertyName("obj_name")]
            public string ObjName { get; set; }
            [JsonPropertyName("is_dir")]
            public bool IsDir { get; set; }
            [JsonPropertyName("parent_dir")]
            public string ParentDir { get; set; }
            [JsonPropertyName("size")]
            public long Size { get; set; }
        }
    }
}
