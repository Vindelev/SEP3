package Model;

import java.util.ArrayList;

public class RideList
{
   public ArrayList<Ride> Rides = new ArrayList<Ride>();
   
   public void add(Ride ride) {
      Rides.add(ride);
   }
   public void remove(Ride ride) {
      for(int i = 0; i < Rides.size(); i++) {
         if(Rides.get(i).getDate().equals(ride.getDate()) && 
         Rides.get(i).getTime().equals(ride.getTime()) && Rides.get(i).getDriver().equals(ride.getDriver())) {
            Rides.remove(i);
         }
      }
   }
}
