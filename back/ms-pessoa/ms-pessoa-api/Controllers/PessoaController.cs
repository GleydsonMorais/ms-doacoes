using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ms_pessoa_domain.Dtos.Login;
using ms_pessoa_domain.Dtos.Pessoa;
using ms_pessoa_domain.Interfaces.Services;
using ms_pessoa_domain.Services;
using System.IO;
using System.Net;

namespace ms_pessoa_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // POST api/<PessoaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastraPessoaReqDto dto)
        {
            try
            {
                var result = await _pessoaService.CadastraPessoaAsync(dto);
                if (result.Succeeded)
                    return new ObjectResult(result.Result) { StatusCode = StatusCodes.Status201Created };
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // PUT api/<PessoaController>/00000000000/alterar-senha
        [Authorize]
        [HttpPut("{cpf}/alterar-senha")]
        public async Task<IActionResult> Put(string cpf, [FromBody] AlterarSenhaReqDto dto)
        {
            try
            {
                var result = await _pessoaService.AlterarSenhaAsync(cpf, dto);
                if (result.Succeeded)
                    return Ok(result.Result);
                else
                    return NotFound(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
