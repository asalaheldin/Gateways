using Gateways.Ground;
using Gateways.Service.Features.Gateways.Factories;
using Gateways.Service.Features.Gateways.Repositories;
using Gateways.Service.Models;
using Gateways.Service.RequestDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gateways.UseCases.Features.Gateways.Queries.GetStoredGatewaysAndDevicesPaginationQuery
{
    public class GetStoredGatewaysAndDevicesPaginationQuery : IRequest<ServiceResultList<DTOGetGateWay>>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }

    public class GetStoredGatewaysAndDevicesPaginationQueryHandler : IRequestHandler<GetStoredGatewaysAndDevicesPaginationQuery, ServiceResultList<DTOGetGateWay>>
    {
        private readonly IGatewayRepository _repository;
        private readonly IGatewayFactory _factory;

        public GetStoredGatewaysAndDevicesPaginationQueryHandler(IGatewayRepository repository, IGatewayFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }
        public async Task<ServiceResultList<DTOGetGateWay>> Handle(GetStoredGatewaysAndDevicesPaginationQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetGatewaysListAsync(request.Page ?? Constants.DefaultPage, request.PageSize ?? Constants.DefaultPageSize);
            var model = data.Gateways.Select(a => _factory.Create(a)).ToList();
            return new ServiceResultList<DTOGetGateWay>()
            {
                IsValid = true,
                Model = model,
                Count = data.Count,
            };
        }
    }
}
