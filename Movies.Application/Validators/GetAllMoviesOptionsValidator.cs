﻿using FluentValidation;
using Movies.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Validators
{
    public class GetAllMoviesOptionsValidator : AbstractValidator<GetAllMoviesOptions>
    {
        private static readonly string[] AcceptableSortFields =
        {
            "title",
            "yearofrelease"
        };
        public GetAllMoviesOptionsValidator()
        {
            RuleFor(x => x.YearOfRelease)
                .LessThanOrEqualTo(DateTime.UtcNow.Year);
            RuleFor(x => x.SortField)
                .Must(x => x is null || AcceptableSortFields.Contains(x, StringComparer.OrdinalIgnoreCase))
                .WithMessage("You can either sort by 'title' or 'yearofrelease'.");

            RuleFor(x => x.Page)
                .InclusiveBetween(1, 25)
                .WithMessage("You can get between 1 and 25 per page");
        }
    }
}
