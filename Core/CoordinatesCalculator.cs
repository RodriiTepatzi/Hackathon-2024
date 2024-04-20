using Hackathon_2024_API.Models;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System.Numerics;

namespace Hackathon_2024_API.Core
{
	public class CoordinatesCalculator
	{
		private HttpClient client;

		public CoordinatesCalculator()
		{
			client = new HttpClient();
		}

		public async Task<(float distance, float duration)> Distance(Coordinate point1, Coordinate point2)
		{
			string profile = "mapbox/driving";
			string coordinates = $"{point1.Longitude},{point1.Latitude};{point2.Longitude},{point2.Latitude}";
			string url = $"https://api.mapbox.com/directions/v5/{profile}/{coordinates}?access_token=pk.eyJ1Ijoicm9kcmlpdGVwYXR6aSIsImEiOiJjbHJwcDhjMHkwOGo5Mmxsa3BsNWZ2bWgzIn0.ZMfAkCGD-Q4sr4Phb1_RNg";

			HttpResponseMessage response = await client.GetAsync(url);
			string responseBody = await response.Content.ReadAsStringAsync();
			dynamic? result = JsonConvert.DeserializeObject(responseBody);

			return (result?.routes[0].distance, result?.routes[0].duration);
		}

		public async Task<(List<Coordinate> route, List<float> durations, float totalDuration)> NearestRoute(List<Coordinate> coordinates, Coordinate? startingPoint)
		{
			if (startingPoint == null)
			{
				startingPoint = coordinates[0];
			}
			else if (coordinates.Where(p => p.Latitude == startingPoint.Latitude && p.Longitude == startingPoint.Longitude).ToList().Count < 1)
			{
				throw new ArgumentException("Starting point must be in the list of coordinates");
			}

			Coordinate currentPoint = startingPoint;
			List<Coordinate> route = new List<Coordinate>();
			List<float> durations = new List<float>();
			coordinates.Remove(currentPoint);
			float totalDuration = 0;

			while (coordinates.Count > 0)
			{
				List<Task<(float distance, float duration)>> distancesAndDurations = coordinates.Select(point => Distance(currentPoint, point)).ToList();

				(float distance, float duration)[] completedDistancesAndDurations = await Task.WhenAll(distancesAndDurations);

				Coordinate nearestPoint = coordinates[Array.IndexOf(completedDistancesAndDurations, completedDistancesAndDurations.Min())];

				route.Add(currentPoint);
				durations.Add(completedDistancesAndDurations.Min().duration);
				totalDuration += completedDistancesAndDurations.Min().duration;

				coordinates.Remove(nearestPoint);
				currentPoint = nearestPoint;
			}

			route.Add(currentPoint);
			route.RemoveAt(0);

			return (route, durations, totalDuration);
		}
	}
}