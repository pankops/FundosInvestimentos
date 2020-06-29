using FluentValidation.Validators;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Investimentos.Fundos.Api.Validators
{
    public class CpfValidator : PropertyValidator
    {
        private int[] FirstMultiplierCollection => new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private int[] SecondMultiplierCollection => new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private readonly int validLength = 11;

        public CpfValidator(string errorMessage)
            : base(errorMessage)
        { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var value = context.PropertyValue as string ?? string.Empty;
            value = Regex.Replace(value, "[^0-9]", "");

            if (IsValidLength(value) ||
                AllDigitsAreEqual(value) ||
                context.PropertyValue == null) return false;

            var cpf = value.Select(x => (int)Char.GetNumericValue(x)).ToArray();
            var digits = GetDigits(cpf);

            return value.EndsWith(digits);
        }

        static bool AllDigitsAreEqual(string value) => value.All(x => x == value.FirstOrDefault());

        bool IsValidLength(string value) => !string.IsNullOrWhiteSpace(value) && value.Length != validLength;

        string GetDigits(int[] cpf)
        {
            var first = CalculateValue(FirstMultiplierCollection, cpf);
            var second = CalculateValue(SecondMultiplierCollection, cpf);

            return $"{CalculateDigit(first)}{CalculateDigit(second)}";
        }

        static int CalculateValue(int[] weight, int[] numbers)
        {
            var sum = 0;
            for (int i = 0; i < weight.Length; i++) sum += weight[i] * numbers[i];
            return sum;
        }

        static int CalculateDigit(int sum)
        {
            int modResult = (sum % 11);
            return modResult < 2 ? 0 : 11 - modResult;
        }
    }
}
