using FluentValidation;
using Proje.DTO.DTOs.GorevDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.ToDo.Business.ValidationRules.FluentValidation
{
    public class GorevUpdateValidator : AbstractValidator<GorevUpdateDto>
    {
        public GorevUpdateValidator()
        {
            RuleFor(I => I.Ad).NotNull().WithMessage("Ad alanı gereklidir");
            RuleFor(I => I.AciliyetId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz");

        }
    }
}