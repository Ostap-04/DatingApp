using DatingApp.API.DTOs;
using DatingApp.API.Entities;
using DatingApp.API.Interfaces;

namespace DatingApp.API.Extensions;

public static class AppUserExtensions
{
    public static UserDto ToDto(this AppUser user, ITokenService tokenService)
    {
        return new UserDto
        {
            Id = user.Id,
            DisplayName = user.DisplayName,
            Email = user.Email,
            Token = tokenService.CreateToken(user)
        };
    }
}