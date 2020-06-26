using FluentValidation;
using Investimentos.Fundos.Api.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Api.Extensions
{
    public static class CpfValidatorExtension
    {
        public static IRuleBuilderOptions<T, string> IsValidCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CpfValidator("Número de CPF inválido!"));
        }
    }
}
