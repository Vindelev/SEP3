using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

[Table("People")]
public class Person{
    [Key]
    [StringLength(10)]
    public string CPR { get; set;}
    public string name { get; set;}
    [StringLength(8)]
    public string MobileNumber { get; set;}
}