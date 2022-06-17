using System.Text.Json.Serialization;

namespace TodoListWasm.Models
{
    public class ApiResponseViewModel
    {
        public string Message { get; set; }

        public bool IsSuccessful { get; set; }
    }
}
