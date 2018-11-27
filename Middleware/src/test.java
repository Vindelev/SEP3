import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

public class test
{

   public static void main(String[] args)
   {
      Client client = ClientBuilder.newClient();
      GsonBuilder gBuilder = new GsonBuilder();
      
      Gson gMan = gBuilder.create();
      
      Response response = client.target("http://localhost:5000/api/people/6969696969").request("application/json").get();
      
      String answer = response.readEntity(String.class);
      
      response.close();
      
      Person person = gMan.fromJson(answer, Person.class);
      
      
      
      //System.out.println(response.readEntity(String.class));
      System.out.println(person.toString());
      
      

      

   }

}
