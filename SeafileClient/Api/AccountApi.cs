using SeafileClient.Common.Attributes;
using SeafileClient.Common.Converters;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SeafileClient
{
    public interface IAccountApi
    {
        /// <summary>
        /// Login with username and password
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/home.md#user-content-Quick%20Start">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Token</returns>
        string Login(string userName, string password);

        /// <summary>
        /// Login with two-factor  
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/home.md#user-content-Quick%20Start">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="otpToken"></param>
        /// <returns>Token</returns>
        string LoginWithOtpToken(string userName, string password, string otpToken);

        /// <summary>
        /// Check account info
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/account.md#user-content-Check%20Account%20Info">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken">Account access token</param>
        /// <returns>Account Info</returns>
        Account GetAccountInfo(string accessToken);

        /// <summary>
        /// Get Client Login URL
        /// 
        /// You can use this API to get a URL to login into the Web interface. The usage case is to provide the feature of "Visit web site" in the clients.
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/account.md#user-content-Get%20Client%20Login%20URL">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken">Account access token</param>
        /// <returns>Device access token</returns>
        string GetClientLoginUrl(string accessToken);

        /// <summary>
        /// Update User Avatar
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/avatars.md#user-content-Update%20User%20Avatar">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken">Account access token</param>
        /// <param name="avatar">Avatar file path</param>
        /// <returns>Device access token</returns>
        Avatar UpdateAvatar(string accessToken, string avatar, int avatarSize = 64);

        /// <summary>
        /// Get user avatar
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/avatars.md#user-content-Get%20User%20Avatar"/>Seafile Doc</para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="email"></param>
        /// <param name="avatarSize"></param>
        /// <returns></returns>
        UserAvatar GetUserAvatar(string accessToken, string email, int avatarSize = 64);

        /// <summary>
        /// Search users
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/user-search.md#user-content-Get%20User%20Avatar">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<SimpleUser> SearchUsers(string accessToken, string query);

        /// <summary>
        /// List user's activities
        /// <para>
        /// <see href="https://download.seafile.com/published/web-api/v2.1/activities.md#user-content-Get%20User%20Avatar">Seafile Doc</see>
        /// </para>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="avatarSize"></param>
        /// <returns></returns>
        IEnumerable<Activity> GetActivities(string accessToken, int page = 1, int perPage = 25, int avatarSize = 64);
    }

    public partial class Api
    {
        [Post("/api2/auth-token/")]
        [Destructure("token")]
        public string Login(
            [ForParameter("username")]
            string userName,
            [ForParameter]
            string password
        ) => throw forbidCallingDirectly;

        [Post("/api2/auth-token/")]
        [RequestHeader("X-SEAFILE-OTP", "{otpToken}")]
        [Destructure("token")]
        public string LoginWithOtpToken(
            [ForParameter("username")]
            string userName,
            [ForParameter]
            string password,
            [ForHeader]
            string otpToken
        ) => throw forbidCallingDirectly;

        [Get("/api2/account/info/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public Account GetAccountInfo(
            [ForHeader]
            string accessToken
        ) => throw forbidCallingDirectly;

        [Post("/api2/client-login/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("token")]
        public string GetClientLoginUrl(
            [ForHeader]
            string accessToken
        ) => throw forbidCallingDirectly;

        [Post("/api/v2.1/user-avatar/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public Avatar UpdateAvatar(
            [ForHeader]
            string accessToken,
            [ForParameter(IsFile = true)]
            string avatar,
            [ForQueryString("avatar_size")]
            int avatarSize = 64
        ) => throw forbidCallingDirectly;

        [Get("/api2/avatars/user/{email}/resized/{avatarSize}/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public UserAvatar GetUserAvatar(
            [ForHeader]
            string accessToken,
            [ForUrlSegment]
            string email,
            [ForUrlSegment]
            int avatarSize = 64
        ) => throw forbidCallingDirectly;

        [Get("/api2/search-user/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        public IEnumerable<SimpleUser> SearchUsers(
            [ForHeader]
            string accessToken,
            [ForQueryString("q")]
            string query
        ) => throw forbidCallingDirectly;

        [Get("/api/v2.1/activities/")]
        [RequestHeader("Authorization", "TOKEN {accessToken}")]
        [Destructure("events")]
        public IEnumerable<Activity> GetActivities(
            [ForHeader]
            string accessToken,
            [ForQueryString]
            int page = 1,
            [ForQueryString("per_page")]
            int perPage = 25,
            [ForQueryString("avatar_size")]
            int avatarSize = 72
        ) => throw forbidCallingDirectly;
    }
}

namespace SeafileClient.Responses
{
    public class Account
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("institution")]
        public string Institution { get; set; }

        [JsonPropertyName("is_staff")]
        public bool IsStaff { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("contact_email")]
        public string ContactEmail { get; set; }

        [JsonPropertyName("space_usage")]
        public string SpaceUsage { get; set; }

        [JsonPropertyName("usage")]
        public int Usage { get; set; }

        [JsonPropertyName("total")]
        public int Quota { get; set; }
    }

    public class Avatar
    {
        [JsonPropertyName("avatar_url")]
        public string Url { get; set; }
    }

    public class UserAvatar
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("mtime")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime ModifiedTime { get; set; }
    }

    public class SimpleUser
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("contact_email")]
        public string ContactEmail { get; set; }
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
