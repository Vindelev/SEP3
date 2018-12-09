package model;

import java.util.ArrayList;

public class RideList {
	public ArrayList<Ride> Rides = new ArrayList<Ride>();

	public void addRide(Ride ride) {
		Rides.add(ride);
	}

	public void removeRide(Ride ride) {
		for (int i = 0; i < Rides.size(); i++) {
			if (Rides.get(i).getDate().equals(ride.getDate()) && Rides.get(i).getTime().equals(ride.getTime())
					&& Rides.get(i).getDriver().equals(ride.getDriver())) {
				Rides.remove(i);
			}
		}
	}

	public void removeRide2(Ride rideObj) {
		for (Ride ride : Rides) {
			if (ride.getDate().equals(rideObj.getDate()) && ride.getTime().equals(rideObj.getTime())
					&& rideObj.getDriver().equals(rideObj.getDriver())) {
				Rides.remove(ride);
			} 
		}
	}
	public Ride getRide(int index) {
		return this.Rides.get(index);
	}
	
}