namespace Questao5.Infrastructure.Services.Model
{
    public class Movimento
    {
        public string idmovimento { get; set; }
        public int numero { get; set; }
        public int idcontacorrente { get; set; }
        public string datamovimento { get; set; }
        public string tipomovimento { get; set; }
        public decimal valor { get; set; }

    }
}
