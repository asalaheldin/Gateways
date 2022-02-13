using Gateways.Data.CustomEntites;
using Gateways.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Service.Features.Gateways.Repositories
{
    public interface IGatewayRepository
    {
        Task<GatewayListCount> GetGatewaysListAsync(int page, int pageSize);
        Task<Gateway> GetGatewayDetailBySerialNumberAsync(string serialNumber);
        Task<bool> AddGatewayWithAssociatedDevices(Gateway data);
    }
}
