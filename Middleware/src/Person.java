
public class Person
{
      private String cpr;
      private String name;
      private String mobileNumber;
      
      public Person(String cpr) {
         this.cpr = cpr;
      }
      
      public String toString() {
         return name + "/" + cpr + "/" + mobileNumber;
      }
}
