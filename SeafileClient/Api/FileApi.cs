using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeafileClient.Common.Attributes;
using SeafileClient.Common.Converters;
using SeafileClient.Responses;

namespace SeafileClient
{
    public interface IFileApi
    {
        /// <summary>
        /// Download File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file.md#user-content-Download%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="reuse"></param>
        /// <returns></returns>
        string GetDownloadLink(string accessToken, string repoId, string path, bool reuse = true);
        /// <summary>
        /// Get File Detail
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file.md#user-content-Get%20File%20Detail">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        FileDetail GetFileDetail(string accessToken, string repoId, string path);
        /// <summary>
        /// Create File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file.md#user-content-Create%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        FileInfo CreateFile(string accessToken, string repoId, string path);
        /// <summary>
        /// Rename File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file.md#user-content-Rename%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        FileInfo RenameFile(string accessToken, string repoId, string path, string newName);
        /// <summary>
        /// Lock File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file.md#user-content-Lock%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        FileInfo LockFile(string accessToken, string repoId, string path);
        /// <summary>
        /// Unlock File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file.md#user-content-Unlock%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        FileInfo UnlockFile(string accessToken, string repoId, string path);
        /// <summary>
        /// Move File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file.md#user-content-Move%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="targetRepoId"></param>
        /// <param name="targetDir"></param>
        /// <returns></returns>
        MoveFileResult MoveFile(string accessToken, string repoId, string path, string targetRepoId, string targetDir);
        /// <summary>
        /// Copy File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file.md#user-content-Copy%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="targetRepoId"></param>
        /// <param name="targetDir"></param>
        /// <returns></returns>
        CopyFileResult CopyFile(string accessToken, string repoId, string path, string targetRepoId, string targetDir);
        /// <summary>
        /// Delete File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file.md#user-content-Delete%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        bool DeleteFile(string accessToken, string repoId, string path);
        /// <summary>
        /// Get Smart Link for a File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file.md#user-content-Get%20Smart%20Link%20for%20a%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="isDir"></param>
        /// <returns></returns>
        string GenerateInternalLink(string accessToken, string repoId, string path, bool isDir);
    }

    public partial class Api
    {
        [Get("/api2/repos/{repoId}/file/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public string GetDownloadLink(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path,
            [ForQueryString("reuse", ConverterType = typeof(BoolToIntConverter))]
            bool reuse
        ) => throw forbidCallingDirectly;

        [Get("/api2/repos/{repoId}/file/detail/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public FileDetail GetFileDetail(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path
        ) => throw forbidCallingDirectly;

        [Post("/api/v2.1/repos/{repoId}/file/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("operation", "create")]
        public FileInfo CreateFile(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/{repoId}/file/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("operation", "rename")]
        public FileInfo RenameFile(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path,
            [ForParameter("newname")]
            string newName
        ) => throw forbidCallingDirectly;

        [Put("/api2/repos/{repoId}/file/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("operation", "lock")]
        public FileInfo LockFile(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path
        ) => throw forbidCallingDirectly;

        [Put("/api2/repos/{repoId}/file/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("operation", "unlock")]
        public FileInfo UnlockFile(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path
        ) => throw forbidCallingDirectly;


        [Post("/api2/repos/{repoId}/file/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("operation", "move")]
        public MoveFileResult MoveFile(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path,
            [ForParameter("dst_repo")]
            string targetRepoId,
            [ForParameter("dst_dir")]
            string targetDir
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/{repoId}/file/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("operation", "copy")]
        public CopyFileResult CopyFile(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path,
            [ForParameter("dst_repo")]
            string targetRepoId,
            [ForParameter("dst_dir")]
            string targetDir
        ) => throw forbidCallingDirectly;

        [Delete("/api2/repos/{repoId}/file/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public bool DeleteFile(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path
        ) => throw forbidCallingDirectly;


        [Get("/api/v2.1/smart-link/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public string GenerateInternalLink(
            [ForHeader]
            string accessToken,
            [ForQueryString("repo_id")]
            string repoId,
            [ForQueryString("p")]
            string path,
            [ForQueryString("is_dir", ConverterType = typeof(BoolToIntConverter))]
            bool isDir
        ) => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{
    public class MoveFileResult
    {
        public string RepoId { get; set; }
        public string ParentDir { get; set; }
        public string ObjName { get; set; }
    }

    public class CopyFileResult
    {
        public string RepoId { get; set; }
        public string ParentDir { get; set; }
        public string ObjName { get; set; }
    }
    public class FileInfo
    {
        public bool IsLocked { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ObjId { get; set; }
        public string ObjName { get; set; }
        public string ParentDir { get; set; }
        public string RepoId { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
    }

    public class FileDetail
    {
        [JsonPropertyName("last_modifier_name")]
        public string LastModifierName { get; set; }
        [JsonPropertyName("uploader_email")]
        public string UploaderEmail { get; set; }
        [JsonPropertyName("upload_time")]
        public DateTime UploadTime { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public string UploaderName { get; set; }
        public string UploaderContactEmail { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool Starred { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string LastModifierEmail { get; set; }
        public string LastMOdifierContactEmail { get; set; }
    }

    public class Activity
    {
        [JsonPropertyName("commit_id")]
        public string CommitId { get; set; }
        [JsonPropertyName("obj_type")]
        public string ObjType { get; set; }
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("author_email")]
        public string AuthorEmail { get; set; }
        [JsonPropertyName("author_contact_email")]
        public string AuthorContactEmail { get; set; }
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
        [JsonPropertyName("author_name")]
        public string AuthorName { get; set; }
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonPropertyName("op_type")]
        public string OperationType { get; set; }
        [JsonPropertyName("path")]
        public string Path { get; set; }
        [JsonPropertyName("repo_name")]
        public string RepoName { get; set; }
    }



    public class PagedSearchResult
    {
        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }
        [JsonPropertyName("total")]
        public long TotalCount { get; set; }
        [JsonPropertyName("results")]
        public IEnumerable<SearchedItem> Data { get; set; }
    }

    public class SearchedItem
    {
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("repo_encrypted")]
        public bool RepoEncrypted { get; set; }
        [JsonPropertyName("permission")]
        public string Permission { get; set; }
        [JsonPropertyName("oid")]
        public string ObjId { get; set; }
        [JsonPropertyName("last_modified")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime LastModifiedTime { get; set; }
        [JsonPropertyName("content_highlight")]
        public string Context { get; set; }
        [JsonPropertyName("full_path")]
        public string FullPath { get; set; }
        [JsonPropertyName("repo_name")]
        public string RepoName { get; set; }
        [JsonPropertyName("is_dir")]
        public bool IsDirectory { get; set; }
        [JsonPropertyName("repo_type")]
        public string RepoType { get; set; }
        [JsonPropertyName("size")]
        public long Size { get; set; }
    }

}
