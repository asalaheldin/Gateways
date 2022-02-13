using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.UseCases.Features.Gateways.Queries.GetGetwayDetailsBySerialNumberQuery
{
    public class GetGetwayDetailsBySerialNumberQueryValidator : AbstractValidator<GetGetwayDetailsBySerialNumberQuery>
    {
        public GetGetwayDetailsBySerialNumberQueryValidator()
        {
            RuleFor(x => x.SerialNumber).NotNull().WithMessage("The SerialNumber field is required.");
        }
    }
}
