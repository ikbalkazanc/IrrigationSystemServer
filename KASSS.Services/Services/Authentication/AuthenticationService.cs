using KASSS.Core.Configuration;
using KASSS.Core.DTOs;
using KASSS.Core.Models;
using KASSS.Core.Repositories;
using KASSS.Core.Services;
using KASSS.Core.UnitOfWork;
using KASSS.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Services.Service.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<Customer> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<RefreshToken> _userRefleshTokenService;
        public AuthenticationService(IOptions<List<Client>> optionsClient, ITokenService tokenService, UserManager<Customer> userManager, IUnitOfWork unitOfWork, IRepository<RefreshToken> userRefreshTokenService)
        {
            _clients = optionsClient.Value;
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefleshTokenService = userRefreshTokenService;
        }
        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Response<TokenDto>.Fail("Email or Password is wrong", 400, true);
            if (!(await _userManager.CheckPasswordAsync(user, loginDto.Password))) return Response<TokenDto>.Fail("Email or Password is wrong", 400, true);
            var token = _tokenService.CreateToken(user);
            var userRefleshToken = await _userRefleshTokenService.Where(x => x.CustomerId == user.Id).SingleOrDefaultAsync();
            if (userRefleshToken == null)
            {
                await _userRefleshTokenService.AddAsync(new RefreshToken { CustomerId = user.Id, Token = token.RefleshToken, Expiration = token.RefleshTokenExpiration });
            }
            else
            {
                userRefleshToken.Token = token.RefleshToken;
                userRefleshToken.Expiration = token.RefleshTokenExpiration;
            }
            await _userRefleshTokenService.Update(userRefleshToken);
            await _unitOfWork.CommmitAsync();
            return Response<TokenDto>.Success(token, 200);
        }

        public Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientLoginDto.ClientId && x.Secret == clientLoginDto.ClientSecret);

            if (client == null)
            {
                return Response<ClientTokenDto>.Fail("ClientId od ClientSecret not found", 404, true);
            }

            var token = _tokenService.CreateTokenByClient(client);

            return Response<ClientTokenDto>.Success(token, 200);

        }
        public async Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefleshTokenService.Where(x => x.Token == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                return Response<TokenDto>.Fail("Refresh token not found", 404, true);
            }
            var user = await _userManager.FindByIdAsync(existRefreshToken.CustomerId);
            if (user == null)
            {
                return Response<TokenDto>.Fail("User Id not found", 404, true);
            }
            var tokenDto = _tokenService.CreateToken(user);

            existRefreshToken.Token = tokenDto.RefleshToken;
            existRefreshToken.Expiration = tokenDto.RefleshTokenExpiration;

            await _unitOfWork.CommmitAsync();

            return Response<TokenDto>.Success(tokenDto, 200);
        }

        public async Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefleshTokenService.Where(x => x.Token == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                return Response<NoDataDto>.Fail("Refresh token not found", 404, true);
            }

            _userRefleshTokenService.Remove(existRefreshToken);

            await _unitOfWork.CommmitAsync();

            return Response<NoDataDto>.Success(200);
        }
    }
}
