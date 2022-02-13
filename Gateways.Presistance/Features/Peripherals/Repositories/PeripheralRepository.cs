using Gateways.Data.Entities;
using Gateways.Presistance.DBContext;
using Gateways.Service.Features.Peripherals.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Presistance.Features.Peripherals.Repositories
{
    public class PeripheralRepository : IPeripheralRepository
    {
        private readonly GatewaysContext _context;

        public PeripheralRepository(GatewaysContext context)
        {
            _context = context;
        }
        public async Task<bool> AddPeripheralToGateway(Peripheral data)
        {
            await _context.Peripherals.AddAsync(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<Peripheral> GetPeripheralBySerialNumberAndUID(string serialNumber, int uid)
        {
            return await _context.Peripherals.FirstOrDefaultAsync(x => x.GatewaySerialNumber == serialNumber && x.UID == uid);
        }
        public async Task<bool> DeletePeripheralFromGateway(Peripheral data)
        {
            _context.Peripherals.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
