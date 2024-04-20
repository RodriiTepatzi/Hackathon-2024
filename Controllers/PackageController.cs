using Hackathon_2024_API.Schemas;
using Hackathon_2024_API.Services;
using Microsoft.AspNetCore.Mvc;
using Hackathon_2024_API.Data;
using Hackathon_2024_API.Data.Consts;
using Hackathon_2024_API.Models;
using System.Text.Json;

namespace Hackathon_2024_API.Controllers
{

    [ApiController]
    [Route("api/packages")]
    public class PackageController:Controller
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePackageAsync([FromBody] PackageSchema packageSchema) {

            if(packageSchema.Weight <= 0) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST});
            if(packageSchema.Height <= 0) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(packageSchema.Width <= 0) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(packageSchema.Lenghth <= 0)  return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(packageSchema.ClientAddress)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(packageSchema.ClientFullName))  return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(packageSchema.ClientPhone)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(packageSchema.PackagePictureUrl)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });



            var package = new Package
            {
                Id = new Guid().ToString(),
                Weight = packageSchema.Weight,
                Height = packageSchema.Height,
                Width = packageSchema.Width,
                Lenghth = packageSchema.Lenghth,
                EntranceDate = DateTime.Now,
                ClientAddress = packageSchema.ClientAddress,
                ClientFullName = packageSchema.ClientFullName,
                ClientPhone = packageSchema.ClientPhone,
                PackageStatus = "onWareHouse",
                IdShiping = " ",
                PackagePictureUrl = packageSchema.PackagePictureUrl,
			};



            return null;
        }
    }
}
