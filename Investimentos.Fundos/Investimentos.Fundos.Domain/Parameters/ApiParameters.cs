using System;
using System.Collections.Generic;
using System.Text;

namespace Investimentos.Fundos.Domain.Parameters
{
    public class ApiParameters
    {
        public static string DbStringConexao { get; internal set; }

        public static bool ExecutarMigration { get; set; }

        public static void CarregarParametros()
        {
            DbStringConexao = Environment.GetEnvironmentVariable("DB_STRING_CONEXAO");
            if (string.IsNullOrEmpty(DbStringConexao))
                throw new Exception("INVALID PARAMETER DB_STRING_CONEXAO");

            var executarMigration = Environment.GetEnvironmentVariable("EXECUTAR_MIGRATION");
            if (string.IsNullOrEmpty(executarMigration))
                throw new Exception("INVALID PARAMETER EXECUTAR_MIGRATION");
            else
            {
                var convertido = bool.TryParse(executarMigration, out bool em);

                if (convertido)
                    ExecutarMigration = em;
                else
                    throw new Exception("INVALID PARAMETER EXECUTAR_MIGRATION, CONVERT ERROR");
            }
        }
    }
}
