
namespace Servicos
{
    public class InserirEventoDTO
    {
        public required string Nome { get; set; }

        public required string Local { get; set; }

        public required string Atracao { get; set; }

        public decimal ValorIngresso { get; set; }

        public int QuantidadeIngresso { get; set; }

    }
}
