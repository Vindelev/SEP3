import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import com.google.gson.Gson;

public class test
{

   public static void main(String[] args)
   {
      Client client = ClientBuilder.newClient();
      WebTarget target = client.target("http://localhost:5000/api/people/6969696969");
      
      Gson gson = new Gson();
      Response response = target.request("application/json").get();
      
      Person person = gson.fromJson(response.readEntity(String.class), Person.class);
      
      response.close();
      
      System.out.println(person.toString());

      

   }

}
