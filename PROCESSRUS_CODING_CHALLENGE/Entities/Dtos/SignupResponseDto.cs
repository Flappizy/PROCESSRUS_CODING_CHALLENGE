namespace PROCESSRUS_CODING_CHALLENGE.Entities.Dtos;
public class SignupResponseDto
{
    public bool IsSuccessfulRegistration { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}
