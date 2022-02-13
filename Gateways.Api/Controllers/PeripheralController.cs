using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateways.Service.RequestDTOs;
using Gateways.UseCases.Features.Peripheral.Commands.AddPeripheralToGatewayCommand;
using Gateways.UseCases.Features.Peripheral.Commands.DeletePeripheralFromGatewayCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class PeripheralController : BaseController
    {
        /// <summary>
        /// Add peripheral to gateway
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Added peripheral</returns>
        [HttpPost]
        [Route("peripherals")]
        public async Task<IActionResult> FinishStudentExam(DTOAddPeripheralWithGatewaySerialNumber model)
        {
            var result = await Mediator.Send(new AddPeripheralToGatewayCommand { DTOAddPeripheralWithGatewaySerialNumber = model });
            return GetApiResponse(result);
        }
        /// <summary>
        /// remove peripheral
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("peripherals")]
        public async Task<IActionResult> DeletePeripheral(DTODeletePeripheralWithSerialNumber model)
        {
            var result = await Mediator.Send(new DeletePeripheralFromGatewayCommand { DTODeletePeripheralWithSerialNumber = model });
            return GetApiResponse(result);
        }
    }
}