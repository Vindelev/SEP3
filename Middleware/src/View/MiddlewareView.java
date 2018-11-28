package View;

import java.io.IOException;
import java.util.InputMismatchException;
import java.util.Scanner;

import Controller.Controller;
import Controller.MiddlewareController;

public class MiddlewareView implements View
{
      private Controller mc;
      public MiddlewareView() throws IOException {
         initiationMessage();
      }

      public void initiationMessage() throws IOException {
         
         System.out.println("Type 1 to start the server or 0 to close the application.");
         Scanner s = new Scanner(System.in);
         
         //Sets a default value to satisfy the compiler.
         int input = 0;
         boolean success = false;
         
         //Makes sure that the input is of type int.
         while(success == false){
            try {
               input = s.nextInt();
               success = true;
            }
            catch(InputMismatchException e) {
               System.out.println("Invalid input.");
            }
         }
         
         // Checks the type of input and produces further results.
         if(input == 1) {
            mc = new MiddlewareController(this);
            s.close();
         }
         else if(input == 0) {
            System.out.println("Exiting system...");
            System.exit(0);
         }
         
         //If input is a different number from 1 or 0, proceed with the following code.
         else {
            System.out.println("I am sick of your shit.");
            System.out.println("Exiting system...");
            System.exit(0);
         }
      }
      //Prints a message to the view.
      public void print(String msg)
      {
            System.out.println(msg);
      }
}
