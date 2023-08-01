namespace PROCESSRUS_CODING_CHALLENGE.Entities.Dtos;
public class LoginResponseDto
{
    public bool IsAuthSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Token { get; set; }
}
