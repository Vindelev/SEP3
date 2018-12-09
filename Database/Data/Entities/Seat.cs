using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Seats")]
public class Seat{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string RideId { get; set;}
    public string Email { get; set;}

}