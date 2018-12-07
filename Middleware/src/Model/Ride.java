package Model;

public class Ride {

   public User driver;
   

   public int Seats;
   public String DeparturePoint;
   public String DestCity;
   public String DestAddr;
   public String DepartureYear;
   public String DepartureMonth;
   public String DepartureDay;
   public String DepartureHour;
   public String DepartureMinute;
   public User[] passangers;

   public Ride(User driver, int Seats) {
      this.driver = driver;
      this.Seats = Seats;
      passangers = new User[Seats];
   }
   
   public int getSeats()
   {
      return Seats;
   }

   public void setSeats(int seats)
   {
      Seats = seats;
   }

   public String getDeparturePoint()
   {
      return DeparturePoint;
   }

   public void setDeparturePoint(String departurePoint)
   {
      DeparturePoint = departurePoint;
   }

   public String getDestCity()
   {
      return DestCity;
   }

   public void setDestCity(String destCity)
   {
      DestCity = destCity;
   }

   public String getDestAddr()
   {
      return DestAddr;
   }

   public void setDestAddr(String destAddr)
   {
      DestAddr = destAddr;
   }

   public int getFreeSeats() {
      return Seats - passangers.length;
   }
   
   public void addPassanger(User user) {
      passangers[passangers.length] = user;
   }
   
   public void removePassanger(User user) {
      for(int i =0; i < passangers.length; i++) {
        if(passangers[i].getEmail().equals(user.getEmail())) {
           for(int n = i; n < passangers.length; n++) {
              if(n+1 <= passangers.length) {
                 passangers[n] = passangers[n+1];
              }
              else {
                 break;
              }
           }
        }
      }
   }
}
  