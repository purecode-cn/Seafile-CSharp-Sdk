using SeafileClient.Common.Attributes;
using SeafileClient.Common.Converters;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SeafileClient
{
    public interface IFileUploadApi
    {
        /// <summary>
        /// Get Upload Link
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-upload.md#user-content-Get%20Upload%20Link">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="uploadDir"></param>
        /// <returns></returns>
        string CreateUploadLink(string accessToken, string repoId, string uploadDir);
        /// <summary>
        /// Upload File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-upload.md#user-content-Upload%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="uploadLink"></param>
        /// <param name="localFilePath"></param>
        /// <param name="parentPath"></param>
        /// <param name="relativePath"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        IEnumerable<UploadResult> UploadFiles(string accessToken, string uploadLink, string[] localFilePath, string parentPath, string relativePath = null, bool replace = false);
        /// <summary>
        /// Get Update Link
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-upload.md#user-content-Get%20Update%20Link">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="updateDir"></param>
        /// <returns></returns>
        string CreateUpdateLink(string accessToken, string repoId, string updateDir);
        /// <summary>
        /// Update File
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-upload.md#user-content-Update%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="updateLink"></param>
        /// <param name="localFilePath"></param>
        /// <param name="targetFilePath"></param>
        /// <returns></returns>
        string UpdateFile(string accessToken, string updateLink, string localFilePath, string targetFilePath);
    }

    public partial class Api
    {
        [Get("/api2/repos/{repoId}/upload-link/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public string CreateUploadLink(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId, 
            [ForQueryString("p")]
            string uploadDir
        ) => throw forbidCallingDirectly;

        [Post("{uploadLink}", IsAbsoluteUrl = true)]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("ret-json", true, ConverterType = typeof(BoolToIntConverter))]
        public IEnumerable<UploadResult> UploadFiles(
            [ForHeader]
            string accessToken, 
            [ForUrlSegment]
            string uploadLink,
            [ForParameter("file", IsFile = true)]
            string[] localFilePath, 
            [ForParameter("parent_dir")]
            string parentPath, 
            [ForParameter("relative_path")]
            string relativePath = null, 
            [ForParameter(ConverterType = typeof(BoolToIntConverter))]
            bool replace = false
        ) => throw forbidCallingDirectly;
        [Get("/api2/repos/{repoId}/update-link/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public string CreateUpdateLink(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string updateDir
        ) => throw forbidCallingDirectly;

        [Post("{updateLink}", IsAbsoluteUrl = true)]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public string UpdateFile(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string updateLink,
            [ForParameter("file", IsFile = true)]
            string localFilePath,
            [ForParameter("target_file")]
            string targetFilePath
        ) => throw forbidCallingDirectly;
        
    }
}

namespace SeafileClient.Responses
{
    public class UploadResult
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("size")]
        public long Size { get; set; }
    }
}