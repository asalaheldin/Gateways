using Gateways.Data.Entities;
using Gateways.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Service.Features.Gateways.Validators
{
    public interface IGatewayValidator
    {
        Task<ValidatorResult> NewGatewayIsNotExistBefore(Gateway existGateway);
        Task<ValidatorResult> AddPeripheralToGatewayAllowed(Gateway existGateway);
    }
}
