package model;

public class Ride {

	public String Driver;
	public int seats;
	public String DeparturePoint;
	public String DestinationCity;
	public String DestinationAddr;
	public String Date;
	public String Time;
	public String[] passengers;
	public String comment;
	public int counter = 0;

	public Ride(String driver, String seats) {
		this.Driver = driver;
		this.seats = Integer.parseInt(seats);
		passengers = new String[this.seats];
	}

	public String getDriver() {
		return Driver;
	}

	public int getFreeSeats() {
		return this.seats - this.counter;
	}

	public void addPassenger(String user) {
		if (!(this.isFull())) {
			passengers[counter] = user;
			counter++;
		}
	}

	public void removePassenger(String user) {
		for (int i = 0; i < passengers.length; i++) {
			if (passengers[i].equals(user)) {
				this.counter--;
				while(i < passengers.length - 1) {
					passengers[i] = passengers[i+1];
					i++;
				}
			}
		}
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

	public String getDeparturePoint() {
		return DeparturePoint;
	}

	public void setDeparturePoint(String departurePoint) {
		DeparturePoint = departurePoint;
	}

	public String getDestinationCity() {
		return DestinationCity;
	}

	public void setDestinationCity(String destCity) {
		DestinationCity = destCity;
	}

	public String getDestinationAddr() {
		return DestinationAddr;
	}

	public void setDestinationAddr(String destAddr) {
		DestinationAddr = destAddr;
	}

	public String getDate() {
		return Date;
	}

	public void setDate(String date) {
		Date = date;
	}

	public String getTime() {
		return Time;
	}

	public void setTime(String time) {
		Time = time;
	}

	public boolean isFull() {
		int counter = 0;
		for (int i = 0; i < passengers.length; i++) {
			if (!(passengers[i] == null)) {
				counter++;
			}
		}
		if (counter == passengers.length) {
			return true;
		} else {
			return false;
		}

	}

	public boolean isEmpty() {
		int counter = 0;
		for (int i = 0; i < passengers.length; i++) {
			if (!(passengers[i] == null)) {
				counter++;
			}
		}
		if (counter == 0) {
			return true;
		} else {
			return false;
		}

	}

	public String getPassenger(int i) {
		return passengers[i];
	}
}