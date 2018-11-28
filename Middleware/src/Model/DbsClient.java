package Model;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.core.Response;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import Controller.Controller;
import Controller.MiddlewareController;

public class DbsClient
{     
      private Client client;
      private GsonBuilder gBuilder;
      private Gson gMan;
      private Controller controller;
      
      public DbsClient(Controller controller){
         client = ClientBuilder.newClient();
         gBuilder = new GsonBuilder();
         gMan = gBuilder.create();
         this.controller = controller;
         this.controller.execute(0, new String[] {"DBS client initiated successfully!"});
      }
      
      public Person getPerson(String cpr) {
         Response response = client.target("http://localhost:5000/api/people/" + cpr).request("application/json").get();
         String answer = response.readEntity(String.class);
         response.close();
         gMan = new Gson();
         Person person = gMan.fromJson(answer, Person.class);
         return person; 
      }
}
