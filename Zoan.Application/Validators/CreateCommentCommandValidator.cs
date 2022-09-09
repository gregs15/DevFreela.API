using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Application.Commands.CreateComment;

namespace Zoan.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator <CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(p => p.Content)
                .MaximumLength(255)
                .WithMessage("Tamanha máximo na descrição do comentário é  de 255 caracteres");
        }
    }
}
