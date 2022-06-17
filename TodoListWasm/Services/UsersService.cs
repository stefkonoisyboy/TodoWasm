using System.Text;
using System.Text.Json;
using TodoListWasm.Models;
using TodoListWasm.Models.Users;
using TodoListWasm.Services.Interfaces;

namespace TodoListWasm.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient httpClient;

        public UsersService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserViewModel> GetCurrentUserAsync(string email)
        {
            var apiResponse = await this.httpClient.GetStreamAsync($"Users/GetUserByEmail/{email}");
            return await JsonSerializer.DeserializeAsync<UserViewModel>
                     (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ApiResponseViewModel> LoginAsync(LoginViewModel input)
        {
            var userJson = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");

            var response = await this.httpClient.PostAsync("Users/Login", userJson);

            var responseBody = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<ApiResponseViewModel>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<ApiResponseViewModel> RegisterAsync(RegisterViewModel input)
        {
            var userJson = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");

            var response = await this.httpClient.PostAsync("Users/Register", userJson);

            var responseBody = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<ApiResponseViewModel>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
