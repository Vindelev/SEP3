using System;
using System.Collections.Generic;

public class RideList{


    public List<Ride> Rides { get; set;}

    public void Add(Ride ride){
        Rides.Add(ride);
    }
    public void Remove(Ride ride){
        Rides.Remove(ride);
    }
}