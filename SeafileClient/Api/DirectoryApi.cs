using SeafileClient.Common.Attributes;
using SeafileClient.Common.Converters;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SeafileClient
{
    public interface IDirectoryApi
    {
        /// <summary>
        /// List Items in Directory
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/directories.md#user-content-List%20Items%20in%20Directory">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path">The path to a directory. If path is missing, then defaults to '/' which is the top directory.</param>
        /// <param name="objectId">The object id of the directory. The object id is the checksum of the directory contents.</param>
        /// <param name="type">If set type argument as `f`, will only return file entries, and `d` for only dir entries.</param>
        /// <param name="recursive">If set type argument as `d` AND recursive argument as `true`, return all dir entries recursively.</param>
        /// <returns></returns>
        IEnumerable<DirEntry> ListDirectories(string accessToken, string repoId, string path = null, string objectId = null, string type = null, bool recursive = false);

        /// <summary>
        /// Get Directory Detail
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/directories.md#user-content-Get%20Directory%20Detail">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        DirInfo GetDirectoryInfo(string accessToken, string repoId, string path);

        /// <summary>
        /// Create Directory
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/directories.md#user-content-Create%20New%20Directory">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        bool CreateDirectory(string accessToken, string repoId, string path);

        /// <summary>
        /// Delete Directory
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/directories.md#user-content-Delete%20Directory">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        bool DeleteDirectory(string accessToken, string repoId, string path);

        /// <summary>
        /// Rename Directory
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/directories.md#user-content-Rename%20Directory">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="newPath"></param>
        /// <returns></returns>
        bool RenameDirectory(string accessToken, string repoId, string path, string newPath);

        /// <summary>
        /// Revert Directory to a History Status
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/directories.md#user-content-Revert%20Directory%20to%20a%20History%20Status">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="commitId"></param>
        /// <returns></returns>
        bool RevertDirectory(string accessToken, string repoId, string path, string commitId);
        /// <summary>
        /// Download Directory
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/directories.md#user-content-Download%20Directory">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="parentPath"></param>
        /// <param name="DirEntryName"></param>
        /// <returns></returns>
        string DownloadDirectory(string accessToken, string repoId, string parentPath, string DirEntryName);
        /// <summary>
        /// Query Task Progress
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/directories.md#user-content-Query%20Task%20Progress">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="zipProccessToken"></param>
        /// <returns></returns>
        ZipProgress QueryTaskProcess(string accessToken, string zipProccessToken);
        /// <summary>
        /// Move directory with items merged
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/directories.md#user-content-Move%20directory%20with%20items%20merged">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sourceRepoId"></param>
        /// <param name="sourceParentPath"></param>
        /// <param name="sourceDirEntryName"></param>
        /// <param name="targetRepoId"></param>
        /// <param name="targetParentPath"></param>
        /// <returns></returns>
        bool MergeDirectoryWithItems(string accessToken, string sourceRepoId, string sourceParentPath, string sourceDirEntryName, string targetRepoId, string targetParentPath);
    }

    public partial class Api
    {
        [Get("/api2/repos/{repoId}/dir/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<DirEntry> ListDirectories(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path = null,
            [ForQueryString("oid")]
            string objectId = null,
            [ForQueryString("t")]
            string type = null,
            [ForQueryString("recursive", ConverterType = typeof(BoolToIntConverter))]
            bool recursive = false
        ) => throw forbidCallingDirectly;

        [Get("/api2/repos/{repoId}/dir/detail/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public DirInfo GetDirectoryInfo(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/{repoId}/dir/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("operation", "mkdir")]
        public bool CreateDirectory(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path
        ) => throw forbidCallingDirectly;

        [Delete("/api2/repos/{repoId}/dir/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public bool DeleteDirectory(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path
        ) => throw forbidCallingDirectly;

        [Get("/api2/repos/{repoId}/dir/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("operation", "rename")]
        public bool RenameDirectory(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path,
            [ForParameter("newname")]
            string newPath
        ) => throw forbidCallingDirectly;

        [Put("/api2/repos/{repoId}/dir/revert/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool RevertDirectory(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForParameter("p")]
            string path,
            [ForParameter("commit_id")]
            string commitId
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/repos/{repoId}/zip-task/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("zip_token")]
        public string DownloadDirectory(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("parent_dir")]
            string parentPath,
            [ForQueryString("dirents")]
            string DirEntryName
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/query-zip-progress/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public ZipProgress QueryTaskProcess(
            [ForHeader]
            string accessToken,
            [ForQueryString("token")]
            string zipProccessToken
        ) => throw forbidCallingDirectly;

        [Post("/api/v2.1/move-folder-merge/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool MergeDirectoryWithItems(
            [ForHeader]
            string accessToken,
            [ForParameter("src_repo_id")]
            string sourceRepoId,
            [ForParameter("src_parent_dir")]
            string sourceParentPath,
            [ForParameter("src_dirent_name")]
            string sourceDirEntryName,
            [ForParameter("dst_repo_id")]
            string targetRepoId,
            [ForParameter("dst_parent_dir")]
            string targetParentPath
        ) => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{
    public class DirEntry
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("size")]
        public long Size { get; set; }
    }
    public class DirInfo
    {
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("mtime")]
        public DateTime ModifiedTime { get; set; }
        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
    public class ZipProgress {
        public long TotalCount { get; set; }
        public long ZippedCount { get; set; }
    }
}
