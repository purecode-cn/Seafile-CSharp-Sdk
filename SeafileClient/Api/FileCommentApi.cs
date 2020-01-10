using SeafileClient.Common.Attributes;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SeafileClient
{

    public interface IFileCommentApi
    {
        /// <summary>
        /// Get File Comment
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-comments.md#user-content-Get%20Comment">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        Comment GetComment(string accessToken, string repoId, string commentId);
        /// <summary>
        /// Delete File Comment
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-comments.md#user-content-Delete%20Comment">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="commentId"></param>
        void DeleteComment(string accessToken, string repoId, string commentId);
        /// <summary>
        /// Update File Comment
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-comments.md#user-content-Update%20Comment">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="commentId"></param>
        /// <param name="content"></param>
        /// <param name="resolved"></param>
        /// <returns></returns>
        Comment UpdateComment(string accessToken, string repoId, string commentId, string content, bool resolved);
        /// <summary>
        /// List a file's comments
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-comments.md#user-content-List%20Comments">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        IEnumerable<Comment> ListComments(string accessToken, string repoId, string path);
        /// <summary>
        /// Create a comment
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-comments.md#user-content-Post%20Comments">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Comment CreateComment(string accessToken, string repoId, string path, string content);
        /// <summary>
        /// Get comments count in a path
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/file-comments.md#user-content-Get%20Number%20of%20Comments">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        IEnumerable<Dictionary<string, long>> GetCountOfComments(string accessToken, string repoId, string path);
    }

    public partial class Api
    {

        [Get("/api2/repos/{repoId}/file/comments/{commentId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public Comment GetComment(
            [ForHeader]
            string accessToken, 
            [ForUrlSegment]
            string repoId, 
            [ForUrlSegment]
            string commentId
        ) => throw forbidCallingDirectly;

        [Delete("/api2/repos/{repoId}/file/comments/{commentId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public void DeleteComment(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForUrlSegment]
            string commentId
        ) => throw forbidCallingDirectly;

        [Put("/api2/repos/{repoId}/file/comments/{commentId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public Comment UpdateComment(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForUrlSegment]
            string commentId,
            [ForParameter("detail")]
            string content, 
            [ForParameter("resolved")]
            bool resolved
        ) => throw forbidCallingDirectly;


        [Get("/api2/repos/{repoId}/file/comments/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("comments")]
        public IEnumerable<Comment> ListComments(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/{repoId}/file/comments/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public Comment CreateComment(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path,
            [ForParameter("comment")]
            string content
        ) => throw forbidCallingDirectly;

        [Get("/api2/repos/{repoId}/file/comments/counts/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<Dictionary<string, long>> GetCountOfComments(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path
        ) => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{

    public class Comment
    {
        [JsonPropertyName("comment")]
        public string Content { get; set; }
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("item_name")]
        public string ItemName { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedTime { get; set; }
        [JsonPropertyName("parent_path")]
        public string ParentPath { get; set; }
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        public long Id { get; set; }
        public string UserEmail { get; set; }
        [JsonPropertyName("user_contact_email")]
        public string UserContactEmail { get; set; }
    }
}
