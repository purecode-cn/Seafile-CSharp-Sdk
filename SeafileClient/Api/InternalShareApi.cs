using SeafileClient.Common.Attributes;
using SeafileClient.Common.Converters;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SeafileClient
{
    public interface IInternalShareApi
    {
        /// <summary>
        /// List Shared Users of a Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-List%20Shared%20Users%20of%20a%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        IEnumerable<SharedUserInfo> ListSharedUsersOfRepo(string accessToken, string repoId);

        /// <summary>
        /// List Shared Groups of a Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-List%20Shared%20Groups%20of%20a%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        IEnumerable<SharedGroupInfo> ListSharedGroupsOfRepo(string accessToken, string repoId);
        /// <summary>
        /// List Libraries Shared to me
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-List%20Libraries%20Shared%20to%20me">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        IEnumerable<SharedSelfInfo> ListSharedRepoToSelf(string accessToken);
        /// <summary>
        /// Share a Library to User
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Share%20a%20Library%20to%20User">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="email"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        ShareToUserResult ShareRepoToUser(string accessToken, string repoId, string email, string permission);
        /// <summary>
        /// Share a Library to Group
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Share%20a%20Library%20to%20Group">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="groupId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        ShareToGroupResult ShareRepoToGroup(string accessToken, string repoId, int groupId, string permission);
        /// <summary>
        /// Unshare a Library from User
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Unshare%20a%20Library%20from%20User">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool RemoveUserFromSharedRepo(string accessToken, string repoId, string email);
        /// <summary>
        /// Unshare a Library from Group
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Unshare%20a%20Library%20from%20Group">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="groupId"></param>
        /// <exception cref=""></exception>
        /// <returns></returns>
        bool RemoveGroupFromSharedRepo(string accessToken, string repoId, int groupId);
        /// <summary>
        /// Update User Share Permission of a Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Update%20User%20Share%20Permission%20of%20a%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="email"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        bool UpdateUserPermissionOfSharedRepo(string accessToken, string repoId, string email, string permission);
        /// <summary>
        /// Update Share Permission of Group Shared Library
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Update%20Share%20Permission%20of%20Group%20Shared%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="groupId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        bool UpdateGroupPermissionOfSharedRepo(string accessToken, string repoId, int groupId, string permission);
        /// <summary>
        /// Delete a library shared to me (leave the share)
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Delete%20a%20library%20shared%20to%20me%20(leave%20the%20share)">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="fromEmail"></param>
        /// <returns></returns>
        bool LeaveShareRepoFromUser(string accessToken, string repoId, string fromEmail);
        /// <summary>
        /// Shared-with-all Libraries
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Create%20shared-with-all%20Library">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="name"></param>
        /// <param name="permission"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Repo CreatePublicRepo(string accessToken, string name, string permission, string password = null);
        /// <summary>
        /// Share Existing Library as shared-with-all
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Share%20Existing%20Library%20as%20shared-with-all">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        bool ShareExistedRepoToPublic(string accessToken, string repoId, string permission);
        /// <summary>
        /// Remove Library from shared-with-all
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Remove%20Library%20from%20shared-with-all">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        bool RemoveRepoFromPublic(string accessToken, string repoId);
        /// <summary>
        /// Batch Share Libraries to User
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Batch%20Share%20Libraries%20to%20User">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userName"></param>
        /// <param name="repoIds"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        BatchShareRepoToUserResult BatchShareRepoToUser(string accessToken, string userName, string[] repoIds, string permission);
        /// <summary>
        /// Batch Share Libraries to Group
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Batch%20Share%20Libraries%20to%20Group">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <param name="repoIds"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        BatchShareRepoToGroupResult BatchShareRepoToGroup(string accessToken, int groupId, string[] repoIds, string permission);
        /// <summary>
        /// List Shared Folders
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-List%20Shared%20Folders">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        IEnumerable<SharedFolderInfo> ListSharedFolders(string accessToken);
        /// <summary>
        /// Share a Folder to a User
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Share%20a%20Folder">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="userEmail"></param>
        /// <param name="permssion"></param>
        /// <returns></returns>
        ShareToUserResult ShareFolderToUser(string accessToken, string repoId, string path, string userEmail, string permssion);
        /// <summary>
        /// Share a Folder to a Group
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Share%20a%20Folder">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="groupId"></param>
        /// <param name="permssion"></param>
        /// <returns></returns>
        ShareToGroupResult ShareFolderToGroup(string accessToken, string repoId, string path, int groupId, string permssion);
        /// <summary>
        /// Update Share Permission of User Shared Folder
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Update%20Folder%20Share%20Permission">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="path"></param>
        /// <param name="email"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        bool UpdateUserPermissionOfSharedFolder(string accessToken, string repoId, string path, string email, string permission);
        /// <summary>
        /// Update Share Permission of Group Shared Folder
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Update%20Folder%20Share%20Permission">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="groupId"></param>
        /// <param name="path"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        bool UpdateGroupPermissionOfSharedFolder(string accessToken, string repoId, string path, int groupId, string permission);
        /// <summary>
        /// Unshare a Folder of a User
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Unshare%20a%20Folder">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="userName"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        bool RemoveUserFromSharedFolder(string accessToken, string repoId, string userName, string path);
        /// <summary>
        /// Unshare a Folder of a Group
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/share.md#user-content-Unshare%20a%20Folder">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="repoId"></param>
        /// <param name="groupId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        bool RemoveGroupFromSharedFolder(string accessToken, string repoId, int groupId, string path);
    }
    public partial class Api
    {

        [Get("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("share_type", "user")]
        [ForQueryString("p", "/")]
        public IEnumerable<SharedUserInfo> ListSharedUsersOfRepo(
            [ForHeader]
            string accessToken, 
            [ForUrlSegment]
            string repoId
        ) => throw forbidCallingDirectly;

        [Get("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("share_type", "group")]
        [ForQueryString("p", "/")]
        public IEnumerable<SharedGroupInfo> ListSharedGroupsOfRepo(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId
        ) => throw forbidCallingDirectly;

        [Get("/api2/beshared-repos/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<SharedSelfInfo> ListSharedRepoToSelf(
            [ForHeader]
            string accessToken
        ) => throw forbidCallingDirectly;

        [Put("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("p", "/")]
        [ForParameter("share_type", "user")]
        public ShareToUserResult ShareRepoToUser(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId, 
            [ForParameter("username")]
            string email,
            [ForParameter("permission")]
            string permission
        ) => throw forbidCallingDirectly;

        [Put("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("p", "/")]
        [ForParameter("share_type", "group")]
        public ShareToGroupResult ShareRepoToGroup(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForParameter("group_id")]
            int groupId,
            [ForParameter("permission")]
            string permission
        ) => throw forbidCallingDirectly;

        [Delete("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("p", "/")]
        [ForQueryString("share_type", "user")]
        [Destructure("success")]
        public bool RemoveUserFromSharedRepo(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("username")]
            string email
        ) => throw forbidCallingDirectly;

        [Delete("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("p", "/")]
        [ForQueryString("share_type", "group")]
        [Destructure("success")]
        public bool RemoveGroupFromSharedRepo(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("group_id")]
            int groupId
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("p", "/")]
        [ForQueryString("share_type", "user")]
        [Destructure("success")]
        public bool UpdateUserPermissionOfSharedRepo(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("username")]
            string email,
            [ForParameter]
            string permission
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("p", "/")]
        [ForQueryString("share_type", "group")]
        [Destructure("success")]
        public bool UpdateGroupPermissionOfSharedRepo(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("group_id")]
            int groupId,
            [ForParameter]
            string permission
        ) => throw forbidCallingDirectly;


        [Delete("/api2/beshared-repos/{repoId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("share_type", "personal")]
        [Destructure("success")]
        public bool LeaveShareRepoFromUser(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("from")]
            string fromEmail
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/public/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public Repo CreatePublicRepo(
            [ForHeader]
            string accessToken,
            [ForParameter]
            string name,
            [ForParameter]
            string permission,
            [ForParameter("passwd")]
            string password = null
        ) => throw forbidCallingDirectly;


        [Put("/api/v2.1/shared-repos/{repoId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("share_type", "public")]
        public bool ShareExistedRepoToPublic(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForParameter]
            string permission
        ) => throw forbidCallingDirectly;

        [Delete("/api/v2.1/shared-repos/{repoId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("share_type", "public")]
        public bool RemoveRepoFromPublic(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId
        ) => throw forbidCallingDirectly;

        [Post("/api/v2.1/repos/batch/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("share_type", "user")]
        [ForParameter("operation", "share")]
        public BatchShareRepoToUserResult BatchShareRepoToUser(
            [ForHeader]
            string accessToken,
            [ForParameter("username")]
            string email,
            [ForParameter("repo_id")]
            string[] repoIds,
            [ForParameter]
            string permission
        ) => throw forbidCallingDirectly;



        [Post("/api/v2.1/repos/batch/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("share_type", "group")]
        [ForParameter("operation", "share")]
        public BatchShareRepoToGroupResult BatchShareRepoToGroup(
            [ForHeader]
            string accessToken,
            [ForParameter("group_id")]
            int groupId,
            [ForParameter("repo_id")]
            string[] repoIds,
            [ForParameter]
            string permission
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/shared-folders/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<SharedFolderInfo> ListSharedFolders(
            [ForHeader]
            string accessToken
        ) => throw forbidCallingDirectly;

        [Put("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("share_type", "user")]
        public ShareToUserResult ShareFolderToUser(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString]
            string path,
            [ForParameter("username")]
            string email,
            [ForParameter]
            string permssion
        ) => throw forbidCallingDirectly;

        [Put("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForParameter("share_type", "group")]
        public ShareToGroupResult ShareFolderToGroup(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString]
            string path,
            [ForParameter("group_id")]
            int groupId,
            [ForParameter]
            string permssion
        ) => throw forbidCallingDirectly;

        [Post("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("share_type", "user")]
        [Destructure("success")]
        public bool UpdateUserPermissionOfSharedFolder(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString]
            string path,
            [ForQueryString("username")]
            string email,
            [ForParameter]
            string permission
        ) => throw forbidCallingDirectly;
        [Post("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("share_type", "group")]
        [Destructure("success")]
        public bool UpdateGroupPermissionOfSharedFolder(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString]
            string path,
            [ForQueryString("group_id")]
            int groupId,
            [ForParameter]
            string permission
        ) => throw forbidCallingDirectly;

        [Delete("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("share_type", "user")]
        [Destructure("success")]
        public bool RemoveUserFromSharedFolder(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString("p")]
            string path,
            [ForQueryString("username")]
            string email
        ) => throw forbidCallingDirectly;

        [Delete("/api2/repos/{repoId}/dir/shared_items/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("share_type", "group")]
        [Destructure("success")]
        public bool RemoveGroupFromSharedFolder(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string repoId,
            [ForQueryString]
            int groupId,
            [ForQueryString]
            string path
        ) => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{
    public class SharedUserInfoItem
    {
        [JsonPropertyName("nickname")]
        public string NickName { get; set; }
        [JsonPropertyName("name")]
        public string UserName { get; set; }
    }
    public class SharedUserInfo
    {
        [JsonPropertyName("user_info")]
        public SharedUserInfoItem User { get; set; }
        [JsonPropertyName("share_type")]
        public string ShareType { get; set; }
        [JsonPropertyName("permission")]
        public string Permission { get; set; }
    }
    public class SharedGroupInfoItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    public class SharedGroupInfo
    {
        [JsonPropertyName("group_info")]
        public SharedGroupInfoItem Group { get; set; }
        [JsonPropertyName("share_type")]
        public string ShareType { get; set; }
        [JsonPropertyName("permission")]
        public string Permission { get; set; }
    }

    public class SharedSelfInfo
    {
        [JsonPropertyName("user")]
        public string FromUserName { get; set; }
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("share_type")]
        public string ShareType { get; set; }
        [JsonPropertyName("permission")]
        public string Permission { get; set; }
        [JsonPropertyName("encrypted")]
        public bool Encrypted { get; set; }
        [JsonPropertyName("last_modified")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime LastModifiedTime { get; set; }
        [JsonPropertyName("repo_desc")]
        public string RepoDescription { get; set; }
        [JsonPropertyName("repo_name")]
        public string RepoName { get; set; }
        [JsonPropertyName("enc_version")]
        public int? EncVersion { get; set; }
        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }
    }

    public class ShareToUserResult
    {
        [JsonPropertyName("failed")]
        public IEnumerable<ShareToUserFailedItem> FailedItems { get; set; }
        [JsonPropertyName("success")]
        public IEnumerable<SharedUserInfo> SuccessItems { get; set; }
    }

    public class ShareToGroupResult
    {
        [JsonPropertyName("failed")]
        public IEnumerable<ShareToUserFailedItem> FailedItems { get; set; }
        [JsonPropertyName("success")]
        public IEnumerable<SharedGroupInfo> SuccessItems { get; set; }
    }

    public class ShareToUserFailedItem
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("error_msg")]
        public string ErrorMessage { get; set; }
    }

    public class BatchShareFailedItem
    {
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("error_msg")]
        public string ErrorMessage { get; set; }
    }

    public class BatchShareToUserSuccessItem
    {
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("permission")]
        public string Permission { get; set; }
    }
    public class BatchShareToGroupSuccessItem
    {
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("group_id")]
        public string GroupId { get; set; }
        [JsonPropertyName("group_name")]
        public string GroupName { get; set; }
        [JsonPropertyName("permission")]
        public string Permission { get; set; }
    }
    public class BatchShareRepoToUserResult
    {
        [JsonPropertyName("failed")]
        public IEnumerable<BatchShareFailedItem> FailedItems { get; set; }
        [JsonPropertyName("success")]
        public IEnumerable<BatchShareToUserSuccessItem> SuccessfulItems { get; set; }
    }
    public class BatchShareRepoToGroupResult
    {
        [JsonPropertyName("failed")]
        public IEnumerable<BatchShareFailedItem> FailedItems { get; set; }
        [JsonPropertyName("success")]
        public IEnumerable<BatchShareToGroupSuccessItem> SuccessfulItems { get; set; }
    }

    public class SharedFolderInfo
    {
        [JsonPropertyName("repo_id")]
        public string RepoId { get; set; }
        [JsonPropertyName("share_permission")]
        public string Permssion { get; set; }
        [JsonPropertyName("share_type")]
        public string ShareType { get; set; }
        [JsonPropertyName("folder_name")]
        public string FolderName { get; set; }
        [JsonPropertyName("path")]
        public string Path { get; set; }
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("user_email")]
        public string UserEmail { get; set; }
        [JsonPropertyName("contact_email")]
        public string UserContactEmail { get; set; }
        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }
        [JsonPropertyName("group_name")]
        public string GroupName { get; set; }
    }
}