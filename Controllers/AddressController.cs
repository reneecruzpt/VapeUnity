using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VapeUnity.Services;
using VapeUnity.Models;
using VapeUnity.Services.VapeUnity.Services;


namespace VapeUnity.Controllers
{
    public class AddressController : Controller
    {
        private readonly GeocodingService geocodingService;

        public AddressController(GeocodingService geocodingService)
        {
            this.geocodingService = geocodingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string streetName)
        {
            var result = await geocodingService.GetAddress(streetName);

            if (result != null)
            {
                var addressResult = new Models.AddressResult
                {
                    FormattedAddress = result.FormattedAddress,
                    Lat = result.Lat,
                    Lng = result.Lng,
                };


                return View("Result", addressResult);
            }

            return View("NotFound");
        }
    }
}
