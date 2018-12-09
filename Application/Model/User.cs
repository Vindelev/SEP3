using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
public class User{

    [JsonProperty("Name")]
    public string Name { get; set;}
    [JsonProperty("Password")]
    public string Password { get; set;}
    [JsonProperty("PhoneNumber")]

    public string PhoneNumber { get; set;}
    [JsonProperty("Email")]

    public string Email { get; set;}
}