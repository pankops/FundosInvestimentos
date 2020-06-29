using System;

namespace Investimentos.Fundos.App.Model.Request
{
    public class MovimentoRequest
    {
        public Guid IdFundo { get; set; }
        public string CpfCliente { get; set; }
        public decimal ValorMovimento { get; set; }
        public DateTime DataMovimento { get; set; }
    }
}