using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

[Table("Rides")]
public class Ride{
    public Ride(){
        passangers = new List<string>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string RideId {get; set;}
    public string Driver { get; set;}

    public int Seats { get; set;}
    
    public string DeparturePoint { get; set;}
    public string DestinationCity { get; set;}
    public string DestinationAddr { get; set;}

    public string Date { get; set;}

    public string Time { get; set;}

    public string Comment { get; set;}

    [NotMapped]
    public List<string> passangers { get; set;}


}