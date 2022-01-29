using Blog.Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.ValidationRules
{
    public class AuthorAddValidator:AbstractValidator<AuthorAddDto>
    {
        public AuthorAddValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Yazar soyadı boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email doğru biçimde gerilmemiş.");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Şifre 8 karakterden fazla olmalıdır.")
                .MaximumLength(16).WithMessage("Şifre 16 karakterden büyük olmamalıdır.");
            RuleFor(x => x.About).MinimumLength(50).WithMessage("Hakkında alanı 50 karakterden fazla olmalıdır");
        }
    }
}

