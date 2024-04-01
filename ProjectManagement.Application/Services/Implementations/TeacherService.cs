using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Account;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.DataLayer.DTOs.Student;
using ProjectManagement.DataLayer.DTOs.Teacher;
using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Entities.Courses;
using ProjectManagement.DataLayer.Entities.People;
using ProjectManagement.DataLayer.Repository;

namespace ProjectManagement.Application.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<Enrollment> _enrollmentRepository;
        private readonly IGenericRepository<ProjectRequest> _projectRequestRepository;
        private readonly IGenericRepository<ProjectProgress> _projectProgressRepository;
        private readonly IGenericRepository<InternshipRequest> _internshipRequestRepository;
        private readonly IGenericRepository<InternshipReport> _internshipReportRepository;
        private readonly IGenericRepository<ProjectDefenseRequest> _projectDefenseRequest;

        public TeacherService(IGenericRepository<Teacher> teacherRepository, IUserService userService, IGenericRepository<ProjectRequest> projectRequestRepository, INotificationService notificationService, IGenericRepository<ProjectProgress> projectProgressRepository, IGenericRepository<Enrollment> enrollmentRepository, IGenericRepository<InternshipRequest> intenrshipRequestRepository, IGenericRepository<InternshipReport> internshipReportRepository, IGenericRepository<ProjectDefenseRequest> projectDefenseRequest)
        {
            _userService = userService;
            _teacherRepository = teacherRepository;
            _notificationService = notificationService;
            _enrollmentRepository = enrollmentRepository;
            _projectRequestRepository = projectRequestRepository;
            _projectProgressRepository = projectProgressRepository;
            _internshipRequestRepository = intenrshipRequestRepository;
            _internshipReportRepository = internshipReportRepository;
            _projectDefenseRequest = projectDefenseRequest;
        }


        public async Task<OperationResult> AddTeacher(TeacherDto teacher)
        {
            if (await _teacherRepository.GetQuery()
                .AnyAsync(x => x.NationalCode == teacher.NationalCode || x.PhoneNumber == teacher.PhoneNumber))
                return new OperationResult { IsSucceed = false, Message = "یکی از مقادیر کد ملی و یا شماره تماس از قبل ثبت شده است" };

            var userId = await _userService.AddUser(new UserDto
            {
                IsStudent = false,
                Username = teacher.Username,
                Password = teacher.Password,
                RoleId = 2
            });

            var newTeacher = new Teacher
            {
                Name = teacher.Name,
                Family = teacher.Family,
                NationalCode = teacher.NationalCode,
                Position = teacher.Position,
                ParentId = teacher.ParentId,
                UserId = userId,
                Internship = teacher.Internship,
                Project = teacher.Project,
                PhoneNumber = teacher.PhoneNumber
            };

            await _teacherRepository.AddEntity(newTeacher);
            await _teacherRepository.SaveChanges();

            return new OperationResult
            {
                IsSucceed = true
            };
        }

        public async ValueTask DisposeAsync()
        {
            if (_teacherRepository != null)
                await _teacherRepository.DisposeAsync();
            if (_userService != null)
                await _userService.DisposeAsync();
        }

        public async Task<List<ComboBoxSelectViewModel>> GetTeacherList(bool isProject)
        {
            return await _teacherRepository.GetQuery().Where(x => !x.IsDeleted)
                .Where(x => isProject ? x.Project : x.Internship)
                .Select(x => new ComboBoxSelectViewModel
                {
                    Id = x.Id,
                    Title = $"{x.Name} {x.Family}"
                }).ToListAsync();
        }

        public async Task<List<TeacherDto>> SearchTeacher(string value)
        {
            //var data = await _teacherRepository.GetQuery()
            //    .Where(m => m.GetType().GetProperties()
            //    .Any(x => x.GetValue(m, null) != null && x.GetValue(m, null).ToString()
            //    .Contains(value))).ToListAsync();

            var data = await _teacherRepository.GetQuery()
                .Where(x => !x.IsDeleted).Where(x => x.Name.Contains(value) ||
                x.Family.Contains(value) || x.PhoneNumber.Contains(value) || x.NationalCode.Contains(value))
                .Include(x => x.User)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return data.Select(x => new TeacherDto
            {
                Name = x.Name,
                Family = x.Family,
                NationalCode = x.NationalCode,
                PhoneNumber = x.PhoneNumber,
                Id = x.Id,
                Parent = GetParentFullName(data, x.ParentId),
                Username = x.User.Username,
                Password = x.User.Password,
                CourseNames = GetCourseNames(x.Id, x.Enrollments)
            }).ToList();
        }

        private static string GetCourseNames(int teacherId, IEnumerable<Enrollment> source)
        {
            var data = source.Where(x => x.TeacherId == teacherId)
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

        private static string GetParentFullName(List<Teacher> data, int id)
        {
            var result = data.FirstOrDefault(x => x.Id == id);

            return result == null ? "-" : $"{result.Name} {result.Family}";
        }

        public async Task<TeacherDto> GetTeacherByUsername(string username)
        {
            return await _teacherRepository.GetQuery()
                .Select(x => new TeacherDto
                {
                    Username = username,
                    NationalCode = x.NationalCode,
                    Id = x.Id,
                    PhoneNumber = x.PhoneNumber
                }).FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<List<RequestProjectDto>> GetProjectRequests(int teacherId)
        {
            var teacher = await _teacherRepository.GetEntityById(teacherId);
            var requests = await _projectRequestRepository.GetQuery()
               .Include(x => x.Student)
               .Include(x => x.Teacher)
               .ToListAsync();

            if (teacher.ParentId == 0)
            {
                requests = requests.Where(x => (x.TeacherId == teacherId) || (x.Teacher.ParentId == teacherId && (x.Situation == AcceptSituation.Accepted || x.Situation == AcceptSituation.Confirm))).ToList();
            }
            else
            {
                requests = requests.Where(x => x.TeacherId == teacherId).ToList();
            }

            return requests.Select(x => new RequestProjectDto
            {
                TeacherId = x.TeacherId,
                Title = x.Title,
                Situation = x.Situation,
                Platform = x.Platform,
                ProjectType = x.ProjectType,
                Puprpose = x.Puprpose,
                Description = x.Description,
                TeammateName = x.TeammateName,
                TeammateStudentCode = x.TeammateStudentCode,
                StudentId = x.StudentId,
                CreationDate = x.CreationDate.ToFarsi(),
                RequestProjectId = x.Id,
                StudentCode = x.Student.StudentCode,
                StudentFullName = $"{x.Student.Name} {x.Student.Family}",
                TeacherFullName = $"{x.Teacher.Name} {x.Teacher.Family}",
                Feedback = x.Feedback
            }).OrderBy(x => x.Situation).ToList();
        }

        public async Task ChangeProjectRequestSituation(AcceptSituation situation, string feedback, int projectRequestId, int teacherId)
        {
            var request = await _projectRequestRepository.GetQuery()
                .Include(x => x.Teacher)
                .Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.Id == projectRequestId);

            var isParent = await CheckIfParent(teacherId);
            var teacherPosition = isParent ? "مدیر گروه" : "استاد راهنما";

            if (isParent)
            {
                if (situation == AcceptSituation.Accepted)
                    request.ChangeSituation(AcceptSituation.Confirm);
                else
                    request.ChangeSituation(situation);
            }
            else
                request.ChangeSituation(situation);

            request.Feedback = feedback;

            await _projectRequestRepository.SaveChanges();

            var notification = new NotificationDto();

            switch (situation)
            {
                case AcceptSituation.UnderProgress:
                    notification.Title = $"درخواست پروژه شما توسط {teacherPosition} به وضعیت در انتظار بررسی تغییر پیدا کرد";
                    notification.Type = NotificationType.Warning;
                    break;
                case AcceptSituation.Accepted:
                    notification.Title = $"درخواست پروژه شما توسط {teacherPosition} تایید شد";
                    notification.Type = NotificationType.Success;
                    break;
                case AcceptSituation.Confirm:
                    notification.Title = $"درخواست پروژه شما توسط {teacherPosition} تایید شد";
                    notification.Type = NotificationType.Success;
                    break;
                case AcceptSituation.Rejected:
                    notification.Title = $"درخواست پروژه شما توسط {teacherPosition} رد شد";
                    notification.Type = NotificationType.Fail;
                    break;
            }

            notification.Message = feedback;
            notification.UserId = request.Student.UserId;

            await _notificationService.SendNotification(notification);
        }

        public async Task<bool> CheckIfParent(int teacherId)
        {
            var teacher = await _teacherRepository.GetEntityById(teacherId);

            return teacher.ParentId == 0;
        }

        public async Task<List<TeacherDto>> GetAllTeachers()
        {
            var data = await _teacherRepository.GetQuery()
                .Include(x => x.User)
                .Include(x => x.Enrollments)
                .OrderByDescending(x => x.CreationDate).ToListAsync();

            return data.Select(x => new TeacherDto
            {
                Id = x.Id,
                Name = x.Name,
                Family = x.Family,
                NationalCode = x.NationalCode,
                PhoneNumber = x.PhoneNumber,
                Parent = GetParentFullName(data, x.ParentId),
                Username = x.User.Username,
                Password = x.User.Password,
                CourseNames = GetCourseNames(x.Id, x.Enrollments)
            }).ToList();
        }

        public async Task<List<TeacherDto>> GetParentsList()
        {
            return await _teacherRepository.GetQuery()
                .Where(x => !x.IsDeleted && x.ParentId == 0).Select(x => new TeacherDto
                {
                    Name = x.Name,
                    Family = x.Family,
                    NationalCode = x.NationalCode,
                    PhoneNumber = x.PhoneNumber,
                    Id = x.Id,
                    FullName = $"{x.Name} {x.Family}"
                }).ToListAsync();
        }

        public async Task<List<ProjectProgressDto>> GetProjectProgressList(int teacherId)
        {
            var projects = await _projectRequestRepository.GetQuery()
                .Include(x => x.ProjectProgresses)
                .Include(x => x.Student)
                .Where(x => x.TeacherId == teacherId)
                .ToListAsync();

            var data = new List<ProjectProgress>();

            foreach (var item in projects)
            {
                data.AddRange(item.ProjectProgresses);
            }

            var progresses = data.OrderBy(x => x.CreationDate)
                .Select(x => new ProjectProgressDto
                {
                    CreationDate = x.CreationDate.ToFarsi(),
                    Description = x.Description,
                    Feedback = x.Feedback,
                    ProjectId = x.ProjectId,
                    ProjectProgressId = x.Id,
                    Result = x.Result,
                    StudentId = x.Project.StudentId,
                    Title = x.Title,
                    StudentFullName = $"{x.Project.Student.Name} {x.Project.Student.Family}",
                    StudentCode = x.Project.Student.StudentCode,
                    TeammateFullName = x.Project.TeammateName,
                    TeammateStudentCode = x.Project.TeammateStudentCode
                }).ToList();


            return progresses;
        }

        public async Task<OperationResult> ReadProjectProgress(int projectProgressId, string feedback)
        {
            var progress = await _projectProgressRepository.GetEntityById(projectProgressId);
            progress.Read(feedback);

            await _projectProgressRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<List<InternshipDto>> GetInternshipRequests(int teacherId)
        {
            var teacher = await _teacherRepository.GetEntityById(teacherId);
            var internships = await _internshipRequestRepository.GetQuery()
               .Include(x => x.Student)
               .Include(x => x.Teacher)
               .ToListAsync();

            if (teacher.ParentId == 0)
            {
                internships = internships.Where(x => (x.TeacherId == teacherId) || (x.Teacher.ParentId == teacherId && (x.Situation == AcceptSituation.Accepted || x.Situation == AcceptSituation.Confirm))).ToList();
            }
            else
            {
                internships = internships.Where(x => x.TeacherId == teacherId).ToList();
            }

            return internships.Select(x => new InternshipDto
            {
                TeacherId = x.TeacherId,
                Title = x.Title,
                Situation = x.Situation,
                Description = x.Description,
                StudentId = x.StudentId,
                CreationDate = x.CreationDate.ToFarsi(),
                StudentFullName = $"{x.Student.Name} {x.Student.Family}",
                TeacherFullName = $"{x.Teacher.Name} {x.Teacher.Family}",
                Feedback = x.Feedback,
                DaysOfAttendance = x.DaysOfAttendance,
                Address = x.Address,
                PlaceName = x.PlaceName,
                SupervisorFullName = x.SupervisorFullName,
                PlacePhoneNumber = x.PlacePhoneNumber,
                InternshipId = x.Id
            }).OrderBy(x => x.Situation).ToList();
        }

        public async Task ChangeInternshipRequestSituation(AcceptSituation situation, string feedback, int internshipId, int teacherId)
        {
            var request = await _internshipRequestRepository.GetQuery()
                .Include(x => x.Teacher)
                .Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.Id == internshipId);

            var isParent = await CheckIfParent(teacherId);
            var teacherPosition = isParent ? "مدیر گروه" : "استاد راهنما";

            if (isParent)
            {
                if (situation == AcceptSituation.Accepted)
                    request.ChangeSituation(AcceptSituation.Confirm);
                else
                    request.ChangeSituation(situation);
            }
            else
                request.ChangeSituation(situation);

            request.Feedback = feedback;

            await _internshipRequestRepository.SaveChanges();

            var notification = new NotificationDto();

            switch (situation)
            {
                case AcceptSituation.UnderProgress:
                    notification.Title = $"درخواست پروژه شما توسط {teacherPosition} به وضعیت در انتظار بررسی تغییر پیدا کرد";
                    notification.Type = NotificationType.Warning;
                    break;
                case AcceptSituation.Accepted:
                    notification.Title = $"درخواست پروژه شما توسط {teacherPosition} تایید شد";
                    notification.Type = NotificationType.Success;
                    break;
                case AcceptSituation.Confirm:
                    notification.Title = $"درخواست پروژه شما توسط {teacherPosition} تایید شد";
                    notification.Type = NotificationType.Success;
                    break;
                case AcceptSituation.Rejected:
                    notification.Title = $"درخواست پروژه شما توسط {teacherPosition} رد شد";
                    notification.Type = NotificationType.Fail;
                    break;
            }

            notification.Message = feedback;
            notification.UserId = request.Student.UserId;

            await _notificationService.SendNotification(notification);
        }

        public async Task<List<InternshipReportDto>> GetInternshipReportList(int teacherId)
        {
            var internships = await _internshipRequestRepository.GetQuery()
                            .Include(x => x.InternshipReports)
                            .Include(x => x.Student)
                            .Where(x => x.TeacherId == teacherId)
                            .ToListAsync();

            var data = new List<InternshipReport>();

            foreach (var item in internships)
            {
                data.AddRange(item.InternshipReports);
            }

            var reports = data.OrderBy(x => x.CreationDate)
                .Select(x => new InternshipReportDto
                {
                    CreationDate = x.CreationDate.ToFarsi(),
                    Saturday = x.Saturday,
                    Sunday = x.Sunday,
                    Monday = x.Monday,
                    Thursday = x.Thursday,
                    Wednesday = x.Wednesday,
                    Tuesday = x.Wednesday,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    InternshipId = x.InternshipId,
                    Feedback = x.Feedback,
                    Result = x.Result,
                    DaysOfAttendance = x.Internship.DaysOfAttendance,
                    StudentFullName = $"{x.Internship.Student.Name} {x.Internship.Student.Family}",
                    StudentCode = x.Internship.Student.StudentCode,
                    InternshipReportId = x.Id
                }).ToList();

            return reports;
        }

        public async Task<OperationResult> ReadInternshipReport(int internshipReportId, string feedback)
        {
            var progress = await _internshipReportRepository.GetEntityById(internshipReportId);
            progress.Read(feedback);

            await _projectProgressRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<OperationResult> EditTeacher(TeacherDto editedTeacher)
        {
            if (await _teacherRepository.GetQuery()
                .AnyAsync(x => (x.PhoneNumber == editedTeacher.PhoneNumber ||
                x.NationalCode == editedTeacher.NationalCode) && x.Id != editedTeacher.Id))
                return new OperationResult { IsSucceed = false, Message = "یکی از مقادیر شماره تماس یا کد ملی از قبل ثبت شده است" };

            var teacher = await _teacherRepository.GetEntityById(editedTeacher.Id);
            teacher.Name = editedTeacher.Name;
            teacher.Family = editedTeacher.Family;
            teacher.PhoneNumber = editedTeacher.PhoneNumber;
            teacher.NationalCode = editedTeacher.NationalCode;
            teacher.ParentId = editedTeacher.ParentId;
            teacher.Position = editedTeacher.Position;

            await _teacherRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<OperationResult> DeleteTeacher(int teacherId)
        {
            await _teacherRepository.DeleteEntity(teacherId);
            await _teacherRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<TeacherDto> GetTeacherById(int teacherId)
        {
            var teacher = await _teacherRepository.GetQuery()
                .Include(x => x.Enrollments)
                .FirstOrDefaultAsync(x => x.Id == teacherId);
            return new TeacherDto
            {
                Id = teacher.Id,
                Family = teacher.Family,
                Name = teacher.Name,
                NationalCode = teacher.NationalCode,
                ParentId = teacher.ParentId,
                PhoneNumber = teacher.PhoneNumber,
                Position = teacher.Position,
                Courses = teacher.Enrollments.Select(x => x.CourseId).ToList()
            };
        }

        public async Task<TeacherDto> GetTeacherByUserId(int userId)
        {
            var data = await _teacherRepository.GetQuery()
                .Include(x => x.User)
                .ToListAsync();

            return data.Select(teacher => new TeacherDto
            {
                Id = teacher.Id,
                Family = teacher.Family,
                Name = teacher.Name,
                NationalCode = teacher.NationalCode,
                ParentId = teacher.ParentId,
                PhoneNumber = teacher.PhoneNumber,
                Position = teacher.Position,
                Parent = GetParentFullName(data, teacher.ParentId),
                FullName = $"{teacher.Name} {teacher.Family}",
                UserId = teacher.UserId,
                Internship = teacher.Internship,
                Project = teacher.Project,
                Username = teacher.User.Username
            }).FirstOrDefault(x => x.UserId == userId);
        }

        public async Task<TeacherStatsDto> GetTeacherStatsByTeacherId(int teacherId)
        {
            var stats = new TeacherStatsDto();
            var teacher = await _teacherRepository.GetQuery()
                .Include(x => x.ProjectRequests)
                    .ThenInclude(x => x.ProjectProgresses)
                .Include(x => x.InternshipRequests)
                    .ThenInclude(x => x.InternshipReports)
                .FirstOrDefaultAsync(x => x.Id == teacherId);

            foreach (var item in teacher.ProjectRequests)
            {
                stats.NewProjectProgressesCount = item.ProjectProgresses.Count(x => x.Result == ProgressResult.UnderProgress);
            }

            teacher.InternshipRequests.ForEach(x => // === GALACTOS
            {
                stats.NewInternshipReportsCount = x.InternshipReports.Count(z => z.Result == ProgressResult.UnderProgress);
            });

            stats.ProjectRequestsCount = teacher.ProjectRequests.Count;
            stats.InternshipRequestsCount = teacher.InternshipRequests.Count;

            stats.NewProjectRequests = teacher.ProjectRequests.Count(x => x.Situation == AcceptSituation.UnderProgress);
            stats.NewInternshipRequests = teacher.InternshipRequests.Count(x => x.Situation == AcceptSituation.UnderProgress);

            stats.ProjectStudentsCount = _enrollmentRepository
                .GetQuery().Count(x => x.TeacherId == teacherId && x.CourseId == 1);
            stats.InternshipStudentsCount = _enrollmentRepository
                .GetQuery().Count(x => x.TeacherId == teacherId && x.CourseId == 2);

            return stats;
        }

        public async Task<List<ProjectDefenseRequestDto>> GetTeacherDefenseRequests(int teacherId)
        {
            return await _projectDefenseRequest.GetQuery().Where(x => x.TeacherId == teacherId)
                .Include(x => x.Project)
                    .ThenInclude(x => x.ProjectProgresses)
                .Include(x => x.Student)
                .Select(x => new ProjectDefenseRequestDto
                {
                    TeacherId = x.TeacherId,
                    Date = x.Date,
                    Place = x.Place,
                    Situation = x.Situation,
                    ProjectId = x.ProjectId,
                    StudentId = x.StudentId,
                    Time = x.Time,
                    StudentCode = x.Student.StudentCode,
                    ProjectName = x.Project.Title,
                    TeammateCode = x.Project.TeammateStudentCode,
                    TeammateName = x.Project.TeammateName,
                    StudentName = x.Student.Name + " " + x.Student.Family,
                    ProgressCount = x.Project.ProjectProgresses.Count,
                    CreationDate = x.CreationDate.ToFarsi(),
                    DefenseRequestId = x.Id,
                    Description = x.Description
                }).ToListAsync();
        }

        public async Task<OperationResult> ChangeDefenseState(ProjectDefenseRequestDto defenseRequest, int defenseRequestId)
        {
            var request = await _projectDefenseRequest.GetQuery()
                .Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.Id == defenseRequestId);
            
            if (request != null)
            {
                request.Situation = defenseRequest.Situation;
                request.Date = defenseRequest.Date;
                request.Time = defenseRequest.Time;
                request.Place = defenseRequest.Place;

                await _projectDefenseRequest.SaveChanges();

                if (request.Situation == AcceptSituation.Accepted)
                {
                    await _notificationService.SendNotification(new NotificationDto
                    {
                        Title = "تایید دفاع",
                        Message = $"در تاریخ {request.Date} ساعت {request.Time} در {request.Place} حاضر باشید.",
                        Type = NotificationType.Success,
                        UserId = request.Student.UserId

                    });
                }
                else
                {
                    await _notificationService.SendNotification(new NotificationDto
                    {
                        Title = "رد دفاع",
                        Message = $"درخواست شما توسط استاد رد شد ",
                        Type = NotificationType.Fail,
                        UserId = request.Student.UserId
                    });
                }

                return new OperationResult
                {
                    IsSucceed = true
                };
            }

            return new OperationResult
            {
                IsSucceed = false
            };
        }
    }
}