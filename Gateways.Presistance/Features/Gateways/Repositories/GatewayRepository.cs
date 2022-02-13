using Gateways.Data.CustomEntites;
using Gateways.Data.Entities;
using Gateways.Presistance.DBContext;
using Gateways.Service.Features.Gateways.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Presistance.Features.Gateways.Repositories
{
    public class GatewayRepository : IGatewayRepository
    {
        private readonly GatewaysContext _context;

        public GatewayRepository(GatewaysContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get Gateways with devices using pagination
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>custom data that contains the gateways list data as well as the total data in the database to calculate the pagination header </returns>
        public async Task<GatewayListCount> GetGatewaysListAsync(int page, int pageSize)
        {
            return new GatewayListCount()
            {
                Gateways = await _context.Gateways
                .Include(x => x.AssociatedPeripherals)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(),
                Count = await _context.Gateways.CountAsync()
            };
        }
        /// <summary>
        /// Get Gateway data by Serial number with its details
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns>Gateway details with its associated devices </returns>
        public async Task<Gateway> GetGatewayDetailBySerialNumberAsync(string serialNumber)
        {
            return await _context.Gateways
                .Include(x => x.AssociatedPeripherals)
                .FirstOrDefaultAsync(x => x.SerialNumber == serialNumber);
        }
        public async Task<bool> AddGatewayWithAssociatedDevices(Gateway data)
        {
            await _context.Gateways.AddAsync(data);
            return await _context.SaveChangesAsync();
        }
    }
}
