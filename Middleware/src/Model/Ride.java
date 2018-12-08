package Model;

public class Ride {

   public String Driver;
   public int Seats;
   public String DeparturePoint;
   public String DestinationCity;
   public String DestinationAddr;
   public String Date;
   public String Time;
   public String[] passangers;
   public String comment;


   public Ride(String driver, String Seats) {
      this.Driver = driver;
      this.Seats = Integer.parseInt(Seats);
      passangers = new String[this.Seats];
   }
   public String getDriver() {
      return Driver;
   }
   
   public int getFreeSeats() {
      return Seats - passangers.length;
   }
   
   public void addPassanger(String user) {
      passangers[passangers.length] = user;
   }
   
   public void removePassanger(String user) {
      for(int i =0; i < passangers.length; i++) {
        if(passangers[i].equals(user)) {
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
   
   public String getComment()
   {
      return comment;
   }

   public void setComment(String comment)
   {
      this.comment = comment;
   }
   
   public String getDeparturePoint()
   {
      return DeparturePoint;
   }

   public void setDeparturePoint(String departurePoint)
   {
      DeparturePoint = departurePoint;
   }
   public String getDestinationCity()
   {
      return DestinationCity;
   }

   public void setDestinationCity(String destCity)
   {
      DestinationCity = destCity;
   }

   public String getDestinationAddr()
   {
      return DestinationAddr;
   }

   public void setDestinationAddr(String destAddr)
   {
      DestinationAddr = destAddr;
   }

   public String getDate()
   {
      return Date;
   }

   public void setDate(String date)
   {
      Date = date;
   }

   public String getTime()
   {
      return Time;
   }

   public void setTime(String time)
   {
      Time = time;
   }
}
  