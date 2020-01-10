using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeafileClient.Common.Attributes;
using SeafileClient.Common.Converters;
using SeafileClient.Responses;

namespace SeafileClient
{
    public interface IGroupApi
    {
        /// <summary>
        /// List Groups
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-List%20Groups">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        IEnumerable<Group> ListGroups(string accessToken);
        /// <summary>
        /// Add a Group
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Add%20a%20Group">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        GroupDetail CreateGroup(string accessToken, string name);
        /// <summary>
        /// Get Info of a Group
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Get%20Info%20of%20a%20Group">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        GroupDetail GetGroup(string accessToken, int groupId);
        /// <summary>
        /// Rename a Group
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Rename%20a%20Group">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        GroupDetail RenameGroup(string accessToken, int groupId, string newName);
        /// <summary>
        /// Transfer a Group
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Transfer%20a%20Group">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <param name="newOwnerEmail"></param>
        /// <returns></returns>
        GroupDetail TransferGroup(string accessToken, int groupId, string newOwnerEmail);
        /// <summary>
        /// Delete a Group
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Delete%20a%20Group">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        bool DeleteGroup(string accessToken, int groupId);
        /// <summary>
        /// List All Group Members
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-List%20All%20Group%20Members">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IEnumerable<GroupMember> ListGroupMembers(string accessToken, int groupId);
        /// <summary>
        /// Add a Group Member
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Add%20a%20Group%20Member">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        GroupMember AddGroupMember(string accessToken, int groupId, string email);
        /// <summary>
        /// Bulk Add Group Members
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Bulk%20Add%20Group%20Members">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <param name="emails"></param>
        /// <returns></returns>
        BatchGroupAddMembersResult BulkAddGroupMembers(string accessToken, int groupId, IEnumerable<string> emails);
        /// <summary>
        /// Get Info of a Group Member
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Get%20Info%20of%20a%20Group%20Member">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        GroupMember GetGroupMember(string accessToken, int groupId, string email);
        /// <summary>
        /// Toggle a Group Admin
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Set%20a%20Group%20Admin">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <param name="email"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        GroupMember ToggleGroupAdmin(string accessToken, int groupId, string email, bool isAdmin);
        /// <summary>
        /// Delete a Group Member
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Delete%20a%20Group%20Member">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool RemoveGroupMember(string accessToken, int groupId, string email);
        /// <summary>
        /// Delete a Group Member
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-Delete%20a%20Group%20Member">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IEnumerable<Repo> ListGroupRepos(string accessToken, int groupId);
        /// <summary>
        /// List All Group Administrators
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/groups.md#user-content-List%20All%20Group%20Members">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IEnumerable<GroupMember> ListGroupAdministrators(string accessToken, int groupId);
    }

    public partial class Api
    {
        [Get("/api2/groups/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("groups")]
        public IEnumerable<Group> ListGroups(
            [ForHeader]
            string accessToken
        ) => throw forbidCallingDirectly;
        [Post("/api/v2.1/groups/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public GroupDetail CreateGroup(
            [ForHeader]
            string accessToken,
            [ForParameter]
            string name
        ) => throw forbidCallingDirectly;
        [Get("/api/v2.1/groups/{groupId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public GroupDetail GetGroup(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId
        ) => throw forbidCallingDirectly;
        [Put("/api/v2.1/groups/{groupId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public GroupDetail TransferGroup(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId,
            [ForParameter("owner")]
            string newOwnerEmail
        ) => throw forbidCallingDirectly;
        [Put("/api/v2.1/groups/{groupId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public GroupDetail RenameGroup(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId,
            [ForParameter("name")]
            string newName
        ) => throw forbidCallingDirectly;
        [Delete("/api/v2.1/groups/{groupId}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool DeleteGroup(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId
        ) => throw forbidCallingDirectly;

        [Delete("/api/v2.1/groups/{groupId}/members/{memberEmail}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool RemoveGroupMember(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId,
            [ForUrlSegment]
            string email
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/groups/{groupId}/members/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<GroupMember> ListGroupMembers(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/groups/{groupId}/members/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [ForQueryString("is_admin", true)]
        public IEnumerable<GroupMember> ListGroupAdministrators(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId
        ) => throw forbidCallingDirectly;
        [Post("/api/v2.1/groups/{groupId}/members/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public GroupMember AddGroupMember(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId,
            [ForParameter]
            string email
        ) => throw forbidCallingDirectly;
        [Post("/api/v2.1/groups/{groupId}/members/bulk/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public BatchGroupAddMembersResult BulkAddGroupMembers(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId,
            [ForParameter(ConverterType = typeof(JoinStringsConverter))]
            IEnumerable<string> emails
        ) => throw forbidCallingDirectly;
        [Get("/api/v2.1/groups/{groupId}/members/{email}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public GroupMember GetGroupMember(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId,
            [ForUrlSegment]
            string email
        ) => throw forbidCallingDirectly;
        [Put("/api/v2.1/groups/{groupId}/members/{email}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public GroupMember ToggleGroupAdmin(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId,
            [ForUrlSegment]
            string email, 
            [ForParameter("is_admin")]
            bool isAdmin
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/groups/{groupId}/libraries/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<Repo> ListGroupRepos(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            int groupId
        ) => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{
    public class Group
    {
        [JsonPropertyName("ctime")]
        public DateTime CreatedTime { get; set; }
        [JsonPropertyName("creator")]
        public string Creator { get; set; }
        [JsonPropertyName("msgnum")]
        public int MessageCount { get; set; }
        [JsonPropertyName("mtime")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime ModifiedTime { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class GroupDetail
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("owner")]
        public string Owner { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedTime { get; set; }
        [JsonPropertyName("admins")]
        public IEnumerable<string> Administrators { get; set; }
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }

    public class GroupMember
    {
        [JsonPropertyName("login_id")]
        public string LoginId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonPropertyName("is_admin")]
        public bool IsGroupAdmin { get; set; }
        [JsonPropertyName("contact_email")]
        public string ContactEmail { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class GroupAddMemberFailedItem
    {
        [JsonPropertyName("error_msg")]
        public string ErrorMessage { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class BatchGroupAddMembersResult
    {
        [JsonPropertyName("failed")]
        public IEnumerable<GroupAddMemberFailedItem> Failed { get; set; }
        [JsonPropertyName("success")]
        public IEnumerable<GroupMember> Success { get; set; }
    }
}
