using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Pages;
using Newtonsoft.Json;

public class ClientSocket{
     // The port number for the remote device.  
    private const int port = 6969;  
  
    // ManualResetEvent instances signal completion.  
    private static ManualResetEvent connectDone;
    private static ManualResetEvent sendDone;
    private static ManualResetEvent receiveDone; 
  
    // The response from the remote device.  
    private static String response;
    private Socket client;

    public ClientSocket(){
        connectDone = new ManualResetEvent(false);
        sendDone = new ManualResetEvent(false);
        receiveDone = new ManualResetEvent(false);  
        response = String.Empty;
        // Establish the remote endpoint for the socket.    
        IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");  
        IPAddress ipAddress = ipHostInfo.AddressList[0];  
        IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);  
  
        // Create a TCP/IP socket.  
        client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);  
  
        // Connect to the remote endpoint.  
        client.BeginConnect( remoteEP, new AsyncCallback(ConnectCallback), client);  
        connectDone.WaitOne();  
    }  
    private static void ConnectCallback(IAsyncResult ar) {  
        try {  
            // Retrieve the socket from the state object.  
            Socket client = (Socket) ar.AsyncState;  
  
            // Complete the connection.  
            client.EndConnect(ar);  
  
            Console.WriteLine("Socket connected to {0}",  
                client.RemoteEndPoint.ToString());  
  
            // Signal that the connection has been made.  
            connectDone.Set();  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }  
  
    private static void Receive(Socket client) {  
        try {  
            // Create the state object.  
            StateObject state = new StateObject();  
            state.workSocket = client;  
  
            // Begin receiving the data from the remote device.  
            client.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }  
  
    private static void ReceiveCallback( IAsyncResult ar ) {  
        try {  
            // Retrieve the state object and the client socket   
            // from the asynchronous state object.  
            StateObject state = (StateObject) ar.AsyncState;  
            Socket client = state.workSocket;  
            // Read data from the remote device.  
            int bytesRead = client.EndReceive(ar);  
            if (bytesRead > 0) {  
                // There might be more data, so store the data received so far. 
                state.sb.Append(Encoding.ASCII.GetString(state.buffer,0,bytesRead)); 

                if (state.sb.ToString().EndsWith("\r\n"))
                {
                    response = state.sb.ToString();
                    receiveDone.Set();
                } 
                // Get the rest of the data. 
                else{
                    client.BeginReceive(state.buffer,0,StateObject.BufferSize,0, new AsyncCallback(ReceiveCallback), state);
                } 
                 
            } else {  
                // All the data has arrived; put it in response. 
                // Signal that all bytes have been received.  
                System.Console.WriteLine(response);
            }  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }  
  
    private static void Send(Socket client, String data) {  
        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.ASCII.GetBytes(data);  
  
        // Begin sending the data to the remote device.  
        client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);  
    }  
  
    private static void SendCallback(IAsyncResult ar) {  
        try {  
            // Retrieve the socket from the state object.  
            Socket client = (Socket) ar.AsyncState;  
  
            // Complete sending the data to the remote device.  
            int bytesSent = client.EndSend(ar);  
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);  
  
            // Signal that all bytes have been sent.  
            sendDone.Set();  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }  

    //Terminates given client
    public static void TerminateSocketClient(Socket client){
        client.Shutdown(SocketShutdown.Both);  
        client.Close();
    }
    public List<Person> GetPerson(){
        Send(this.client, "get");
        sendDone.WaitOne();
        Send(this.client, "6969696969");
        sendDone.WaitOne();

        Receive(this.client);
        receiveDone.WaitOne();

        
        Person p2 = JsonConvert.DeserializeObject<Person>(response);
        List<Person> lelist = new List<Person>();
        lelist.Add(p2);
        return lelist; 
    }
}