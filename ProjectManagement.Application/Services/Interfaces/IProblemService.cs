using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Common;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IProblemService : IAsyncDisposable
    {
        Task<OperationResult> AddQuestion(ProblemDto problemDto);
        Task<OperationResult> EditQuestion(ProblemDto problemDto);
        Task<ProblemDto> GetQuestionById(int questionId);
        Task<List<ProblemDto>> GetQuestionsList();
        Task<List<ProblemDto>> SearchQuestions(string value);
        Task<OperationResult> DeleteQuestion(int problemId);
    }
}
