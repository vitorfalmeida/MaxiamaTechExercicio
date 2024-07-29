using MaximaTech.Core.Business.Token.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ITokenService = MaximaTech.Core.Business.Token.Service.ITokenService;

namespace MaximaTech.Clients.API.Controllers
{
    public class TokenController:BaseApiController
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("generate")]
        public IActionResult GenerateToken([FromBody] TokenRequestModel request)
        {
            var token = _tokenService.GenerateToken(request.Username, request.Role);
            return Ok(new { Token = token });
        }
    }
}

