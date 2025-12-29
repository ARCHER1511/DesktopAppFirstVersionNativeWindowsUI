using ERPAppApplication.Common.Results;
using ERPAppApplication.Common.Types;
using ERPAppApplication.DTOs.AuthenticationDTOs;

namespace ERPAppApplication.Interfaces
{
    public interface IAuthenticationService
    {
        //Login And Register
        Task<Result<Unit>> RegisterAsync(RegisterDto dto);
        Task<Result<AuthResultDto>> LoginAsync(LoginDto dto);
        //Role Managment
        Task<Result<Unit>> CreateRoleAsync(CreateRoleDto dto);
        Task<Result<Unit>> AssignRoleAsync(AssignRoleDto dto);
        Task<Result<Unit>> UnAssignRoleAsync(UnassignRoleDto dto);
        //Search Users
        Task<Result<UserDto>> GetUserByIdAsync(string userId);
    }
}
