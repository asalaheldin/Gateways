using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateways.Ground;
using Gateways.Service.RequestDTOs;
using Gateways.UseCases.Features.Gateways.Commands.AddGatewayWithAssociatedDevicesCommand;
using Gateways.UseCases.Features.Gateways.Queries.GetGetwayDetailsBySerialNumberQuery;
using Gateways.UseCases.Features.Gateways.Queries.GetStoredGatewaysAndDevicesPaginationQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class GatewayController : BaseController
    {
        /// <summary>
        /// Get list of gateways with their devices
        /// </summary>
        /// <param name="request"></param>
        /// <returns>List of gateways with their devices</returns>
        [HttpGet]
        [Route("gateways", Name = "GetGatewaysList")]
        public async Task<IActionResult> GetGatewaysList([FromQuery] GetStoredGatewaysAndDevicesPaginationQuery request)
        {
            var result = await Mediator.Send(request);
            return GetApiResponse(result, request.Page ?? Constants.DefaultPage, request.PageSize ?? Constants.DefaultPageSize);
        }
        /// <summary>
        /// Get gateway by serial number
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Gateway details with devices</returns>

        [HttpGet]
        [Route("gateways/{serialNumber}", Name = "GetGatewayBySerialNumber")]
        public async Task<IActionResult> GetGatewayBySerialNumber(string serialNumber)
        {
            var result = await Mediator.Send(new GetGetwayDetailsBySerialNumberQuery() { SerialNumber = serialNumber });
            return GetApiResponse(result);
        }
        /// <summary>
        /// Add Gateway with associated devices
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Added gateway with devices details</returns>
        [HttpPost]
        [Route("gateways")]
        public async Task<IActionResult> FinishStudentExam(DTOAddGateway model)
        {
            var result = await Mediator.Send(new AddGatewayWithAssociatedDevicesCommand { DTOAddGateway = model });
            return GetApiResponse(result);
        }
    }
}