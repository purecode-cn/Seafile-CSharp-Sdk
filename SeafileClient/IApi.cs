using SeafileClient.Responses;

namespace SeafileClient
{
    public interface IApi : 
        IAccountApi, IServerApi, 
        IFileApi, IFileCommentApi, IFileHistoryApi, IFileTagApi, IFileUploadApi,
        IRepoApi, IDirectoryApi, ISharedLinkApi, IDeviceApi, IPublicUploadLinkApi, IStarItemApi,
        IInternalShareApi, IGroupApi,
        IUserApi
    {
        string ServiceRoot { get; set; }
    }


    public interface IFileSearchApi
    {
        PagedSearchResult SearchFiles(
            string accessToken,
            string query,
            int page = 1,
            int perPage = 25,
            string searchRepo = "all",
            string searchPath = null,
            string enableTypeFilter = null,
            string fileType = null,
            string extensions = null,
            bool withPermission = false,
            int startTime = 0,
            int endTime = 0,
            int minSize = 0,
            int maxSize = 0
        );
    }



}
