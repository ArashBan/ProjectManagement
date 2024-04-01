using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.DataLayer.DTOs.Student;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IStudentService : IAsyncDisposable
    {
        Task<OperationResult> RegisterStudent(StudentDto student);
        Task<OperationResult> EditStudent(StudentDto editedStudent);
        Task<OperationResult> DeleteStudent(int studentId);
        Task AssignEnrollment(int studentId, List<StudentCourse> courses);
        Task<StudentDto> GetStudentByNationalCode(string nationalCode);
        Task<StudentDto> GetStudentByUserId(int userId);
        Task<List<StudentDto>> SearchStudent(string value);
        Task<List<RequestProjectDto>> GetStudentsProjectRequests(int studentId);
        Task<List<InternshipDto>> GetStudentsInternshipRequests(int studentId);
        Task<List<StudentDto>> GetAllStudents();
        Task<bool> HasCourse(int courseId, int studentId);
    }    
}
