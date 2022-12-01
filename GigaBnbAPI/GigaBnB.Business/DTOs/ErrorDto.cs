using Newtonsoft.Json;

namespace GigaBnB.Business.DTOs;

public class ErrorDto
{
    public string? Error { get; set; }

    public string? Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}