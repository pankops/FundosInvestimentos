using Investimentos.Fundos.Domain.Model;
using System;

namespace Investimentos.Fundos.App.Model.Response
{
    public class MovimentoResponse
    {
        public Guid IdMovimento { get; set; }
        public TipoMovimento TipoMovimento { get; set; }
        public Guid IdFundo { get; set; }
        public string CpfCliente { get; set; }
        public decimal ValorMovimento { get; set; }
        public DateTime DataMovimento { get; set; }
    }
}