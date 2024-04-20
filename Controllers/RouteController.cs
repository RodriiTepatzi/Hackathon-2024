using Hackathon_2024_API.Core;
using Hackathon_2024_API.Data;
using Hackathon_2024_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Numerics;

namespace Hackathon_2024_API.Controllers
{
	[Route("api/routes")]
	[ApiController]
	public class RouteController : Controller
	{
		private CoordinatesCalculator calculator;

		public RouteController()
		{
			calculator = new CoordinatesCalculator();
		}

		[HttpPost]
		[Route("calculate")]
		public async Task<ActionResult> CalculateRoute([FromBody] Dictionary<string, object> data)
		{
			List<Coordinate> coordinates = JsonConvert.DeserializeObject<List<Coordinate>>(data["coordinates"].ToString());
			Coordinate? startingPoint = data.ContainsKey("startingPoint") ? JsonConvert.DeserializeObject<Coordinate>(data["startingPoint"].ToString()) : null;

			if (coordinates == null || coordinates.Count < 2)
			{
				return BadRequest("Invalid coordinates");
			}

			(List<Coordinate> route, List<float> durations, float totalDuration) = await calculator.NearestRoute(coordinates, startingPoint);

			return Ok(new { route = route, durations = durations, totalDuration = totalDuration });
		}


	}
}
