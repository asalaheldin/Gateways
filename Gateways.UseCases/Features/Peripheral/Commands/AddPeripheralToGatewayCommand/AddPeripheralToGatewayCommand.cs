using Gateways.Service.Features.Gateways.Repositories;
using Gateways.Service.Features.Gateways.Validators;
using Gateways.Service.Features.Peripherals.Factories;
using Gateways.Service.Features.Peripherals.Repositories;
using Gateways.Service.Models;
using Gateways.Service.RequestDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gateways.UseCases.Features.Peripheral.Commands.AddPeripheralToGatewayCommand
{
    public class AddPeripheralToGatewayCommand : IRequest<ServiceResultDetail<DTOAddPeripheralWithGatewaySerialNumber>>
    {
        public DTOAddPeripheralWithGatewaySerialNumber DTOAddPeripheralWithGatewaySerialNumber { get; set; }
    }
    public class AddPeripheralToGatewayCommandHandler : IRequestHandler<AddPeripheralToGatewayCommand, ServiceResultDetail<DTOAddPeripheralWithGatewaySerialNumber>>
    {
        private readonly IPeripheralFactory _factory;
        private readonly IPeripheralRepository _peripheralRepository;
        private readonly IGatewayRepository _gatewayRepository;
        private readonly IGatewayValidator _validator;
        public AddPeripheralToGatewayCommandHandler(IPeripheralFactory factory, IPeripheralRepository peripheralRepository
            , IGatewayRepository gatewayRepository
            , IGatewayValidator validator)
        {
            _factory = factory;
            _peripheralRepository = peripheralRepository;
            _gatewayRepository = gatewayRepository;
            _validator = validator;
        }
        public async Task<ServiceResultDetail<DTOAddPeripheralWithGatewaySerialNumber>> Handle(AddPeripheralToGatewayCommand request, CancellationToken cancellationToken)
        {
            var existGateway = await _gatewayRepository.GetGatewayDetailBySerialNumberAsync(request.DTOAddPeripheralWithGatewaySerialNumber.SerialNumber);
            var validationResult = await _validator.AddPeripheralToGatewayAllowed(existGateway);
            if (!validationResult.IsValid)
            {
                return new ServiceResultDetail<DTOAddPeripheralWithGatewaySerialNumber>()
                {
                    IsValid = false,
                    Messages = new List<string>() { validationResult.Message }
                };
            }
            var data = _factory.Create(request.DTOAddPeripheralWithGatewaySerialNumber);
            var result = await _peripheralRepository.AddPeripheralToGateway(data);
            if (result)
            {
                return new ServiceResultDetail<DTOAddPeripheralWithGatewaySerialNumber>()
                {
                    Model = request.DTOAddPeripheralWithGatewaySerialNumber
                };
            }
            return new ServiceResultDetail<DTOAddPeripheralWithGatewaySerialNumber>()
            {
                IsValid = false,
                Messages = new List<string>() { "Something went wrong please report back to system adminstrator" }
            };
        }
    }
}
