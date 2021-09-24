using System.Net.Http.Headers;
using System.Text.Json;
using Thermometer.GitHub;

namespace Thermometer.Netatmo
{
    public class NetatmoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly string _clientId = "614c5ffef29af66fc256ed1e"; // TODO: remove
        private readonly string _clientSecret = "EECIwh18cZ3ZNiYotj0kzsMFiNHcv8vD1QIka7"; // TODO: remove
        private readonly string _scope = "read_station"; // scopes space separated: se https://dev.netatmo.com/apidocumentation/oauth#scopes

        public static Token? CurrentToken;

        public string _indoorModule = "70:ee:50:35:df:88";
        public string _outdoorModule = "02:00:00:2c:96:5e";

        public NetatmoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task Authorize()
        {
            var state = Guid.NewGuid();
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add("client_id", _clientId);
                //client.DefaultRequestHeaders.Add("redirect_uri", _redirectUri);
                httpClient.DefaultRequestHeaders.Add("scope", _scope);
                httpClient.DefaultRequestHeaders.Add("state", state.ToString());

                var stringTask = httpClient.GetAsync(NetatmoUrls.AuthorizeUrl);

                var msg = await stringTask;
                Console.Write(msg);
            }
        }

        public async Task Login()
        {
            var userName = "odalauten@gmail.com";
            var password = "D:hack2021";
            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", _clientId),
                new KeyValuePair<string, string>("client_secret", _clientSecret),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("scope", _scope),
            };
            var content = new FormUrlEncodedContent(values);
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage response = await httpClient.PostAsync(NetatmoUrls.RequestTokenUrl, content);
                if (!response.IsSuccessStatusCode)
                {
                    CurrentToken = null;
                    throw new Exception("Unauthorized." + response.StatusCode);
                }
                var strtoken = await response.Content.ReadAsStringAsync();
                CurrentToken = JsonSerializer.Deserialize<Token>(strtoken);
            }
           
        }

        public async Task<NetatmoResponse> GetNetatmoWeatherDataAsync()
        {
            if (CurrentToken == null)
            {
                await Login();
            }

            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var values = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("access_token", CurrentToken.AccessToken),
                    new KeyValuePair<string, string>("device_id", _indoorModule),
                };
                var content = new FormUrlEncodedContent(values);

                var response = await httpClient.PostAsync(NetatmoUrls.GetStationsDataUrl, content);
                var datastr = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<NetatmoResponse>(datastr);
            }
        }

        public async Task<NetatmoMeasureResponse> GetMeasureAsync()
        {
            return await GetMeasureAsync(_indoorModule, _outdoorModule);
        }

        public async Task<NetatmoMeasureResponse> GetMeasureAsync(string deviceId, string moduleId)
        {
            if (CurrentToken == null)
            {
                await Login();
            }

            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var values = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("access_token", CurrentToken.AccessToken),
                    new KeyValuePair<string, string>("device_id", deviceId),
                    new KeyValuePair<string, string>("module_id", moduleId),
                    new KeyValuePair<string, string>("scale", "max"),
                    //new KeyValuePair<string, string>("limit", "10"),
                    new KeyValuePair<string, string>("date_begin", DateTimeHelper.UtcDateTimeToTimeStamp(DateTime.UtcNow.AddMinutes(-100)).ToString()),
                    new KeyValuePair<string, string>("type", "Temperature,Humidity,Co2,Noise,Pressure"),
                };
                var content = new FormUrlEncodedContent(values);

                var response = await httpClient.PostAsync(NetatmoUrls.GetMeasureUrl, content);
                var datastr = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<NetatmoMeasureResponse>(datastr);
            }
        }

        public async Task<Measurement> GetLatestMeasurementIndoor()
        {
            return await GetLatestMeasurement(_indoorModule, _indoorModule);
        }

        public async Task<Measurement> GetLatestMeasurementOutdoor()
        {
            return await GetLatestMeasurement(_indoorModule, _outdoorModule);
        }

        public async Task<Measurement> GetLatestMeasurement(string deviceId, string moduleId)
        {
            var list = new List<Measurement>();
            var response = await GetMeasureAsync(deviceId, moduleId);
            foreach (var measureSet in response.Measurements)
            {
                var time = measureSet.StartTime;
                foreach (var measure in measureSet.Value)
                {
                    list.Add(new Measurement
                    {
                        MeasureTime = DateTimeHelper.TimeStampToLocalDateTime(time),
                        Temperature = measure.Count > 0 ? measure[0] : null,
                        Humidity = measure.Count > 1 ? measure[1] : null,
                        CO2 = measure.Count > 2 ? measure[2] : null,
                        Noise = measure.Count > 3 ? measure[3] : null,
                        Pressure = measure.Count > 4 ? measure[4] : null,
                    });
                    time += measureSet.StepTime;
                }
            }
            return list.OrderByDescending(m => m.MeasureTime).First();
        }
    }
}
