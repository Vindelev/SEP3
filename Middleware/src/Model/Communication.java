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
   }
   //Runs a loop that listens for client requests
   //and potentially responds to them.
   public void run()
   {
      boolean runny = true;
      while(runny) {
         try{
            int bInt = 0;
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
            
            if(clientText.equals("get")) {
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
            }
         }
         catch (Exception e){
            e.printStackTrace();
         } 
      }   
   }

}
