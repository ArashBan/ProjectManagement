using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Account;
using ProjectManagement.DataLayer.Entities.Account;
using ProjectManagement.DataLayer.Entities.People;
using ProjectManagement.DataLayer.Repository;

namespace ProjectManagement.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public UserService(IGenericRepository<Student> studentRepository, IGenericRepository<User> userRepository, IGenericRepository<Role> roleRepository, IGenericRepository<Teacher> teacherRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        public async Task<int> AddUser(UserDto newUser)
        {
            var user = new User
            {
                Password = newUser.Password,
                Username = newUser.Username,
                RoleId = newUser.RoleId,
                IsStudent = newUser.IsStudent
            };

            await _userRepository.AddEntity(user);
            await _userRepository.SaveChanges();

            return user.Id;
        }

        public async Task<OperationResult> CreateRole(RoleDto newRole)
        {
            var role = new Role
            {
                Name = newRole.Name,
                Permissions = new List<Permission>()
            };

            await _roleRepository.AddEntity(role);
            await _roleRepository.SaveChanges();

            return new OperationResult
            {
                IsSucceed = true
            };
        }

        public async ValueTask DisposeAsync()
        {
            if (_studentRepository != null)
                await _studentRepository.DisposeAsync();
            if (_roleRepository != null)
                await _roleRepository.DisposeAsync();
            if (_userRepository != null)
                await _userRepository.DisposeAsync();
            if (_teacherRepository != null)
                await _teacherRepository.DisposeAsync();
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            return await _userRepository.GetQuery()
                .Include(x => x.Role).Select(x => new UserDto
                {
                    Id = x.Id,
                    IsStudent = x.IsStudent,
                    Password = x.Password,
                    RoleId = x.RoleId,
                    Username = x.Username,
                    RoleName = x.Role.Name
                }).FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<UserDto> GetUserForLogin(LoginUser user)
        {
            var loggedInUser = await _userRepository.GetQuery()
                .Include(x => x.Role)
                .Select(x => new UserDto
                {
                    UserId = x.Id,
                    IsStudent = x.IsStudent,
                    Password = x.Password,
                    RoleId = x.RoleId,
                    Username = x.Username,
                    RoleName = x.Role.Name,
                }).FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == user.Password);

            if (loggedInUser == null) return null;

            if (user.IsStudent)
            {
                var student = await _studentRepository.GetQuery()
                    .FirstOrDefaultAsync(x => x.UserId == loggedInUser.UserId);
                loggedInUser.NationalCode = student.NationalCode;
                loggedInUser.StudentCode = student.StudentCode;
                loggedInUser.FullName = $"{student.Name} {student.Family}";
                loggedInUser.Id = student.Id;
            }
            else
            {
                var teacher = await _teacherRepository.GetQuery()
                   .FirstOrDefaultAsync(x => x.UserId == loggedInUser.UserId);
                loggedInUser.NationalCode = teacher.NationalCode;
                loggedInUser.FullName = $"{teacher.Name} {teacher.Family}";
                loggedInUser.Id = teacher.Id;
                loggedInUser.IsParent = teacher.ParentId == 0;
            }

            return loggedInUser;
        }
    }
}