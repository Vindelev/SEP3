using Newtonsoft.Json;

public class Ride{
    [JsonProperty("Driver")]
    public string Driver { get; set;}

    [JsonProperty("Seats")]
    public int Seats { get; set;}
    [JsonProperty("DeparturePoint")]

    public string DeparturePoint { get; set;}

    [JsonProperty("DestinationCity")]
    public string DestinationCity { get; set;}
    [JsonProperty("DestinationAddr")]

    public string DestinationAddr { get; set;}
    [JsonProperty("Date")]

    public string Date { get; set;}
    [JsonProperty("Time")]

    public string Time { get; set;}

    public string Comment { get; set;}

    
    public string[] passangers { get; set;}
}