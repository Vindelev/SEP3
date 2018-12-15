package Model;

import java.util.ArrayList;

public class Ride {

   public String Driver;
   public int Seats;
   public String DeparturePoint;
   public String DestinationCity;
   public String DestinationAddr;
   public String Date;
   public String Time;
   public String Comment;
   public ArrayList<String> passangers;
   


   public Ride(String driver, String Seats) {
      this.Driver = driver;
      this.Seats = Integer.parseInt(Seats);
      passangers = new ArrayList<String>();
   }
   public String getDriver() {
      return Driver;
   }
   
   
   public String getComment()
   {
      return Comment;
   }

   public void setComment(String comment)
   {
      this.Comment = comment;
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
  