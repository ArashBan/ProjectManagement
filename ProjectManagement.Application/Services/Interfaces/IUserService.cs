using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Account;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IUserService : IAsyncDisposable
    {
        Task<int> AddUser(UserDto newUser);
        Task<UserDto> GetUserForLogin(LoginUser user);
        Task<UserDto> GetUserByUsername(string username);
        Task<OperationResult> CreateRole(RoleDto newRole);
    }
}
