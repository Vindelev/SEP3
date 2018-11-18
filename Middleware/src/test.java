import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Invocation;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.Response;

public class test
{

   public static void main(String[] args)
   {
      Client client = ClientBuilder.newClient();
      WebTarget target = client.target("http://localhost:5000/api/people/6969696969");
      Invocation.Builder invo = target.request("application/json");
      Response response = invo.get();
      response.bufferEntity();
      
      try {
         while(response.getStatus() != 200) {
            System.out.println(response.readEntity(String.class));
         }
      }finally {
         response.close();
      }

   }

}
