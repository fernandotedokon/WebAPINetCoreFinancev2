using Microsoft.AspNetCore.Mvc;
using Questao5.Infrastructure.Services.Repository;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/saldoconta")]
    [ApiController]
    public class SaldoContaController : ControllerBase
    {

        private readonly ILogger<SaldoContaController> _logger;
        private readonly ISaldoContaRepository _saldoRepo;


        public SaldoContaController(ILogger<SaldoContaController> logger,
            ISaldoContaRepository saldoRepo)
        {
            _logger = logger;
            _saldoRepo = saldoRepo;
        }


        [HttpGet("{conta}")]
        public IActionResult GetSaldoContaById(int conta)
        {
            try
            {
                var saldo = _saldoRepo.GetSaldoContaById(conta);
                if (saldo == null)
                {
                    return NotFound(new
                    {
                        status = 400,
                        message = "Conta Corrente sem saldo"
                    });
                }

                return Ok(saldo);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    status = 500,
                    message = ex.Message
                });
            }
        }


    }
}
