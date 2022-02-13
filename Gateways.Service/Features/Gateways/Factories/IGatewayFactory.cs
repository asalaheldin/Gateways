using Gateways.Data.Entities;
using Gateways.Service.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Service.Features.Gateways.Factories
{
    public interface IGatewayFactory
    {
        DTOGetGateWay Create(Gateway data);
        Gateway Create(DTOAddGateway model);
    }
}
