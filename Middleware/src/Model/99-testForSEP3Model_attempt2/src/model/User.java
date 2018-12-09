package model;

public class User
{
   public String UserId;
   public String Name;
   public String Password;
   public String PhoneNumber;
   public String Email;
   
   
   public String getUserId()
   {
      return UserId;
   }
   public void setUserId(String userId)
   {
      UserId = userId;
   }
   public String getName()
   {
      return Name;
   }
   public void setName(String name)
   {
      Name = name;
   }
   public String getEmail()
   {
      return Email;
   }
   public void setEmail(String email)
   {
      Email = email;
   }
   public String getPhoneNumber()
   {
      return PhoneNumber;
   }
   public void setPhoneNumber(String phoneNumber)
   {
      PhoneNumber = phoneNumber;
   }
   public String getPassword()
   {
      return Password;
   }
   public void setPassword(String password)
   {
      Password = password;
   }
}
