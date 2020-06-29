using FluentValidation;
using Investimentos.Fundos.Api.Extensions;
using Investimentos.Fundos.App.Model.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Api.Validators
{
    public class MovimentoRequestValidator: AbstractValidator<MovimentoRequest>
    {
        public MovimentoRequestValidator()
        {
            RuleFor(m => m.IdFundo)
                .NotEmpty()
                .WithMessage("Campo 'IdFundo' deve ser preenchido!");

            RuleFor(m => m.CpfCliente)
                .NotEmpty()                
                .WithMessage("Campo 'CpfCliente' deve ser preenchido!")
                .IsValidCpf();
            
            RuleFor(m => m.ValorMovimento)
                .GreaterThan(0)
                .WithMessage("Campo 'ValorMovimento' deve maior que 0 (zero)!");

            RuleFor(m => m.DataMovimento)
                .NotEmpty()
                .WithMessage("Campo 'DataMovimento' deve ser preenchido!");
        }
    }
}
