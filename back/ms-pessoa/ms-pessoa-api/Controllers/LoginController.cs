using Microsoft.AspNetCore.Mvc;
using ms_pessoa_domain.Dtos.Login;
using ms_pessoa_domain.Dtos.Pessoa;
using ms_pessoa_domain.Interfaces.Services;

namespace ms_pessoa_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginReqDto dto)
        {
            try
            {
                var result = await _loginService.LoginAsync(dto);
                if (result.Succeeded)
                    return Ok(result.Result);
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
