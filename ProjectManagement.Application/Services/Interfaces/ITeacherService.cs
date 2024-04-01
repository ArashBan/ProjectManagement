using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.DataLayer.DTOs.Student;
using ProjectManagement.DataLayer.DTOs.Teacher;
using ProjectManagement.DataLayer.Entities.Courses;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface ITeacherService : IAsyncDisposable
    {
        Task<OperationResult> AddTeacher(TeacherDto teacher);
        Task<OperationResult> EditTeacher(TeacherDto editedTeacher);
        Task<TeacherDto> GetTeacherById(int teacherId);
        Task<OperationResult> DeleteTeacher(int teacherId);
        Task<List<ComboBoxSelectViewModel>> GetTeacherList(bool isProject);
        Task<List<TeacherDto>> SearchTeacher(string value);
        Task<TeacherDto> GetTeacherByUsername(string username);
        Task<List<RequestProjectDto>> GetProjectRequests(int teacherId);
        Task ChangeProjectRequestSituation(AcceptSituation situation, string feedback, int projectRequestId, int teacherId);
        Task<bool> CheckIfParent(int teacherId);
        Task<List<TeacherDto>> GetAllTeachers();
        Task<List<TeacherDto>> GetParentsList();
        Task<List<ProjectProgressDto>> GetProjectProgressList(int teacherId);
        Task<List<InternshipReportDto>> GetInternshipReportList(int teacherId);
        Task<OperationResult> ReadProjectProgress(int projectProgressId, string feedback);
        Task<OperationResult> ReadInternshipReport(int internshipReportId, string feedback);
        Task<List<InternshipDto>> GetInternshipRequests(int teacherId);
        Task ChangeInternshipRequestSituation(AcceptSituation situation, string feedback, int internshipId, int teacherId);
        Task<TeacherDto> GetTeacherByUserId(int userId);
        Task<TeacherStatsDto> GetTeacherStatsByTeacherId(int teacherId);
        Task<List<ProjectDefenseRequestDto>> GetTeacherDefenseRequests(int teacherId);
        Task<OperationResult> ChangeDefenseState(ProjectDefenseRequestDto defenseRequest, int defenseRequestId);
    }
}