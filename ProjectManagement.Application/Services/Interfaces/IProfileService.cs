using ProjectManagement.DataLayer.DTOs.Common;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IProfileService : IAsyncDisposable
    {
        Task<StudentProfileDto> GetStudentProfile(int userId);
        Task<TeacherProfileDto> GetTeacherProfile(int userId);
    }
}
