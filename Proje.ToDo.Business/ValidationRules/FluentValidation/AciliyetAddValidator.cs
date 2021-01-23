using FluentValidation;
using Proje.DTO.DTOs.AciliyetDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.ToDo.Business.ValidationRules.FluentValidation
{
   public class AciliyetAddValidator:AbstractValidator<AciliyetAddDto>
    {
        public AciliyetAddValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
