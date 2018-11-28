package Controller;

import java.io.IOException;
import java.io.Serializable;
import Model.DbsClient;
import Model.SocketServer;
import View.View;

public class MiddlewareController implements Controller, Serializable
{
   
   
   private View view;
   private DbsClient dbsClient;
   private SocketServer scktServer;
   
   public MiddlewareController(View view) throws IOException {
      this.view = view;
      dbsClient = new DbsClient(this);
      scktServer = new SocketServer(this, dbsClient);
      this.view.print("Controller initiated successfully!");
      scktServer.run();
   }
 
   public void execute(int i, String[] list) {
      switch(i) {
         //Prints a simple message to the view(console)
         case 0: view.print(list[0]);
                  break;
         //Prints application client requests to the view(console)
         case 1:  view.print(list[0] +" requested " + list[1]);
                  break;
      }
   }
}
