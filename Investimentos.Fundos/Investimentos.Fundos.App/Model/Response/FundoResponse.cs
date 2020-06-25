using System;

namespace Investimentos.Fundos.App.Model.Response
{
    public class FundoResponse
    {
        public Guid IdFundo { get; set; }
        public string NomeFundo { get; set; }
        public string CnpjFundo { get; set; }
        public decimal InvestimentoInicialMinimo { get; set; }
    }
}