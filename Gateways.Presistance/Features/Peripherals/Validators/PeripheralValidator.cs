using Gateways.Data.Entities;
using Gateways.Service.Features.Peripherals.Validators;
using Gateways.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Presistance.Features.Peripherals.Validators
{
    public class PeripheralValidator : IPeripheralValidator
    {
        public async Task<ValidatorResult> DeletedPeripheralExists(Peripheral existPerpheral)
        {
            if(existPerpheral == null)
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = $"This peripheral doesn't exist within the gateway with this serial number, and can't be deleted",
                };
            return new ValidatorResult();
        }
    }
}
