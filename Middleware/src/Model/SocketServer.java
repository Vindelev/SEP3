package Model;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

import Controller.Controller;
//This class is responsible for listening 
//for and connecting to front end clients.
public class SocketServer implements Runnable
{
   private ServerSocket serverSocket;
   private Controller controller;
   private DbsClient dbsClient;
   
   public SocketServer(Controller controller, DbsClient dbsClient) throws IOException{
      serverSocket = new ServerSocket(6969);
      this.controller = controller;
      this.dbsClient = dbsClient;
      this.controller.execute(0, new String[] {"Socket server initiated successfully!"});
   }
   //Run a loop that listens for connections.
   //If a connection occurs, create a new thread and run the connection on it
   //Proceed listening for other clients.
   public void run() {
      while(true) {
         try
         {
            Socket server = serverSocket.accept();
            controller.execute(0, new String[] {"Connected to: " + server.getRemoteSocketAddress()});
            
            Communication clientConnected = new Communication(server, controller, dbsClient);
            clientConnected.run();
           
         }
         
         catch (IOException e)
         {
            // TODO Auto-generated catch block
            e.printStackTrace();
         }
      }
   }
}
