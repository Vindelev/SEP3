using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
public class User{
    [DataMember]
    public string UserId { get; set;}
    [JsonProperty("Name")]
    public string Name { get; set;}
    [JsonProperty("Password")]
    public string Password { get; set;}
    [JsonProperty("PhoneNumber")]

    public string PhoneNumber { get; set;}
    [JsonProperty("Email")]

    public string Email { get; set;}
}