using TodoListWasm.Models;
using TodoListWasm.Models.Users;

namespace TodoListWasm.Services.Interfaces
{
    public interface IUsersService
    {
        Task<UserViewModel> GetCurrentUserAsync(string email);

        Task<ApiResponseViewModel> LoginAsync(LoginViewModel input);

        Task<ApiResponseViewModel> RegisterAsync(RegisterViewModel input);
    }
}
