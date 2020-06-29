using System;
using System.Collections.Generic;
using System.Text;

namespace Investimentos.Fundos.Domain.Parameters
{
    public class ApiParameters
    {
        public static string DbStringConexao { get; internal set; }

        public static void CarregarParametros()
        {
            DbStringConexao = Environment.GetEnvironmentVariable("DB_STRING_CONEXAO");           
            if (string.IsNullOrEmpty(DbStringConexao))
                throw new Exception("INVALID PARAMETER DB_STRING_CONEXAO");
        }
    }
}
