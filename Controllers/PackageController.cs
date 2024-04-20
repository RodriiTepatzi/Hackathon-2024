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

            //get lat and lon
            string token = "pk.eyJ1Ijoicm9kcmV4MjUiLCJhIjoiY2x2N3NyNThoMDJ0ZzJxbDZyemU2ZXdsciJ9.ld6FzWNvU59_UGdbGjBF7w";
            string direccion = packageSchema.ClientAddress.Replace(" ", "+");
            string url = "https://api.mapbox.com/search/searchbox/v1/suggest?q=" + direccion + "&language=en&access_token=" + token;

            List<GetMapBox> mapBoxList = await GetResponseFromApi(url);
            string mapBoxId = mapBoxList[0].mapbox_id; 

            string url2 = "https://api.mapbox.com/search/searchbox/v1/retrieve/" + mapBoxId + "&access_token=" + token;



            List<GetLatLon> latLon = await GetLonLanFromApi(url2);
            double latitud = latLon[0].latitude;
            double longitud = latLon[0].longitude;



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
                Latitude = latitud,
                Longuitud = longitud,
                IdShiping = " ",
                PackagePictureUrl = packageSchema.PackagePictureUrl,
             


        };



            return null;
        }

        //GET: 

        public async Task<List<GetMapBox>> GetResponseFromApi(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<GetMapBox> mapBox = JsonSerializer.Deserialize<List<GetMapBox>>(content);
                    return mapBox;
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

        public async Task<List<GetLatLon>> GetLonLanFromApi(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<GetLatLon> lonLanList = JsonSerializer.Deserialize<List<GetLatLon>>(content);
                    return lonLanList;
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

    }
}
