using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Extensions;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Repository;

namespace ProjectManagement.Application.Services.Implementations
{
    public class ProblemService : IProblemService
    {
        private readonly IGenericRepository<Problem> _problemRepository;

        public ProblemService(IGenericRepository<Problem> problemRepository)
        {
            _problemRepository = problemRepository;
        }


        public async Task<OperationResult> AddQuestion(ProblemDto problemDto)
        {
            var problem = new Problem
            {
                Question = problemDto.Question,
                Answer = problemDto.Answer,
                Type = problemDto.Type
            };

            await _problemRepository.AddEntity(problem);
            await _problemRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<OperationResult> DeleteQuestion(int problemId)
        {
            await _problemRepository.DeleteEntity(problemId);
            await _problemRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async ValueTask DisposeAsync()
        {
            if (_problemRepository != null)
                await _problemRepository.DisposeAsync();
        }

        public async Task<OperationResult> EditQuestion(ProblemDto problemDto)
        {
            var problem = await _problemRepository.GetEntityById(problemDto.Id);

            problem.Question = problemDto.Question;
            problem.Answer = problemDto.Answer;
            problem.Type = problemDto.Type;

            await _problemRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<ProblemDto> GetQuestionById(int questionId)
        {
            var question = await _problemRepository.GetEntityById(questionId);

            return new ProblemDto
            {
                Answer = question.Answer,
                Id = question.Id,
                Question = question.Question,
                Type = question.Type
            };
        }

        public async Task<List<ProblemDto>> GetQuestionsList()
        {
            return await _problemRepository.GetQuery()
                .Select(x => new ProblemDto
                {
                    Id = x.Id,
                    Answer = x.Answer,
                    Question = x.Question,
                    Type = x.Type,
                    TypeName = x.Type.GetEnumName()
                }).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<List<ProblemDto>> SearchQuestions(string value)
        {
            var data = _problemRepository.GetQuery()
                .Select(x => new ProblemDto
                {
                    Id = x.Id,
                    Answer = x.Answer,
                    Question = x.Question,
                    Type = x.Type,
                    TypeName = x.Type.GetEnumName()
                });

            if (!string.IsNullOrWhiteSpace(value))
                data = data.Where(x => x.Question.Contains(value) || x.Answer.Contains(value));

            return await data.OrderByDescending(x => x.Id).ToListAsync();
        }
    }
}
