using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.DTOs.Course;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface ICourseService : IAsyncDisposable
    {
        Task<OperationResult> AddCourse(AddCourse course);
        Task<List<ComboBoxSelectViewModel>> GetCourseList();
        Task<OperationResult> RequestProject(RequestProjectDto project);
        Task<OperationResult> EditProjectRequest(RequestProjectDto project);
        Task<RequestProjectDto> GetProjectRequestById(int requestId);
        Task<OperationResult> RemoveProjectRequest(int requestId);
        Task<List<RequestProjectDto>> SearchProjectRequests(ProjectRequestSearchModel model);
        Task<OperationResult> AddProjectProgress(ProjectProgressDto progress, int studentId);
        Task<List<ProjectProgressDto>> GetProjectProgressList(int studentId);
        Task<RequestProjectDto> GetConfirmedProjectByStudentId(int studentId);
        Task<OperationResult> RequestProjectDefense(ProjectDefenseRequestDto defenseRequest);
        Task<List<ProjectDefenseRequestDto>> GetProjectDefenseRequestListByStudentId(int studentId);
    }
}
