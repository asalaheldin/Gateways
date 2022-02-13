using FluentValidation;
using Gateways.Service.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateways.UseCases.Features.Gateways.Commands.AddGatewayWithAssociatedDevicesCommand
{
    public class AddGatewayWithAssociatedDevicesCommandValidator : AbstractValidator<AddGatewayWithAssociatedDevicesCommand>
    {
        public AddGatewayWithAssociatedDevicesCommandValidator()
        {
            //Required fields
            RuleFor(x => x.DTOAddGateway.SerialNumber).NotNull().WithMessage("The SerialNumber field is required.");
            RuleFor(x => x.DTOAddGateway.Name).NotNull().WithMessage("The Name field is required.");

            RuleForEach(x => x.DTOAddGateway.AssociatedPeripherals).ChildRules(p =>
            p.RuleFor(x => x.Vendor).NotNull().WithMessage("The Vendor field is required for associated peripheral #{CollectionIndex}"));

            RuleForEach(x => x.DTOAddGateway.AssociatedPeripherals).ChildRules(p =>
            p.RuleFor(x => x.Status).NotNull().WithMessage("The Status field is required for associated peripheral #{CollectionIndex}"));

            //Other validations
            //1- IPv4 address validation
            RuleFor(x => x.DTOAddGateway.IPv4).Custom((ipString, context) =>
            {
                if (String.IsNullOrWhiteSpace(ipString))
                {
                    context.AddFailure("The IPv4 field is required.");
                }

                string[] splitValues = ipString.Split('.');
                if (splitValues.Length != 4)
                {
                    context.AddFailure("The IPv4 field isn't in a valid format - It must contains four parts separated by '.' symbol");
                }

                byte tempForParsing;
                if (!splitValues.All(r => byte.TryParse(r, out tempForParsing)))
                    context.AddFailure("The IPv4 field isn't in a valid format - format must be in form of 127.0.0.1 for example.");

            });

            //2- Associated peripherals can't exceed 10 for a single gateway
            RuleFor(x => x.DTOAddGateway.AssociatedPeripherals).Must(list => list.Count <= 10)
                .WithMessage("No more 10 peripheral devices are allowed for a gateway");

        }
    }
}
