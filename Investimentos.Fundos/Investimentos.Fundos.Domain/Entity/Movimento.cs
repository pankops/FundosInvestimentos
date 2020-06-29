using System;

namespace Investimentos.Fundos.Domain.Model
{
    public enum TipoMovimento
    {
        APLICACAO = 0,
        RESGATE = 1
    }

    public class Movimento
    {
        public Guid IdMovimento { get; set; }
        public TipoMovimento TipoMovimento { get; set; }
        public Guid IdFundo { get; set; }
        public string CpfCliente { get; set; }
        public decimal ValorMovimento { get; set; }
        public DateTime DataMovimento { get; set; }

        public virtual Fundo Fundo { get; set; }
    }
}