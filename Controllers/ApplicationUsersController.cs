using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hackathon_2024_API.Services;
using Hackathon_2024_API.Models;
using Hackathon_2024_API.Schemas;

using Hackathon_2024_API.Data;
using Hackathon_2024_API.Data.Consts;
using System.Reflection.Metadata.Ecma335;

namespace Hackathon_2024_API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class ApplicationUsersController:Controller
    {
        
        private readonly IApplicationUsersService _applicationUsersService;

        public ApplicationUsersController(IApplicationUsersService applicationUsersService) {

            _applicationUsersService = applicationUsersService;


        }

        [HttpPost]
        [Route("create")]
        //[Authorize]
        public async Task<IActionResult> CreateUserAsync([FromBody] ApplicationUsersSchema user) {
            //validaciones
            if(string.IsNullOrEmpty(user.FirstName)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST});
            if(string.IsNullOrEmpty(user.LastName)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(user.Email))return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(user.PictureUrl)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(user.WorkId)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(user.PhoneNumber)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(user.Email)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(user.Password)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            
            var userResult = await _applicationUsersService.GetUserByEmailAsync(user.Email);

            if(userResult != null) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.ENTITY_EXISTS });

            var result = await _applicationUsersService.CreateUserAsync(user);

            if(result == null) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST});

            return Ok(new DataResponse { Data = result.ToDictionary, ErrorMessage= null});
        }

        [HttpGet]
        [Route("id/{id}")]

        public async Task<IActionResult> GetUserByIDAsync(string id)
        {
            if (!Guid.TryParse(id, out _)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });


            var result = await _applicationUsersService.GetUserByIDAsync(id);

            if(result == null) return  BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.OBJECT_NOT_FOUND });

            return Ok(new DataResponse { Data = result.ToDictionary, ErrorMessage = null });
        }

    }
}
