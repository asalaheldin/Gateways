using Gateways.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Service.Features.Peripherals.Repositories
{
    public interface IPeripheralRepository
    {
        Task<bool> AddPeripheralToGateway(Peripheral data);
        Task<Peripheral> GetPeripheralBySerialNumberAndUID(string serialNumber, int uid);
        Task<bool> DeletePeripheralFromGateway(Peripheral data);
    }
}
