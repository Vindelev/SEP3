using System;
using System.Runtime.Serialization;

[DataContract]
public class Person{
    [DataMember]
    public string Name { get; set;}
    [DataMember]
    public string CPR { get; set;}
    [DataMember]
    public string MobileNumber { get; set;}

    public override string ToString(){
        return Name + ", " + CPR + ", " + MobileNumber; 
    }
}