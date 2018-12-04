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
            }
            catch(SocketException scktE) {
               controller.execute(1, new String[] { socket.getRemoteSocketAddress().toString(), " disconnected from the server."});
               socket.close();
               runny = false;
               break;
            }
            String request = new String(bArray, 0, bInt, Charset.forName("ASCII"));
            Gson gson = new Gson();
            String clientText = gson.fromJson(request, String.class);
            
            //Asks database to compare the account information
            //sent from the client and returns back to client
            //if access is granted.
            if(clientText.equals("login")) {
               controller.execute(0, new String[] {socket.getRemoteSocketAddress().toString() + " requested login"});
               bInt = inFromClient.read(bArray);
               request = new String(bArray, 0, bInt, Charset.forName("ASCII"));

               
               String[] account = request.split(",");
               gson = new Gson();
               //Talks to database and saves the answer to string
               String answer = dbsClient.login(account[0], account[1]);
               //Adds \r\n in the end in order to tell client
               //where to stop reading
               String response = answer + "\r\n";
               byte[] responseBytes = response.getBytes("ASCII");
               outToClient.write(responseBytes);
               //Sends "Respond sent succsessfully" to middleware view
               controller.execute(0, new String[] {"Resposne sent successfully!"});
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
            System.out.println("woops");
         } 
      }   
   }

}
