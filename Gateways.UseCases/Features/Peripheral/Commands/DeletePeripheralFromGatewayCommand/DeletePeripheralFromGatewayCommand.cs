using Gateways.Service.Features.Gateways.Validators;
using Gateways.Service.Features.Peripherals.Repositories;
using Gateways.Service.Features.Peripherals.Validators;
using Gateways.Service.Models;
using Gateways.Service.RequestDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gateways.UseCases.Features.Peripheral.Commands.DeletePeripheralFromGatewayCommand
{
    public class DeletePeripheralFromGatewayCommand : IRequest<ServiceResultDetail<DTODeletePeripheralWithSerialNumber>>
    {
        public DTODeletePeripheralWithSerialNumber DTODeletePeripheralWithSerialNumber { get; set; }
    }
    public class DeletePeripheralFromGatewayCommandHandler : IRequestHandler<DeletePeripheralFromGatewayCommand, ServiceResultDetail<DTODeletePeripheralWithSerialNumber>>
    {
        private readonly IPeripheralRepository _repository;
        private readonly IPeripheralValidator _validator;
        public DeletePeripheralFromGatewayCommandHandler(IPeripheralRepository repository
            , IPeripheralValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<ServiceResultDetail<DTODeletePeripheralWithSerialNumber>> Handle(DeletePeripheralFromGatewayCommand request, CancellationToken cancellationToken)
        {
            var existPeripheral = await _repository.GetPeripheralBySerialNumberAndUID(request.DTODeletePeripheralWithSerialNumber.SerialNumber, request.DTODeletePeripheralWithSerialNumber.UID);
            var validationResult = await _validator.DeletedPeripheralExists(existPeripheral);
            if (!validationResult.IsValid)
            {
                return new ServiceResultDetail<DTODeletePeripheralWithSerialNumber>()
                {
                    IsValid = false,
                    Messages = new List<string>() { validationResult.Message }
                };
            }
            var result = await _repository.DeletePeripheralFromGateway(existPeripheral);
            if (result)
            {
                return new ServiceResultDetail<DTODeletePeripheralWithSerialNumber>()
                {
                    Model = request.DTODeletePeripheralWithSerialNumber
                };
            }
            return new ServiceResultDetail<DTODeletePeripheralWithSerialNumber>()
            {
                IsValid = false,
                Messages = new List<string>() { "Something went wrong please report back to system adminstrator" }
            };
        }

        
    }
}
