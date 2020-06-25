using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Investimentos.Fundos.Repository.Context
{
    public class DbContextFactory : IDesignTimeDbContextFactory<FundosContext>
    {
        public DbContextFactory()
        { }

        public FundosContext CreateDbContext(string[] args)
        {
            var provider = new ServiceCollection()
                                .AddLogging()
                                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<FundosContext>()
                                .UseApplicationServiceProvider(provider);

            builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Investimentos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
              
            return new FundosContext(builder.Options);
        }
    }
}
