namespace Application.Services.Authentication
{
    public record AuthenticationResult(
        Guid id,
        string firstName,
        string lastName,
        string email,
        string token);
}