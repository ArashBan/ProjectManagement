using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Account;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.DataLayer.DTOs.Student;
using ProjectManagement.DataLayer.Entities.Account;
using ProjectManagement.DataLayer.Entities.Courses;
using ProjectManagement.DataLayer.Entities.People;
using ProjectManagement.DataLayer.Repository;

namespace ProjectManagement.Application.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IUserService _userService;
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Enrollment> _enrollmentRepository;
        private readonly IGenericRepository<ProjectRequest> _projectRequestRepository;
        private readonly IGenericRepository<InternshipRequest> _internshipRequestRepository;

        public StudentService(IGenericRepository<Student> studentRepository, IGenericRepository<Enrollment> enrollmentRepository, IGenericRepository<ProjectRequest> projectRequestRepository, IGenericRepository<User> userRepository, IUserService userService, IGenericRepository<InternshipRequest> internshipRequestRepository)
        {
            _userService = userService;
            _studentRepository = studentRepository;
            _enrollmentRepository = enrollmentRepository;
            _projectRequestRepository = projectRequestRepository;
            _internshipRequestRepository = internshipRequestRepository;
        }


        public async Task<OperationResult> RegisterStudent(StudentDto student)
        {
            if (await _studentRepository.GetQuery()
                .AnyAsync(x => x.NationalCode == student.NationalCode || x.StudentCode == student.StudentCode || x.PhoneNumber == student.PhoneNumber))
                return new OperationResult { IsSucceed = false, Message = "یکی از مقادیر کد ملی، کد دانشجویی و یا شماره همراه از قبل ثبت شده است" };

            var userId = await _userService.AddUser(new UserDto
            {
                IsStudent = true,
                Username = student.StudentCode,
                Password = student.NationalCode,
                RoleId = 1
            });

            var newStudent = new Student
            {
                Name = student.Name,
                Family = student.Family,
                Field = student.Field,
                NationalCode = student.NationalCode,
                PhoneNumber = student.PhoneNumber,
                StudentCode = student.StudentCode,
                Semester = student.Semester,
                Type = student.Type,
                UserId = userId
            };

            await _studentRepository.AddEntity(newStudent);
            await _studentRepository.SaveChanges();

            await AssignEnrollment(newStudent.Id, student.Courses);
            await _enrollmentRepository.SaveChanges();

            return new OperationResult
            {
                IsSucceed = true
            };
        }

        public async Task AssignEnrollment(int studentId, List<StudentCourse> courses)
        {
            var enrollments = new List<Enrollment>();

            foreach (var item in courses)
            {
                enrollments.Add(new Enrollment
                {
                    CourseId = item.CourseId,
                    StudentId = studentId,
                    TeacherId = item.TeacherId
                });
            }

            await _enrollmentRepository.AddRangeEntity(enrollments);
        }

        public async ValueTask DisposeAsync()
        {
            if (_studentRepository != null)
                await _studentRepository.DisposeAsync();
            if (_enrollmentRepository != null)
                await _enrollmentRepository.DisposeAsync();
            if (_userService != null)
                await _userService.DisposeAsync();
            if (_projectRequestRepository != null)
                await _projectRequestRepository.DisposeAsync();
        }

        public async Task<StudentDto> GetStudentByNationalCode(string nationalCode)
        {
            return await _studentRepository.GetQuery()
                .Include(x => x.Enrollments)
                .Select(x => new StudentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    NationalCode = x.NationalCode,
                    Family = x.Family,
                    PhoneNumber = x.PhoneNumber,
                    Field = x.Field,
                    StudentCode = x.StudentCode,
                    Type = x.Type,
                    Semester = x.Semester,
                    Courses = MapStudentCourses(x.Enrollments)
                }).FirstOrDefaultAsync(x => x.NationalCode == nationalCode);
        }

        private static List<StudentCourse> MapStudentCourses(List<Enrollment> data)
        {
            return data.Select(x => new StudentCourse
            {
                CourseId = x.CourseId,
                TeacherId = x.TeacherId
            }).ToList();
        }

        public async Task<List<StudentDto>> SearchStudent(string value)
        {
            return await _studentRepository.GetQuery()
                .Where(x => !x.IsDeleted).Where(x => x.Name.Contains(value) ||
                x.Family.Contains(value) || x.PhoneNumber.Contains(value) || x.NationalCode.Contains(value)
                || x.StudentCode.Contains(value) || x.Field.Contains(value) ||
                x.Semester.Contains(value) || x.Type.Contains(value)).Select(x => new StudentDto
                {
                    Name = x.Name,
                    Family = x.Family,
                    Field = x.Field,
                    NationalCode = x.NationalCode,
                    PhoneNumber = x.PhoneNumber,
                    Semester = x.Semester,
                    Type = x.Type,
                    StudentCode = x.StudentCode,
                    Id = x.Id,
                    CourseNames = GetCourseNames(x.Id, x.Enrollments)
                }).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<List<RequestProjectDto>> GetStudentsProjectRequests(int studentId)
        {
            return await _projectRequestRepository.GetQuery()
                .Where(x => x.StudentId == studentId).OrderByDescending(x => x.CreationDate).Select(x => new RequestProjectDto
                {
                    Title = x.Title,
                    Platform = x.Platform,
                    ProjectType = x.ProjectType,
                    Puprpose = x.Puprpose,
                    Situation = x.Situation,
                    TeammateName = x.TeammateName,
                    TeammateStudentCode = x.TeammateStudentCode,
                    Description = x.Description,
                    CreationDate = x.CreationDate.ToFarsi(),
                    RequestProjectId = x.Id
                }).ToListAsync();
        }

        public async Task<StudentDto> GetStudentByUserId(int userId)
        {
            return await _studentRepository.GetQuery()
                .Select(x => new StudentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    NationalCode = x.NationalCode,
                    Family = x.Family,
                    PhoneNumber = x.PhoneNumber,
                    Field = x.Field,
                    StudentCode = x.StudentCode,
                    Type = x.Type,
                    Semester = x.Semester,
                    UserId = x.UserId
                }).FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<StudentDto>> GetAllStudents()
        {
            return await _studentRepository.GetQuery()
                .Include(x => x.Enrollments)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreationDate)
                .Select(x => new StudentDto
                {
                    Name = x.Name,
                    Family = x.Family,
                    Field = x.Field,
                    NationalCode = x.NationalCode,
                    PhoneNumber = x.PhoneNumber,
                    Semester = x.Semester,
                    Type = x.Type,
                    StudentCode = x.StudentCode,
                    Id = x.Id,
                    CourseNames = GetCourseNames(x.Id, x.Enrollments)
                }).ToListAsync();

        }

        public async Task<bool> HasCourse(int courseId, int studentId)
        {
            return await _enrollmentRepository.GetQuery()
                .AnyAsync(x => x.StudentId == studentId && x.CourseId == courseId);
        }

        public async Task<List<InternshipDto>> GetStudentsInternshipRequests(int studentId)
        {
            return await _internshipRequestRepository.GetQuery()
                .Where(x => x.StudentId == studentId).OrderByDescending(x => x.CreationDate)
                .Select(x => new InternshipDto
                {
                    Title = x.Title,
                    Description = x.Description,
                    StudentId = x.StudentId,
                    Address = x.Address,
                    Feedback = x.Feedback,
                    PlaceName = x.PlaceName,
                    Situation = x.Situation,
                    SupervisorFullName = x.SupervisorFullName,
                    InternshipId = x.Id,
                    PlacePhoneNumber = x.PlacePhoneNumber,
                    DaysOfAttendance = x.DaysOfAttendance,
                    CreationDate = x.CreationDate.ToFarsi()
                }).ToListAsync();
        }

        public async Task<OperationResult> EditStudent(StudentDto editedStudent)
        {
            if (await _studentRepository.GetQuery()
                .AnyAsync(x => (x.PhoneNumber == editedStudent.PhoneNumber ||
                x.StudentCode == editedStudent.StudentCode ||
                x.NationalCode == editedStudent.NationalCode) && x.Id != editedStudent.Id))
                return new OperationResult { IsSucceed = false, Message = "یکی از مقادیر شماره تماس، کد ملی یا کد دانشجویی از قبل ثبت شده است" };

            var student = await _studentRepository.GetEntityById(editedStudent.Id);
            student.Name = editedStudent.Name;
            student.Family = editedStudent.Family;
            student.StudentCode = editedStudent.StudentCode;
            student.PhoneNumber = editedStudent.PhoneNumber;
            student.Field = editedStudent.Field;
            student.NationalCode = editedStudent.NationalCode;
            student.Semester = editedStudent.Semester;
            student.Type = editedStudent.Type;

            await _studentRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<OperationResult> DeleteStudent(int studentId)
        {
            await _studentRepository.DeleteEntity(studentId);
            await _studentRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        private List<StudentCourse> MapStudentCourses(int studentId, IEnumerable<Enrollment> data)
        {
            return data.Where(x => x.StudentId == studentId).Select(x => new StudentCourse
            {
                TeacherId = x.TeacherId,
                CourseId = x.CourseId
            }).ToList();
        }

        private static string GetCourseNames(int studentId, IEnumerable<Enrollment> source)
        {
            var data = source.Where(x => x.StudentId == studentId)
                .Select(x => new StudentCourse
                {
                    TeacherId = x.TeacherId,
                    CourseId = x.CourseId
                }).ToList();

            var result = "-";
            if (data.Any(x => x.CourseId == 1) && data.Any(x => x.CourseId == 2))
                result = "پروژه - کارآموزی";
            else if (data.Any(x => x.CourseId == 1))
                result = "پروژه";
            else if (data.Any(x => x.CourseId == 2))
                result = "کارآموزی";

            return result;
        }
    }
}