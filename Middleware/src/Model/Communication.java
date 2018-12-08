package Model;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.net.SocketException;
import java.nio.charset.Charset;
import java.util.Arrays;

import com.google.gson.Gson;

import Controller.Controller;
//This class is responsible for the communication between 
//a client and the middleware.
public class Communication implements Runnable
{
   private DataInputStream inFromClient;
   private DataOutputStream outToClient; 
   private Controller controller;
   private DbsClient dbsClient;
   private Socket socket;
   private final byte[] bArray = new byte[1024];
   private String clientText;
   private Gson gson;
   
   //Constructor receives a socket, to initiate a connection to the client
   //and the instances of the controller and dbsClient 
   //in order to invoke methods on them.
   public Communication(Socket socket, Controller controller, DbsClient dbsClient) throws IOException{
      inFromClient = new DataInputStream(socket.getInputStream());
      outToClient = new DataOutputStream(socket.getOutputStream());
      
      this.controller = controller;
      this.dbsClient = dbsClient;
      this.socket = socket;
      controller.execute(0, new String[] {"Connected to: " + socket.getRemoteSocketAddress().toString()});
   }
   //Runs a loop that listens for client requests
   //and potentially responds to them.
   public void run()
   {
      boolean runny = true;
      while(runny) {
         try{
            int bInt = 0;
            //Tries to talk to client and if exception is caught
            //the thread is terminated and client connection
            //is closed.
            try {
               bInt = inFromClient.read(bArray);
               clientText = new String(bArray, 0, bInt, Charset.forName("ASCII"));
            }
            catch(SocketException scktE) {
               controller.execute(1, new String[] { socket.getRemoteSocketAddress().toString(), " disconnected from the server."});
               socket.close();
               runny = false;
               break;
            }
            

            //Asks database to compare the account information
            //sent from the client and returns back to client
            //if access is granted.
            if(clientText.equals("login")) {
               controller.execute(0, new String[] {socket.getRemoteSocketAddress().toString() + " requested login"});
               //Send a response saying that you received the login message
               //and the client can proceed with its request.
               String response = "ok" + "\r\n";
               byte[] responseBytes = response.getBytes("ASCII");
               outToClient.write(responseBytes);
               
               //Read the next message
               bInt = inFromClient.read(bArray);
               String request = new String(bArray, 0, bInt, Charset.forName("ASCII"));
               //Talks to database and saves the answer to string
               String answer = dbsClient.login(request);
               //Adds \r\n in the end in order to tell client
               //where to stop reading
               response = answer + "\r\n";
               responseBytes = response.getBytes("ASCII");
               outToClient.write(responseBytes);
               //Sends "Respond sent succsessfully" to middleware view
               controller.execute(0, new String[] {"Resposne sent successfully!"});
               socket.close();
               runny = false;
               break;
            }
            else if(clientText.equals("register")){
               controller.execute(0, new String[] {socket.getRemoteSocketAddress().toString() + " requested registration"});
               //Send a response saying that you received the login message
               //and the client can proceed with its request.
               String response = "ok" + "\r\n";
               byte[] responseBytes = response.getBytes("ASCII");
               outToClient.write(responseBytes);
               
               bInt = inFromClient.read(bArray);
               String request = new String(bArray, 0, bInt, Charset.forName("ASCII"));
               
               //Disects string into User attributes
               String[] userArray = request.split(",");
               //Makes User object and sets attributes
               User user = new User();
               user.setPassword(userArray[0]);
               user.setEmail(userArray[1]);
               user.setPhoneNumber(userArray[2]);
               user.setName(userArray[3]);
               user.setUserId(null);
               //Serializes User object
              //gson = new Gson();
              // String registerRequest = gson.toJson(user);
               
               //Talks to database and saves the answer to string
               String answer = dbsClient.register(user);
               //Adds \r\n in the end in order to tell client
               //where to stop reading
               response = answer + "\r\n";
               responseBytes = response.getBytes("ASCII");
               outToClient.write(responseBytes);
               //Sends "Respond sent succsessfully" to middleware view
               controller.execute(0, new String[] {"Resposne sent successfully!"});
               socket.close();
               runny = false;
               break;
            }
            else if(clientText.equals("createRide")){
               controller.execute(0, new String[] {socket.getRemoteSocketAddress().toString() + " requested to create a ride"});
               //Send a response saying that you received the login message
               //and the client can proceed with its request.
               String response = "ok" + "\r\n";
               byte[] responseBytes = response.getBytes("ASCII");
               outToClient.write(responseBytes);
               
               bInt = inFromClient.read(bArray);
               String request = new String(bArray, 0, bInt, Charset.forName("ASCII"));
               
               //Disects string into User attributes
               String[] rideArray = request.split(",");
               //Makes User object and sets attributes
               Ride ride = new Ride(rideArray[0], rideArray[1]);
               ride.setDeparturePoint(rideArray[2]);
               ride.setDestinationCity(rideArray[3]);
               ride.setDestinationAddr(rideArray[4]);
               ride.setDate(rideArray[5]);
               ride.setTime(rideArray[6]);
               ride.setComment(rideArray[7]);
               //Talks to database and saves the answer to string
               String answer = dbsClient.createRide(ride);
               //Adds \r\n in the end in order to tell client
               //where to stop reading
               response = answer + "\r\n";
               responseBytes = response.getBytes("ASCII");
               outToClient.write(responseBytes);
               //Sends "Respond sent succsessfully" to middleware view
               controller.execute(0, new String[] {"Resposne sent successfully!"});
               socket.close();
               runny = false;
               break;
            }
            else if(clientText.equals("getCreatedRides")){
               controller.execute(0, new String[] {socket.getRemoteSocketAddress().toString() + " requested created rides list."});
               //Send a response saying that you received the login message
               //and the client can proceed with its request.
               String response = "ok" + "\r\n";
               byte[] responseBytes = response.getBytes("ASCII");
               outToClient.write(responseBytes);
               
               bInt = inFromClient.read(bArray);
               String request = new String(bArray, 0, bInt, Charset.forName("ASCII"));
               
               //Disects string into User attributes
               //Makes User object and sets attributes
               
               //Talks to database and saves the answer to string
               String answer = dbsClient.getCreatedRides(request);
               //Adds \r\n in the end in order to tell client
               //where to stop reading
               response = answer + "\r\n";
               responseBytes = response.getBytes("ASCII");
               outToClient.write(responseBytes);
               //Sends "Respond sent succsessfully" to middleware view
               controller.execute(0, new String[] {"Resposne sent successfully!"});
               socket.close();
               runny = false;
               break;
            }
            /*if(clientText.equals("get")) {
               bInt = inFromClient.read(bArray);
               request = new String(bArray, 0, bInt, Charset.forName("ASCII"));
               gson = new Gson();
               clientText = gson.fromJson(request, String.class);
               
               
               gson = new Gson();
               Person person = dbsClient.getPerson(clientText);
               String response = gson.toJson(person)+"\r\n";
               controller.execute(1, new String[] {socket.getRemoteSocketAddress().toString() + " requested ", response});
               byte[] responseBytes = response.getBytes("ASCII");
               outToClient.write(responseBytes);
               controller.execute(0, new String[] {"Resposne sent successfully!"});
            }*/
         }
         catch (Exception e){
            e.printStackTrace();
         } 
      }   
   }

}
