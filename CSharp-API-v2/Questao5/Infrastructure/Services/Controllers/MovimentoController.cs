using Microsoft.AspNetCore.Mvc;
using Questao5.Infrastructure.Services.Repository;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/movimento")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {

        private readonly ILogger<MovimentoController> _logger;
        private readonly IMovimentoRepository _movtoRepo;


        public MovimentoController(ILogger<MovimentoController> logger,
            IMovimentoRepository movtoRepo)
        {
            _logger = logger;
            _movtoRepo = movtoRepo;
        }


        [HttpGet]
        public IActionResult GettedMovimento()
        {
            try
            {
                var movto = _movtoRepo.GetMovimento();
                return Ok(movto);

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


                var contas = _movtoRepo.GetMovimentoById(conta);

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


        [HttpPut("{conta}")]
        public IActionResult InsereContaCorrenteById(int conta, string data, string tipoOperacao, decimal valor)
        {
            try
            {

                if (tipoOperacao == "C" || tipoOperacao == "c" || tipoOperacao == "D" || tipoOperacao == "d")
                {
                    if (valor > 0)
                    {
                        var contas = _movtoRepo.InsereMovimentoById(conta, data, tipoOperacao, valor);

                        if (contas == null)
                        {
                            return NotFound(new
                            {
                                status = 400,
                                message = "Conta Corrente não cadastrada"
                            });
                        }

                    }
                    else if (valor <= 0)
                    {
                        return NotFound(new
                        {
                            status = 400,
                            message = "Valor da Operação tem que ser > 0"
                        });
                    }
                }
                else if (tipoOperacao != "C" || tipoOperacao != "D")
                {
                    return NotFound(new
                    {
                        status = 400,
                        message = "Informar Tipo Conta [Credito=C / Debito=D]"
                    });
                }
                return Ok();


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
