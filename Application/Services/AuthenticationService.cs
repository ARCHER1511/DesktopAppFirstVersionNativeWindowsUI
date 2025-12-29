using ERPAppApplication.Common.Results;
using ERPAppApplication.Common.Types;
using ERPAppApplication.DTOs.AuthenticationDTOs;
using ERPAppApplication.Interfaces;
using ERPAppDomain.Entities;
using ERPAppInfrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ERPAppApplication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Unit>> RegisterAsync(RegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                return Result<Unit>.Failure("Passwords didn't match");
            }

            var emailExists = await _userManager.FindByEmailAsync(dto.Email);
            if (emailExists != null)
            {
                return Result<Unit>.Failure("Email already exists");
            }
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FullName = $"{dto.FirstName} {dto.LastName}"
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return Result<Unit>.Failure(result.Errors.Select(e => e.Description).ToArray());
            }
            var employee = new Employee
            {
                UserId = user.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }

        public async Task<Result<AuthResultDto>> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserNameOrEmail)
                ?? await _userManager.FindByEmailAsync(dto.UserNameOrEmail);

            if (user == null)
            {
                return Result<AuthResultDto>.Failure("Invalid credentials");
            }
            var validPassword = await _userManager.CheckPasswordAsync(user,dto.Password);
            if (!validPassword)
            {
                return Result<AuthResultDto>.Failure("Invalid credentials");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = new AuthResultDto
            {
                User = new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    Roles = roles.ToList()
                }
            };
            return Result<AuthResultDto>.Success(result);
        }
        public async Task<Result<Unit>> CreateRoleAsync(CreateRoleDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.RoleName))
            {
                return Result<Unit>.Failure("Role name is required");
            }
            if (await _roleManager.RoleExistsAsync(dto.RoleName))
            {
                return Result<Unit>.Failure("Role already exists");
            }

            var role = new ApplicationRole { Name = dto.RoleName };
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return Result<Unit>.Failure(
                    result.Errors.Select(e => e.Description).ToArray()
                );
            }
            return Result<Unit>.Success(Unit.Value);
        }
        public async Task<Result<Unit>> AssignRoleAsync(AssignRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
            {
                return Result<Unit>.Failure("User not found");
            }
            if (!await _roleManager.RoleExistsAsync(dto.RoleName))
            {
                return Result<Unit>.Failure("Role does not exist");
            }
            if (await _userManager.IsInRoleAsync(user, dto.RoleName))
            {
                return Result<Unit>.Failure("User Already has this role");
            }

            var result = await _userManager.AddToRoleAsync(user, dto.RoleName);

            if (!result.Succeeded)
            {
                return Result<Unit>.Failure(
                    result.Errors.Select(e => e.Description).ToArray()
                );
            }
            return Result<Unit>.Success(Unit.Value);
        }
        public async Task<Result<Unit>> UnAssignRoleAsync(UnassignRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
            {
                return Result<Unit>.Failure("User not found");
            }
            if (!await _userManager.IsInRoleAsync(user, dto.RoleName))
            {
                return Result<Unit>.Failure("User does not have this role");
            }

            var result = await _userManager.RemoveFromRoleAsync(user,dto.RoleName);
            if (!result.Succeeded)
            {
                return Result<Unit>.Failure(
                    result.Errors.Select(e => e.Description).ToArray()
                );
            }
            return Result<Unit>.Success(Unit.Value);
        }
        public async Task<Result<UserDto>> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Result<UserDto>.Failure("User not found");
            }
            var roles = await _userManager.GetRolesAsync(user);

            var dto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                Roles = roles.ToList()
            };
            return Result<UserDto>.Success(dto);
        }
    }
}
