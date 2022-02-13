using Gateways.Data.Entities;
using Gateways.Service.Features.Gateways.Validators;
using Gateways.Service.Models;
using Gateways.Service.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Presistance.Features.Gateways.Validators
{
    public class GatewayValidator : IGatewayValidator
    {
        public async Task<ValidatorResult> NewGatewayIsNotExistBefore(Gateway existGateway)
        {
            if (existGateway != null)
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = $"Gateway with serial number: {existGateway.SerialNumber} is already exists",
                };
            return new ValidatorResult();
        }
        public async Task<ValidatorResult> AddPeripheralToGatewayAllowed(Gateway existGateway)
        {
            var tasks = new List<Task<ValidatorResult>>()
                    {
                        PeripheralCountWithinRange(existGateway?.AssociatedPeripherals?.Count ?? 0),
                        GatewayExists(existGateway)
                    };
            await Task.WhenAll(tasks);
            var result = tasks.Select(a => a.Result).FirstOrDefault(a => !a.IsValid);
            if (result != null)
                return result;
            return new ValidatorResult();

        }
        private async Task<ValidatorResult> PeripheralCountWithinRange(int count)
        {
            if(count > 10)
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = $"Gateway has more than 10 peripherlas already, no more peripherals are allowed",
                };
            return new ValidatorResult();
        }
        private async Task<ValidatorResult> GatewayExists(Gateway existGateway)
        {
            if(existGateway == null)
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = $"No gateway with this serial number is exist",
                };
            return new ValidatorResult();
        }
    }
}
