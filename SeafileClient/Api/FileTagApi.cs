using SeafileClient.Common.Attributes;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SeafileClient
{

    public interface IFileTagApi
    {
        /// <summary>
        /// List All Tags of a Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-tags.md#user-content-List%20All%20Tags%20of%20a%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        IEnumerable<RepoTag> ListRepoTags(string accessToken, string repoId);
        /// <summary>
        /// Add a Tag to a Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-tags.md#user-content-Add%20a%20Tag%20to%20a%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        RepoTag CreateRepoTag(string accessToken, string repoId, string name, string color);
        /// <summary>
        /// Update a Tag of a Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-tags.md#user-content-Update%20a%20Tag%20of%20a%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="tagId"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        RepoTag UpdateRepoTag(string accessToken, string repoId, int tagId, string name, string color);
        /// <summary>
        /// Delete a Tag of a Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-tags.md#user-content-Delete%20a%20Tag%20of%20a%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        bool DeleteRepoTag(string accessToken, string repoId, int tagId);
        /// <summary>
        /// List All Tags of a File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-tags.md#user-content-List%20All%20Tags%20of%20a%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        IEnumerable<FileTag> ListFileTags(string accessToken, string repoId, string path);
        /// <summary>
        /// Add a Tag for a File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-tags.md#user-content-Add%20a%20Tag%20for%20a%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        FileTag AddFileTag(string accessToken, string repoId, string path, string tagId);
        /// <summary>
        /// Delete a Tag from a File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-tags.md#user-content-Delete%20a%20Tag%20from%20a%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="fileTagId"></param>
        /// <returns></returns>
        bool DeleteFileTag(string accessToken, string repoId, int fileTagId);
        /// <summary>
        /// List Tagged Files By Tag Id
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-tags.md#user-content-List%20Tagged%20Files%20By%20Tag%20ID">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="repoTagId"></param>
        /// <returns></returns>
        IEnumerable<TaggedFile> GetTaggedFile(string accessToken, string repoId, int repoTagId);
    }

    public partial class Api
    {

        [Get("/api/v2.1/repos/{repoId}/repo-tags/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("repo_tags")]
        public IEnumerable<RepoTag> ListRepoTags(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId
        ) => throw forbidCallingDirectly;

        [Post("/api/v2.1/repos/{repoId}/repo-tags/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("repo_tag")]
        public RepoTag CreateRepoTag(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForParameter]
            string name,
            [ForParameter]
            string color
        ) => throw forbidCallingDirectly;

        [Put("/api/v2.1/repos/{repoId}/repo-tags/{tagId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("repo_tag")]
        public RepoTag UpdateRepoTag(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForUrlSegment]
            int tagId,
            [ForParameter]
            string name,
            [ForParameter]
            string color
        ) => throw forbidCallingDirectly;

        [Delete("/api/v2.1/repos/{repoId}/repo-tags/{tagId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool DeleteRepoTag(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForUrlSegment]
            int tagId
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/repos/{repoId}/file-tags/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("file_tags")]
        public IEnumerable<FileTag> ListFileTags(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("file_path")]
            string path
        ) => throw forbidCallingDirectly;

        [Post("/api/v2.1/repos/{repoId}/file-tags/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("file_tag")]
        public FileTag AddFileTag(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForParameter("file_path")]
            string path,
            [ForParameter("repo_tag_id")]
            string tagId
        ) => throw forbidCallingDirectly;

        [Delete("/api/v2.1/repos/{repoId}/file-tags/{fileTagId}")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool DeleteFileTag(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForUrlSegment]
            int fileTagId
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/repos/{repoId}/tagged-files/{repoTagId}")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("tagged_files")]
        public IEnumerable<TaggedFile> GetTaggedFile(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForUrlSegment]
            int repoTagId
        ) => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{

    public class RepoTag
    {
        [JsonPropertyName("tag_color")]
        public string Color { get; set; }
        [JsonPropertyName("tag_name")]
        public string Name { get; set; }
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("repo_tag_id")]
        public string TagId { get; set; }
    }

    public class FileTag
    {
        [JsonPropertyName("tag_color")]
        public string Color { get; set; }
        [JsonPropertyName("tag_name")]
        public string Name { get; set; }
        [JsonPropertyName("repo_tag_id")]
        public int RepoTagId { get; set; }
        [JsonPropertyName("file_tag_id")]
        public int FileTagId { get; set; }
    }

    public class TaggedFile
    {
        [JsonPropertyName("modifier_email")]
        public string ModifierEmail { get; set; }
        [JsonPropertyName("file_tag_id")]
        public int FileTagId { get; set; }
        [JsonPropertyName("filename")]
        public string FileName { get; set; }
        [JsonPropertyName("parent_path")]
        public string ParentPath { get; set; }
        [JsonPropertyName("last_modified")]
        public DateTime LastModifiedTime { get; set; }
        [JsonPropertyName("modifier_contact_email")]
        public string ModifierContactEmail { get; set; }
        [JsonPropertyName("modifier_name")]
        public string ModifierName { get; set; }
        [JsonPropertyName("size")]
        public long Size { get; set; }
    }
}