using FluentValidation;
using RetoBackendBCP.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RetoBackendBCP.Common
{
    public class DivisaValidator : AbstractValidator<DivisaRequest>
    {
        public DivisaValidator()
        {
            RuleFor(x => x.MontoInicial)
                      .NotNull()
                      .WithMessage("{PropertyName} es requerido.")
                      .GreaterThan(0)
                      .WithMessage("{PropertyName} debe ser mayor que 0.");
            RuleFor(x => x.MonedaOrigen)
                      .NotEmpty().WithMessage("{PropertyName} es requerido.")
                      .Length(3, 3).WithMessage("{PropertyName} debe contener {MaxLength} caracteres")
                      .Must(receivingCurrency => ISO._4217.CurrencyCodesResolver.Codes
                      .Any(c => c.Code == receivingCurrency)).WithMessage("{PropertyName} debe ser un código de divisa válido (ISO 4217).");

            RuleFor(x => x.MonedaDestino)
                      .NotEmpty().WithMessage("{PropertyName} es requerido.")
                      .Length(3, 3).WithMessage("{PropertyName} debe contener {MaxLength} caracteres")
                      .Must(receivingCurrency => ISO._4217.CurrencyCodesResolver.Codes
                      .Any(c => c.Code == receivingCurrency)).WithMessage("{PropertyName} debe ser un código de divisa válido (ISO 4217).")
                      .NotEqual(x => x.MonedaOrigen)
                      .WithMessage("monedaOrigen es igual a monedaDestino");
        }
    }
}
