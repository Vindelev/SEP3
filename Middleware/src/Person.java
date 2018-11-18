import java.io.Serializable;

public class Person implements Serializable
{
      private String CPR;
      private String Name;
      private String MobileNumber;
  
      public Person() {
         
      }
      
      public Person(String CPR, String Name, String MobileNumber) {
         this.CPR = CPR;
         this.Name = Name;
         this.MobileNumber = MobileNumber;
      }
      
      public void setCPR(String CPR) {
         this.CPR = CPR;
      }
      
      public String getCPR() {
         return CPR;
      }
      
      public void setName(String Name) {
         this.Name = Name;
      }
      
      public String getName() {
         return Name;
      }
      
      public void setMobileNumber(String MobileNumber) {
         this.MobileNumber = MobileNumber;
      }
      
      public String getMobileNumber() {
         return MobileNumber;
      }
      
      public String toString() {
         return new StringBuffer("Name: ").append(this.Name)
               .append(" CPR: ").append(this.CPR).append(" Mobile Number: ").append(this.MobileNumber).toString();

      }
}
