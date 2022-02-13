using Gateways.Data.Entities;
using Gateways.Service.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Service.Features.Peripherals.Factories
{
    public interface IPeripheralFactory
    {
        DTOGetPeripheral Create(Peripheral data);
        Peripheral Create(DTOAddPeripheral model);
        Peripheral Create(DTOAddPeripheralWithGatewaySerialNumber model);
    }
}
