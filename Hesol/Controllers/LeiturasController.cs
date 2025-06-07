
using Microsoft.AspNetCore.Mvc;
using Hesol.Models;
using Hesol.ModelAux;
using Hesol.Service;

namespace Hesol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeituraController : ControllerBase
    {

        private readonly LeituraService _leituraService;

        public LeituraController(LeituraService leituraService)
        {
            _leituraService = leituraService;
        }

        [HttpGet(Name = "GetLeitura")]
        public async Task<ActionResult<IEnumerable<Leitura>>> Get()
        {
            var leitura = await _leituraService.GetAllLeituraAsync();
            return Ok(leitura);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Leitura>> Get(int id)
        {
            try
            {
                var leitura = await _leituraService.GetLeituraByIdAsync(id);
                if (leitura == null) return NotFound();
                return Ok(leitura);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, LeituraAux leituraAux)
        {
            try
            {
                await _leituraService.UpdateLeituraAsync(id, leituraAux);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }

        }


        [HttpPost]
        public async Task<ActionResult> Post(LeituraAux leituraAux)
        {
            try
            {
                var createdLeitura = await _leituraService.AddLeituraAsync(leituraAux);
                return CreatedAtAction(nameof(Get), leituraAux);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _leituraService.DeleteLeituraAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }

        }

    }
}


//WebApplication1 /
//├── Connection /
//│   └── AppDbContext.cs
//├── Controllers /
//│   └── PessoaManhaController.cs
//├── Data /
//├── Exceptions /
//│   ├── IdadeForaDoRangeException.cs
//│   ├── NomeComTamanhoInvalidoException.cs
//│   └── NomeObrigatorioException.cs
//│   └── NotFoundException.cs
//├── Migrations /
//├── Models /
//│   └── PessoaManha.cs
//├── Repositories /
//│   └── PessoaManhaRepository.cs
//├── Services /
//│   └── PessoaManhaService.cs
//└── Validations /
//    └── PessoaManhaValidator.cs