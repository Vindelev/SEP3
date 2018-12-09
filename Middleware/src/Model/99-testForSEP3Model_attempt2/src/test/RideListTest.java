package test;

import static org.junit.Assert.*;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import model.Ride;
import model.RideList;

public class RideListTest {
	private RideList rideList;
	private Ride ride1;
	private Ride ride2;
	
	@Before
	public void createObjects() {
		rideList = new RideList();
		ride1 = new Ride("John", "4");
		ride1.setDate("1");
		ride1.setTime("20");
		ride2 = new Ride("James", "9");
		
	}
	
	@After
	public void teardownObjects() {
		rideList = null;
		ride1 = null;
		ride2 = null;
	}

	@Test
	public void addRideToListTest() {
		rideList.addRide(ride1);
		assertTrue(rideList.Rides.get(0).equals(ride1));
	}
	
	@Test
	public void removeRideFromListTest() {
		rideList.addRide(ride1);
		rideList.addRide(ride2);
		rideList.removeRide(ride1);
		assertTrue(rideList.Rides.get(0).equals(ride2));
	}

}
