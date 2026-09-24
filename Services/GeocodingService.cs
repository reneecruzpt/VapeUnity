using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VapeUnity.Models;

namespace VapeUnity.Services
{
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    namespace VapeUnity.Services
    {
        public class GeocodingService
        {
            private readonly HttpClient httpClient;
            private readonly string apiKey;

            public GeocodingService(string apiKey)
            {
                httpClient = new HttpClient();
                this.apiKey = apiKey;
                httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/geocode/");
            }

            public async Task<AddressResult> GetAddress(string streetName)
            {
                string encodedStreetName = Uri.EscapeDataString(streetName);
                string url = $"json?address={encodedStreetName}&key={apiKey}";

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var geocodingResult = JsonSerializer.Deserialize<GeocodingResult>(json);

                    if (geocodingResult.Status == "OK" && geocodingResult.Results.Length > 0)
                    {
                        var result = geocodingResult.Results[0];

                        return new AddressResult
                        {
                            FormattedAddress = result.FormattedAddress,
                            Lat = result.Geometry.Location.Lat.ToString(),
                            Lng = result.Geometry.Location.Lng.ToString()
                        };
                    }
                }

                return null;
            }

            internal Task GetAddress(string streetName, object value)
            {
                throw new NotImplementedException();
            }
        }
    }

}
