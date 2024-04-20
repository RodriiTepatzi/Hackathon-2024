using Hackathon_2024_API.Models;
using Hackathon_2024_API.Services;
using Microsoft.AspNetCore.Mvc;
using Hackathon_2024_API.Schemas;
using Hackathon_2024_API.Data.Consts;
using Hackathon_2024_API.Data;

namespace Hackathon_2024_API.Controllers
{

    [ApiController]
    [Route("api/shipings")]
    public class ShipingController:Controller
    {

        private readonly IShipingService _shipingService;

        public ShipingController(IShipingService shipingService) { 
            _shipingService = shipingService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateShipingAsync([FromBody]ShipingSchema shipingSchema) {

            if (!Guid.TryParse(shipingSchema.IdCarrier, out _)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if (string.IsNullOrEmpty(shipingSchema.Status)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });

            var shiping = new Shiping { 
                Status = shipingSchema.Status,
                Id = new Guid().ToString(),
            };

            var result = await _shipingService.CreateShipingAsync(shiping);


            return Ok(new DataResponse { Data = shiping.Dictionary, ErrorMessage = null });
        }

        [HttpGet]
        [Route("id/{id}")]
        public async Task<IActionResult> GetShipingByIdAsync(string id) {

            if (!Guid.TryParse(id, out _)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });


            var result = await _shipingService.GetShipingByIdAsync(id);

            if (result == null) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.OBJECT_NOT_FOUND });

            return Ok(new DataResponse { Data = result.Dictionary, ErrorMessage = null });
        }

        [HttpGet]
        [Route("carrier/{idcarrier}")]

        public async Task<IActionResult> GetShipingsByCarrier(string idCarrier)
        {

            if (!Guid.TryParse(idCarrier, out _)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });


            var result = await _shipingService.GetShipingsByCarrierAsync(idCarrier);

            if (result == null) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.OBJECT_NOT_FOUND });

            var data = new List<Dictionary<string, object>>();

            foreach (var item in result) data.Add(item.Dictionary);

            if (result.Count > 0) return Ok(new DataResponse { Data = data, ErrorMessage = null });

            return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.OBJECT_NOT_FOUND });

        }




    }
}
