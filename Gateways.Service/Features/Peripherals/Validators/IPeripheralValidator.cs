using Gateways.Data.Entities;
using Gateways.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Service.Features.Peripherals.Validators
{
    public interface IPeripheralValidator
    {
        Task<ValidatorResult> DeletedPeripheralExists(Peripheral existPerpheral);
    }
}
