package Model;
import java.io.Serializable;

public class Person implements Serializable
{
      private String cpr;
      private String name;
      private String mobileNumber;
  
      public Person() {
         
      }
      
      public Person(String CPR, String Name, String MobileNumber) {
         this.cpr = CPR;
         this.name = Name;
         this.mobileNumber = MobileNumber;
      }
      
      public void setCPR(String CPR) {
         this.cpr = CPR;
      }
      
      public String getCPR() {
         return cpr;
      }
      
      public void setName(String Name) {
         this.name = Name;
      }
      
      public String getName() {
         return name;
      }
      
      public void setMobileNumber(String MobileNumber) {
         this.mobileNumber = MobileNumber;
      }
      
      public String getMobileNumber() {
         return mobileNumber;
      }
      
      public String toString() {
         return new StringBuffer("Name: ").append(this.name)
               .append(" CPR: ").append(this.cpr).append(" Mobile Number: ").append(this.mobileNumber).toString();

      }
}
