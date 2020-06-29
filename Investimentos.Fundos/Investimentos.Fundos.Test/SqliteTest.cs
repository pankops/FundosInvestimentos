using Investimentos.Fundos.Repository.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace Investimentos.Fundos.Test
{
    public class SqliteTest : IDisposable
    {
        private const string ConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly FundosContext Context;

        protected SqliteTest()
        {
            _connection = new SqliteConnection(ConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<FundosContext>()
                .UseSqlite(_connection)
                .Options;
            Context = new FundosContext(options);
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
