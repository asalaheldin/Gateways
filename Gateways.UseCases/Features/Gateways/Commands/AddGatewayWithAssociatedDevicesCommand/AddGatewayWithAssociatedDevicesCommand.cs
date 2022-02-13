using Gateways.Service.Features.Gateways.Factories;
using Gateways.Service.Features.Gateways.Repositories;
using Gateways.Service.Features.Gateways.Validators;
using Gateways.Service.Models;
using Gateways.Service.RequestDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gateways.UseCases.Features.Gateways.Commands.AddGatewayWithAssociatedDevicesCommand
{
    public class AddGatewayWithAssociatedDevicesCommand : IRequest<ServiceResultDetail<DTOAddGateway>>
    {
        public DTOAddGateway DTOAddGateway { get; set; }
    }
    public class AddGatewayWithAssociatedDevicesCommandHandler : IRequestHandler<AddGatewayWithAssociatedDevicesCommand, ServiceResultDetail<DTOAddGateway>>
    {
        private readonly IGatewayFactory _factory;
        private readonly IGatewayRepository _repository;
        private readonly IGatewayValidator _validator;
        public AddGatewayWithAssociatedDevicesCommandHandler(IGatewayFactory factory, IGatewayRepository repository, IGatewayValidator validator)
        {
            _factory = factory;
            _repository = repository;
            _validator = validator;
        }
        public async Task<ServiceResultDetail<DTOAddGateway>> Handle(AddGatewayWithAssociatedDevicesCommand request, CancellationToken cancellationToken)
        {
            var existGateway = await _repository.GetGatewayDetailBySerialNumberAsync(request.DTOAddGateway.SerialNumber);
            var validationResult = await _validator.NewGatewayIsNotExistBefore(existGateway);
            if(!validationResult.IsValid)
            {
                return new ServiceResultDetail<DTOAddGateway>()
                {
                    IsValid = false,
                    Messages = new List<string>() { validationResult.Message }
                };
            }
            var data = _factory.Create(request.DTOAddGateway);
            var result = await _repository.AddGatewayWithAssociatedDevices(data);
            if(result)
            {
                return new ServiceResultDetail<DTOAddGateway>()
                {
                    Model = request.DTOAddGateway
                };
            }
            return new ServiceResultDetail<DTOAddGateway>()
            {
                IsValid = false,
                Messages = new List<string>() { "Something went wrong please report back to system adminstrator" }
            };
        }
    }
}
