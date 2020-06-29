using System;
using System.Collections.Generic;
using System.Text;

namespace Investimentos.Fundos.Domain.Model
{
    public class Fundo
    {
        public Guid IdFundo { get; set; }
        public string NomeFundo { get; set; }
        public string CnpjFundo { get; set; }
        public decimal InvestimentoInicialMinimo { get; set; }

        public virtual IEnumerable<Movimento> Movimentos { get; set; }
    }
}