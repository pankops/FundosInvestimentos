using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Domain.Repository
{
    public interface IUnitOfWork
    {
        Task Salvar();
    }
}
