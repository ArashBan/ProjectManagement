using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Repository;

namespace ProjectManagement.Application.Services.Implementations
{
    public class NewsService : INewsService
    {
        private readonly IGenericRepository<News> _newsRepository;

        public NewsService(IGenericRepository<News> newsRepository)
        {
            _newsRepository = newsRepository;
        }


        public async Task<OperationResult> AddNews(NewsDto newsDto)
        {
            var news = new News
            {
                Title = newsDto.Title,
                Body = newsDto.Body,
                Type = newsDto.Type,
                TeacherId = newsDto.TeacherId,
                Importance = newsDto.Importance
            };

            await _newsRepository.AddEntity(news);
            await _newsRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<OperationResult> DeleteNews(int newsId)
        {
            await _newsRepository.DeleteEntity(newsId);
            await _newsRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async ValueTask DisposeAsync()
        {
            if (_newsRepository != null)
                await _newsRepository.DisposeAsync();
        }

        public async Task<OperationResult> EditNews(NewsDto editedNews)
        {
            var news = await _newsRepository.GetEntityById(editedNews.NewsId);

            news.Title = editedNews.Title;
            news.Body = editedNews.Body;
            news.Type = editedNews.Type;
            news.TeacherId = editedNews.TeacherId;
            news.Importance = editedNews.Importance;

            await _newsRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<List<NewsDto>> GetAllNews()
        {
            return await _newsRepository.GetQuery()
                .OrderByDescending(x => x.CreationDate)
                .Select(x => new NewsDto
                {
                    Body = x.Body,
                    TeacherId = x.TeacherId,
                    NewsId = x.Id,
                    Title = x.Title,
                    Type = x.Type,
                    Importance = x.Importance,
                    CreationDate = x.CreationDate.ToFarsi(),
                    TeacherFullName = $"{x.Teacher.Name} {x.Teacher.Family}"
                }).ToListAsync();
        }

        public async Task<List<NewsDto>> GetLastFive()
        {
            return await _newsRepository.GetQuery()
                .Include(x => x.Teacher)
                .Select(x => new NewsDto
                {
                    Body = x.Body,
                    TeacherId = x.TeacherId,
                    NewsId = x.Id,
                    Title = x.Title,
                    Type = x.Type,
                    Importance = x.Importance,
                    CreationDate = x.CreationDate.ToFarsi(),
                    TeacherFullName = $"{x.Teacher.Name} {x.Teacher.Family}"
                }).OrderByDescending(x => x.NewsId).Take(5).ToListAsync();
        }

        public async Task<List<NewsDto>> GetLastThree()
        {
            return await _newsRepository.GetQuery()
                .Include(x => x.Teacher)
                .Select(x => new NewsDto
                {
                    Body = Tools.StripHTML(x.Body).LimitCharacters(290),
                    TeacherId = x.TeacherId,
                    NewsId = x.Id,
                    Title = x.Title,
                    Type = x.Type,
                    Importance = x.Importance,
                    CreationDate = x.CreationDate.ToFarsi(),
                    TeacherFullName = $"{x.Teacher.Name} {x.Teacher.Family}"
                }).OrderByDescending(x => x.NewsId).Take(3).ToListAsync();
        }

        public async Task<NewsDto> GetNewsById(int newsId)
        {
            var news = await _newsRepository.GetEntityById(newsId);

            return new NewsDto
            {
                Body = news.Body,
                TeacherId = news.TeacherId,
                Title = news.Title,
                Type = news.Type,
                NewsId = news.Id,
                Importance = news.Importance,
            };
        }
    }
}
