import javax.ws.rs.RedirectionException;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.glassfish.jersey.client.ClientProperties;

import java.lang.Thread;

public class test
{

   public static void main(String[] args) throws InterruptedException
   {
      Client client = ClientBuilder.newClient();
     
      WebTarget target = client.target("http://localhost:5000/api/people");
      target.property(ClientProperties.FOLLOW_REDIRECTS, Boolean.TRUE);
      
      Response response = target.request().get();
      response.bufferEntity();
      System.out.println(response.readEntity(String.class));
    
      
   }

}
