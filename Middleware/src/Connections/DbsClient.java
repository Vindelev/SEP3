package Connections;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.core.Response;
import Controller.Controller;
import Model.Ride;
import Model.User;
//This class is responsible for requesting and receiving data from the backend.
public class DbsClient
{     
      private Client client;
      private Controller controller;
      
      //Constructor receives a controller instance
      //in order to invoke methods on it.
      public DbsClient(Controller controller){
         client = ClientBuilder.newClient();
         
         this.controller = controller;
         this.controller.execute(0, new String[] {"DBS client initiated successfully!"});
      }
      
      public String login(String user) {
         Response response = client.target("http://localhost:5000/api/users/" + user).request("text/plain").get();
         String answer = response.readEntity(String.class);
         response.close();
         return answer;
      }
      
      public String register(User user){
         System.out.println(user);
         Response response = client.target("http://localhost:5000/api/users/").request("text/plain").post(Entity.json(user));
         String answer = response.readEntity(String.class);
         response.close();
         return answer;
      }
      public String createRide(Ride ride) {
         Response response = client.target("http://localhost:5000/api/rides/").request("text/plain")
               .post(Entity.json(ride));
         String answer = response.readEntity(String.class);
         response.close();
         return answer;
      }
      
      public String getCreatedRides(String email){
         Response response = client.target("http://localhost:5000/api/rides/" + email).request("text/plain").get();
         String answer = response.readEntity(String.class);
         response.close();
         return answer;
      }
      public String getRides() {
         Response response = client.target("http://localhost:5000/api/rides/").request("text/plain").get();
         String answer = response.readEntity(String.class);
         response.close();
         return answer;
      }
      public String deleteRide(Ride ride) {
         Response response = client.target("http://localhost:5000/api/ride/").request("text/plain").put(Entity.json(ride));
         String answer = response.readEntity(String.class);
         response.close();
         return answer;
      }
      public String joinRide(Ride ride) {
         Response response = client.target("http://localhost:5000/api/rides/").request("text/plain").put(Entity.json(ride));
         String answer = response.readEntity(String.class);
         response.close();
         return answer;
      }
      public String leaveRide(Ride ride) {
         Response response = client.target("http://localhost:5000/api/ride/").request("text/plain").post(Entity.json(ride));
         String answer = response.readEntity(String.class);
         response.close();
         return answer;
      }
}
