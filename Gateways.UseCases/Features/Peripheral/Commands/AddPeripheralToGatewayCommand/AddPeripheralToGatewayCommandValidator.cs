using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.UseCases.Features.Peripheral.Commands.AddPeripheralToGatewayCommand
{
    public class AddPeripheralToGatewayCommandValidator : AbstractValidator<AddPeripheralToGatewayCommand>
    {
        public AddPeripheralToGatewayCommandValidator()
        {
            //Required fields
            RuleFor(x => x.DTOAddPeripheralWithGatewaySerialNumber.SerialNumber).NotNull().WithMessage("The SerialNumber field is required.");
            RuleFor(x => x.DTOAddPeripheralWithGatewaySerialNumber.Vendor).NotNull().WithMessage("The Vendor field is required.");
            RuleFor(x => x.DTOAddPeripheralWithGatewaySerialNumber.Status).NotNull().WithMessage("The Status field is required.");
        }
    }
}
