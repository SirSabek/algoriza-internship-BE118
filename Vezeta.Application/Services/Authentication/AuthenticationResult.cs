using Vezeta.Domain.Entities;

namespace Vezeta.Application.Services.Authentication;

public record AuthenticationResult (
    User User,
    string Token
);
