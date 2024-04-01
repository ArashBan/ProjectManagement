using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Course;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IInternshipService : IAsyncDisposable
    {
        Task<OperationResult> RequestInternship(InternshipDto request);
        Task<OperationResult> EditInternshipRequest(InternshipDto project);
        Task<InternshipDto> GetInternshipById(int internshipId);
        Task<OperationResult> RemoveInternshipRequest(int requestId);
        Task<List<InternshipDto>> SearchInternshipRequests(InternshipRequestSearchModel model);
        Task<OperationResult> SendWeeklyReport(InternshipReportDto progress, int studentId);
        Task<List<InternshipReportDto>> GetInternshipReportsList(int studentId);
        Task<InternshipDto> GetConfirmedInternshipByStudentId(int studentId);
        Task<string> GetAttendanceDaysByStudentId(int studentId);
    }
}
