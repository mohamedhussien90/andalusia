using Assignment_8.DTOs;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace Assignment_8.Validators
{
    public class UpdateTaskRequestValidator : AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.")
                .Must(HaveNoHtmlTags).WithMessage("Title cannot contain HTML tags.");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.UtcNow).WithMessage("Due date must be in the future.")
                .When(x => x.DueDate.HasValue);
        }

        private bool HaveNoHtmlTags(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return true;
            return !Regex.IsMatch(title, "<.*?>");
        }
    }
}
