package test;

import static org.junit.Assert.*;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import model.Ride;
import model.RideList;

public class RideTest {

	private Ride ride;

	@Before
	public void createObjcets() {
		ride = new Ride("John", "4");
	}

	@After
	public void teardownObjects() {
		ride = null;

	}

	@Test
	public void addPassengersToList() {
		this.ride.addPassenger("John");
		assertTrue(!(this.ride.getPassenger(0) == null));

	}

	// tests the method is full
	@Test
	public void isfullTest() {
		for (int i = 0; i < ride.seats; i++) {
			this.ride.addPassenger("John");
		}
		assertTrue(this.ride.isFull());
	}

	// tests if is empty method is working
	@Test
	public void isEmptyTest() {
		assertTrue(this.ride.isEmpty());
	}

	// tests for out of bounce
	@Test
	public void outOfBounceTest() {
		for (int i = 0; i < ride.seats + 1; i++) {
			this.ride.addPassenger("Ian");
		}
		assertTrue(this.ride.isFull());
	}

	// tests if passengers can be removed and the list is
	@Test
	public void removePassanger() {
		ride.addPassenger("John");
		ride.addPassenger("James");
		ride.removePassenger("John");
		assertTrue(ride.getPassenger(0).equals("James"));

	}

	// returns the number of free seats.
	@Test
	public void returnFreeSeatsTest() {
		ride.addPassenger("John");
		ride.addPassenger("James");
		assertTrue(ride.getFreeSeats() == 2);
	}
	

}
