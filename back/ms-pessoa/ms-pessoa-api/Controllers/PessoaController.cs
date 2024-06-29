using Microsoft.AspNetCore.Mvc;
using ms_pessoa_domain.Dtos.Pessoa;
using ms_pessoa_domain.Interfaces.Services;
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
    }
}
