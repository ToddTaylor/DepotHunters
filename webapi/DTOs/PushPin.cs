using Newtonsoft.Json;

namespace webapi.DTOs;

public class PushPin
{
    [JsonProperty("latitude")]
    public double Latitude { get; set; }

    [JsonProperty("longitude")]
    public double Longitude { get; set; }
}
