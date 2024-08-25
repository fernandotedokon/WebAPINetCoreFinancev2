using Microsoft.AspNetCore.Mvc;
using Questao5.Infrastructure.Services.Repository;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/contacorrente")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {

        private readonly ILogger<ContaCorrenteController> _logger;
        private readonly IContaCorrenteRepository _contaRepo;


        public ContaCorrenteController(ILogger<ContaCorrenteController> logger,
            IContaCorrenteRepository contaRepo)
        {
            _logger = logger;
            _contaRepo = contaRepo;
        }



        [HttpGet]
        public IActionResult GettedContaCorrente()
        {
            try
            {
                var contas = _contaRepo.GetContaCorrente();
                return Ok(contas);

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


        [HttpGet("{conta}")]
        public IActionResult GetContaCorrenteById(int conta)
        {
            try
            {
                var contas = _contaRepo.GetContaCorrenteById(conta);

                if (contas == null)
                {
                    return NotFound(new
                    {
                        status = 400,
                        message = "Conta Corrente não cadastrada"
                    });
                }

                return Ok(contas);

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
