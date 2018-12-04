using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Users")]
public class User{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string UserId { get; set;}
    public string Name { get; set;}
    public string Password { get; set;}

    public string PhoneNumber { get; set;}

    public string Email { get; set;}
}