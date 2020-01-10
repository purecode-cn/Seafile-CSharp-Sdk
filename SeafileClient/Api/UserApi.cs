using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SeafileClient.Common.Attributes;
using SeafileClient.Responses;

namespace SeafileClient
{
    public interface IUserApi
    {
        /// <summary>
        /// List All Users' Info
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1-admin/accounts.md#user-content-List%20All%20Users'%20Info">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <returns></returns>
        PagedUsers AdminListUsers(string accessToken, int page, int perPage);

        /// <summary>
        /// Search Users
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1-admin/accounts.md#user-content-Search%20User">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<User> AdminSearchUsers(string accessToken, string query);

        /// <summary>
        /// Get a User's Info
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1-admin/accounts.md#user-content-Get%20a%20User's%20Info">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        User AdminGetUser(string accessToken, string email);

        /// <summary>
        /// Add User
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1-admin/accounts.md#user-content-Add%20User">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="isStaff"></param>
        /// <param name="isActive"></param>
        /// <param name="role"></param>
        /// <param name="name"></param>
        /// <param name="loginId"></param>
        /// <param name="contactEmail"></param>
        /// <param name="referencId"></param>
        /// <param name="department"></param>
        /// <param name="quotaTotal"></param>
        /// <returns></returns>
        User AdminCreateUser(string accessToken, string email, string password, bool? isStaff = null, bool? isActive = null, string role = null, string name = null, string loginId = null, string contactEmail = null, string referencId = null, string department = null, long? quotaTotal = null);

        /// <summary>
        /// Update User Info
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1-admin/accounts.md#user-content-Update%20User%20Info">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="isStaff"></param>
        /// <param name="isActive"></param>
        /// <param name="role"></param>
        /// <param name="name"></param>
        /// <param name="loginId"></param>
        /// <param name="contactEmail"></param>
        /// <param name="referencId"></param>
        /// <param name="department"></param>
        /// <param name="quotaTotal"></param>
        /// <returns></returns>
        User AdminUpdateUser(string accessToken, string email, string password = null, bool? isStaff = null, bool? isActive = null, string role = null, string name = null, string loginId = null, string contactEmail = null, string referencId = null, string department = null, long? quotaTotal = null);

        /// <summary>
        /// Delete User
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1-admin/accounts.md#user-content-Delete%20User">Delete User</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool AdminDeleteUser(string accessToken, string email);

        /// <summary>
        /// Migrate Account
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1-admin/accounts.md#user-content-Migrate%20Account">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="email"></param>
        /// <param name="toUserEmail"></param>
        /// <returns></returns>
        bool AdminMigrateUser(string accessToken, string email, string toUserEmail);
    }
    public partial class Api
    {
        [Get("/api/v2.1/admin/users/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public PagedUsers AdminListUsers(
            [ForHeader]
            string accessToken,
            [ForQueryString]
            int page,
            [ForQueryString("per_page")]
            int perPage
        ) => throw forbidCallingDirectly;


        [Get("/api/v2.1/admin/search-user/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<User> AdminSearchUsers(
            [ForHeader]
            string accessToken,
            [ForQueryString]
            string query
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/admin/users/{email}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public User AdminGetUser(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string email
        ) => throw forbidCallingDirectly;

        [Post("/api/v2.1/admin/users/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public User AdminCreateUser(
            [ForHeader]
            string accessToken,
            [ForParameter]
            string email,
            [ForParameter]
            string password,
            [ForParameter("is_staff")]
            bool? isStaff = false,
            [ForParameter("is_active")]
            bool? isActive = true,
            [ForParameter]
            string role = null,
            [ForParameter]
            string name = null,
            [ForParameter("login_id")]
            string loginId = null,
            [ForParameter("contact_email")]
            string contactEmail = null,
            [ForParameter("reference_id")]
            string referencId = null,
            [ForParameter]
            string department = null,
            [ForParameter("quota_total")]
            long? quotaTotal = null
        ) => throw forbidCallingDirectly;

        [Put("/api/v2.1/admin/users/{email}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public User AdminUpdateUser(
            [ForHeader]
            string accessToken,
            [ForParameter]
            string email,
            [ForParameter]
            string password = null,
            [ForParameter("is_staff")]
            bool? isStaff = false,
            [ForParameter("is_active")]
            bool? isActive = true,
            [ForParameter]
            string role = null,
            [ForParameter]
            string name = null,
            [ForParameter("login_id")]
            string loginId = null,
            [ForParameter("contact_email")]
            string contactEmail = null,
            [ForParameter("reference_id")]
            string referencId = null,
            [ForParameter]
            string department = null,
            [ForParameter("quota_total")]
            long? quotaTotal = null
        ) => throw forbidCallingDirectly;

        [Delete("/api/v2.1/admin/users/{email}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("success")]
        public bool AdminDeleteUser(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string email
        ) => throw forbidCallingDirectly;


        [Post("/api/v2.1/admin/users/{email}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public bool AdminMigrateUser(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string email,
            [ForParameter("to_user")]
            string toUserEmail
        )=> throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{
    public class PagedUsers
    {
        [JsonPropertyName("available_roles")]
        public string [] Roles { get; set; }
        [JsonPropertyName("page_info")]
        public PageInfo PageInfo { get; set; }
        [JsonPropertyName("data")]
        public IEnumerable<User> Items { get; set; }
    }

    public class PageInfo
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }
        [JsonPropertyName("has_next_page")]
        public bool HasNextPage { get; set; }
    }

    public class User
    {
        [JsonPropertyName("login_id")]
        public string LoginId { get; set; }
        [JsonPropertyName("quota_usage")]
        public long QuotaUsage { get; set; }
        [JsonPropertyName("last_login")]
        public DateTime LastLoginTime { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("create_time")]
        public DateTime CreatedTime { get; set; }
        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }
        [JsonPropertyName("is_staff")]
        public bool IsStaff { get; set; }
        [JsonPropertyName("contact_email")]
        public string ContactEmail { get; set; }
        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }
        [JsonPropertyName("department")]
        public string Department { get; set; }
        [JsonPropertyName("quota_total")]
        public long QuotaTotal { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("has_default_device")]
        public bool HasDefaultDevice { get; set; }
        [JsonPropertyName("is_force_2fa")]
        public bool IsForceTwoFactor { get; set; }
    }
}
