using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Common;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface INewsService : IAsyncDisposable
    {
        Task<OperationResult> AddNews(NewsDto newsDto);
        Task<OperationResult> EditNews(NewsDto editedNews);
        Task<NewsDto> GetNewsById(int newsId);
        Task<OperationResult> DeleteNews(int newsId);
        Task<List<NewsDto>> GetAllNews();
        Task<List<NewsDto>> GetLastFive();
        Task<List<NewsDto>> GetLastThree();

    }
}
