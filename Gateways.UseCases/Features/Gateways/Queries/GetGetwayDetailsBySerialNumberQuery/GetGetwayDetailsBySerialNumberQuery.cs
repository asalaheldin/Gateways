using Gateways.Service.Features.Gateways.Factories;
using Gateways.Service.Features.Gateways.Repositories;
using Gateways.Service.Models;
using Gateways.Service.RequestDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gateways.UseCases.Features.Gateways.Queries.GetGetwayDetailsBySerialNumberQuery
{
    public class GetGetwayDetailsBySerialNumberQuery : IRequest<ServiceResultDetail<DTOGetGateWay>>
    {
        public string SerialNumber { get; set; }
    }

    public class GetGetwayDetailsBySerialNumberQueryHandler : IRequestHandler<GetGetwayDetailsBySerialNumberQuery, ServiceResultDetail<DTOGetGateWay>>
    {
        private readonly IGatewayRepository _repository;
        private readonly IGatewayFactory _factory;

        public GetGetwayDetailsBySerialNumberQueryHandler(IGatewayRepository repository, IGatewayFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }
        public async Task<ServiceResultDetail<DTOGetGateWay>> Handle(GetGetwayDetailsBySerialNumberQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetGatewayDetailBySerialNumberAsync(request.SerialNumber);
            var model = _factory.Create(data);
            return new ServiceResultDetail<DTOGetGateWay>()
            {
                IsValid = true,
                Model = model,
            };
        }
    }
}
