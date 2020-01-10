using SeafileClient.Common.Attributes;
using SeafileClient.Common.Converters;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SeafileClient
{
    public interface IPublicUploadLinkApi
    {
        /// <summary>
        /// List Upload Links
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/upload-links.md#user-content-List%20Upload%20Links">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        IEnumerable<UploadLink> ListPublicUploadLinks(string accessToken);
        /// <summary>
        /// Create Upload Link
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/upload-links.md#user-content-Create%20Upload%20Link">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UploadLink CreatePublicUploadLink(string accessToken, string repoId, string path, string password);

        /// <summary>
        /// Exchange Public Upload Link to Real Upload Link of File Server
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/upload-links.md#user-content-Upload%20File">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        string ExchangeUploadLink(string accessToken, string token);
        /// <summary>
        /// Delete Upload Link
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/upload-links.md#user-content-Delete%20Upload%20Link">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="linkToken"></param>
        /// <returns></returns>
        bool DeletePublicUploadLink(string accessToken, string linkToken);
        /// <summary>
        /// Send Upload Link Email
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/upload-links.md#user-content-Send%20Upload%20Link%20Email">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="linkToken"></param>
        /// <param name="emails"></param>
        /// <param name="extraMessage"></param>
        /// <returns></returns>
        SendUploadLinkResult SendPublicUploadLinkEmail(string accessToken, string linkToken, IEnumerable<string> emails, string extraMessage = null);


    }
    public partial class Api
    {
        [Get("/api/v2.1/upload-links/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<UploadLink> ListPublicUploadLinks(
            [ForHeader]
            string accessToken
        ) => throw forbidCallingDirectly;
        
        [Post("/api/v2.1/upload-links/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public UploadLink CreatePublicUploadLink(
            [ForHeader]
            string accessToken, 
            [ForParameter("repo_id")]
            string repoId, 
            [ForParameter]
            string path, 
            [ForParameter]
            string password
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/upload-links/{token}/upload/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("upload_link")]
        public string ExchangeUploadLink(
            [ForHeader]
            string accessToken, 
            [ForUrlSegment]
            string token
        ) => throw forbidCallingDirectly;

        [Delete("/api/v2.1/upload-links/{linkToken}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool DeletePublicUploadLink(
            [ForHeader]
            string accessToken, 
            [ForUrlSegment]
            string linkToken
        ) => throw forbidCallingDirectly;
        
        [Post("/api/v2.1/send-upload-links/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public SendUploadLinkResult SendPublicUploadLinkEmail(
            [ForHeader]
            string accessToken, 
            [ForParameter("token")]
            string linkToken, 
            [ForParameter("email", ConverterType = typeof(JoinStringsConverter))]
            IEnumerable<string> emails,
            [ForParameter("extra_msg")]
            string extraMessage = null) => throw forbidCallingDirectly;
    }
}


namespace SeafileClient.Responses
{
    public class UploadLink
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("ctime")]
        public DateTime CreatedTime { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("path")]
        public string Path { get; set; }
    }

    public class SendUploadLinkResult
    {
        [JsonPropertyName("failed")]
        public IEnumerable<SendUploadLinkFailedItem> FailedItems { get; set; }
        [JsonPropertyName("success")]
        public IEnumerable<string> SuccessfulEmails { get; set; }
    }

    public class SendUploadLinkFailedItem
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("error_msg")]
        public string ErrorMessage { get; set; }
    }
}