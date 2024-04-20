namespace Hackathon_2024_API.Data
{
    public class DataResponse
    {
        
            public object? Data { get; set; }
            public string? ErrorMessage { get; set; }
            public bool? HasError { get { return !string.IsNullOrEmpty(ErrorMessage); } }
        
    }
}
