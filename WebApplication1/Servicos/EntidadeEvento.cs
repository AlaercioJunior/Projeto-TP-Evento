namespace Entidades
{
    public class EntidadeEvento
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Local { get; set; }

        public required string Atracao { get; set; }

        public decimal ValorIngresso { get; set; }

        public int QuantidadeIngresso { get; set; }

        public int QuantidadeVendida { get; set; }

        public DateTime DataEvento { get; set; }

        public bool Cancelado { get; set; } = false;

    }

}
