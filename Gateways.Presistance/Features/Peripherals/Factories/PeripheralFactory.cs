using Gateways.Data.Entities;
using Gateways.Service.Features.Peripherals.Factories;
using Gateways.Service.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Presistance.Features.Peripherals.Factories
{
    public class PeripheralFactory : IPeripheralFactory
    {
        public DTOGetPeripheral Create(Peripheral data)
        {
            return new DTOGetPeripheral()
            {
                UID = data.UID,
                Vendor = data.Vendor,
                Status = data.Status,
                CreatedAt = data.CreateAt
            };
        }

        public Peripheral Create(DTOAddPeripheral model)
        {
            return new Peripheral()
            {
                Vendor = model.Vendor,
                Status = model.Status,
                CreateAt = DateTime.UtcNow,
            };
        }

        public Peripheral Create(DTOAddPeripheralWithGatewaySerialNumber model)
        {
            return new Peripheral()
            {
                GatewaySerialNumber = model.SerialNumber,
                Vendor = model.Vendor,
                Status = model.Status,
                CreateAt = DateTime.UtcNow,
            };
        }
    }
}
