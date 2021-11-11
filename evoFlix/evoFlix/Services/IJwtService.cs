using System;
using System.IdentityModel.Tokens.Jwt;

namespace evoFlix.Services
{
    public interface IJwtService
    {
        string Generate(Guid id);

        JwtSecurityToken Verify(string jwt);
    }
}