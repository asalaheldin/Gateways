using Gateways.Data.Entities;
using Gateways.Service.Features.Gateways.Factories;
using Gateways.Service.Features.Peripherals.Factories;
using Gateways.Service.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateways.Presistance.Features.Gateways.Factories
{
    public class GatewayFactory : IGatewayFactory
    {
        private readonly IPeripheralFactory _peripheralFactory;
        public GatewayFactory(IPeripheralFactory peripheralFactory)
        {
            _peripheralFactory = peripheralFactory;
        }
        public DTOGetGateWay Create(Gateway data)
        {
            return new DTOGetGateWay()
            {
                SerialNumber = data.SerialNumber,
                Name = data.Name,
                IPv4 = data.IPv4,
                AssociatedPeripherals = data.AssociatedPeripherals.Select(x => _peripheralFactory.Create(x)).ToList(),
            };
        }
        public Gateway Create(DTOAddGateway model)
        {
            return new Gateway()
            {
                SerialNumber = model.SerialNumber,
                Name = model.Name,
                IPv4 = model.IPv4,
                AssociatedPeripherals = model.AssociatedPeripherals.Select(x => _peripheralFactory.Create(x)).ToList(),
            };
        }
    }
}
