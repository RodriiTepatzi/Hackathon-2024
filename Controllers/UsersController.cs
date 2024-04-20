using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hackathon_2024_API.Services;
using Hackathon_2024_API.Models;
using Hackathon_2024_API.Schemas;

using Hackathon_2024_API.Data;
using Hackathon_2024_API.Data.Consts;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;

namespace Hackathon_2024_API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        
        private readonly IUsersService _applicationUsersService;

        public UsersController(IUsersService applicationUsersService) {

            _applicationUsersService = applicationUsersService;
        }

        [Route("create")]
		[HttpPost]
		//[Authorize]
		public async Task<IActionResult> CreateUserAsync([FromBody] UsersSchema user) {
            //validaciones
            if(string.IsNullOrEmpty(user.FirstName)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST});
            if(string.IsNullOrEmpty(user.LastName)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(user.Email))return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(user.WorkId)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(user.Email)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            if(string.IsNullOrEmpty(user.Password)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });
            
            var userResult = await _applicationUsersService.GetUserByEmailAsync(user.Email);

            if(userResult != null) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.ENTITY_EXISTS });

            var result = await _applicationUsersService.CreateUserAsync(user);

            if(result == null) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST});

            return Ok(new DataResponse { Data = result.ToDictionary, ErrorMessage= null});
        }


        [Route("email/{email}")]
		[HttpGet]
		public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.BAD_REQUEST });

            var result = await _applicationUsersService.GetUserByEmailAsync(email);

            if (result == null) return BadRequest(new DataResponse { Data = null, ErrorMessage = ResponseMessages.OBJECT_NOT_FOUND });

            return Ok(new DataResponse { Data = result.ToDictionary, ErrorMessage = null });

        }

    }
}
