namespace Vezeta.Contract.Authentication;

public record AuthenticationResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);