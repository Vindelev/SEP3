package Controller;

import java.io.IOException;
import java.io.Serializable;

import Connections.DbsClient;
import Connections.SocketServer;
import View.View;

//Responsible for setting up a connection
//to the front and back end. Prints out
//messages from the model to the view.
public class MiddlewareController implements Controller, Serializable
{
   
   
   private View view;
   private DbsClient dbsClient;
   private SocketServer scktServer;
   
   //Receives a view in order to invoke 
   //methods on it.
   public MiddlewareController(View view) throws IOException {
      this.view = view;
      dbsClient = new DbsClient(this);
      scktServer = new SocketServer(this, dbsClient);
      this.view.print("Controller initiated successfully!");
      scktServer.run();
   }
   
   //Purposely created to invoke different
   //actions depending on the case called.
   //Asks for a String array in order to be able
   //to receive multiple strings without multiple execute() calls.
   public void execute(int i, String[] list) {
      switch(i) {
         //Prints a simple message to the view(console)
         case 0: view.print(list[0]);
                  break;
         //Prints two messages to the view(console)
         case 1:  view.print(list[0] + list[1]);
                  break;
      }
   }
}
