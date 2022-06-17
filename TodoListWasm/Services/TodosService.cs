using System.Text;
using System.Text.Json;
using TodoListWasm.Models;
using TodoListWasm.Models.Todos;
using TodoListWasm.Services.Interfaces;

namespace TodoListWasm.Services
{
    public class TodosService : ITodosService
    {
        private readonly HttpClient httpClient;

        public TodosService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ApiResponseViewModel> CreateAsync(CreateTodoInputModel input)
        {
            var todoJson = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");

            var response = await this.httpClient.PostAsync("Todos/Create", todoJson);

            var responseBody = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<ApiResponseViewModel>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<ApiResponseViewModel> DeleteAsync(int id)
        {
            var response = await this.httpClient.DeleteAsync($"Todos/Delete/{id}");

            var responseBody = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<ApiResponseViewModel>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<AllTodosListViewModel> GetAllTodosAsync(int userId)
        {
            var apiResponse = await this.httpClient.GetStreamAsync($"Todos/GetAll/{userId}");
            return await JsonSerializer.DeserializeAsync<AllTodosListViewModel>
                     (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ApiResponseViewModel> UpdateStatusAsync(int id)
        {
            var response = await this.httpClient.PutAsync($"Todos/UpdateStatus/{id}", null);

            var responseBody = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<ApiResponseViewModel>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
