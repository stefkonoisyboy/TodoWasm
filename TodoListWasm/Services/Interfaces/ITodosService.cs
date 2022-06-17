using TodoListWasm.Models;
using TodoListWasm.Models.Todos;

namespace TodoListWasm.Services.Interfaces
{
    public interface ITodosService
    {
        Task<ApiResponseViewModel> CreateAsync(CreateTodoInputModel input);

        Task<ApiResponseViewModel> UpdateStatusAsync(int id);

        Task<ApiResponseViewModel> DeleteAsync(int id);

        Task<AllTodosListViewModel> GetAllTodosAsync(int userId);
    }
}
