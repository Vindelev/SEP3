import javax.ws.rs.RedirectionException;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;

public class test
{

   public static void main(String[] args) throws InterruptedException
   {
      Client client = ClientBuilder.newClient();
      WebTarget target = client.target("http://localhost:5000/api/people/6969696969");
      try {
         System.out.println(target.request(MediaType.TEXT_PLAIN).get());
      }
      catch(RedirectionException e) {
         while(true) {
            System.out.println("Waiting for an answer");
            Thread.sleep(1000);
         }
      }
      
   }

}
