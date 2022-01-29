using Blog.Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.ValidationRules
{
    public class CommentAddValidator : AbstractValidator<CommentAddDto>
    {
        public CommentAddValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Yorum başlığı boş geçilemez.");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("İçerik boş geçilemez.")
                .MinimumLength(50).WithMessage("İçerik 50 karakterden fazla olmalıdır.")
                .MaximumLength(250).WithMessage("İçerik 250 karakterden fazla olmamalıdır.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("True yada False değer girilmelidir.");
            RuleFor(x => x.PostId).GreaterThan(0).WithMessage("Yazı id 0 dan büyük olmalıdır.");
            RuleFor(x => x.AuthorId).GreaterThan(0).WithMessage("Yazar id 0 dan büyük olmalıdır.");

        }
    }
}
