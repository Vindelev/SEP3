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
    private ManualResetEvent connectDone;
    private ManualResetEvent sendDone;
    private ManualResetEvent receiveDone; 
  
    // The response from the remote device.  
    private String response;
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
        connectDone.Reset(); 
    }  
    private void ConnectCallback(IAsyncResult ar) {  
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
  
    private void Receive(Socket client) {  
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
  
    private void ReceiveCallback( IAsyncResult ar ) {  
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
                string content = state.sb.ToString();
                if (content.EndsWith("\r\n"))
                {
                    response = content.Substring(0, content.Length - 2);
                    receiveDone.Set();
                } 
                // Get the rest of the data. 
                else{
                    client.BeginReceive(state.buffer,0,StateObject.BufferSize,0, new AsyncCallback(ReceiveCallback), state);
                } 
                 
            } else {  
                // All the data has arrived; put it in response. 
                // Signal that all bytes have been received.  ;
            }  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }  
  
    private void Send(Socket client, String data) {  
        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.ASCII.GetBytes(data);  
  
        // Begin sending the data to the remote device.  
        client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);  
    }  
  
    private void SendCallback(IAsyncResult ar) {  
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
    public void TerminateSocketClient(Socket client){
        client.Shutdown(SocketShutdown.Both);  
        client.Close();
    }

    public String Login(String email, String password){
        Send(this.client, "login");
        sendDone.WaitOne();
        sendDone.Reset();
        
        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();
        
        Send(this.client, email + "," + password);
        sendDone.WaitOne();
        sendDone.Reset();

        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();

        //var user = JsonConvert.DeserializeObject<String>(response);
        return response; 
    }

    public String Register(String user){
        Send(this.client, "register");
        sendDone.WaitOne();
        sendDone.Reset();
        
        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();

        System.Console.WriteLine(response);
        
        Send(this.client, user);
        sendDone.WaitOne();
        sendDone.Reset();

        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();

        System.Console.WriteLine(response);
        return response;
    }
    public string CreateRide(string ride)
    {
        Send(this.client, "createRide");
        sendDone.WaitOne();
        sendDone.Reset();

        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();

        Send(this.client, ride);
        sendDone.WaitOne();
        sendDone.Reset();

        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();
        
        return response;

    }
    public string GetCreatedRides(string email){
        Send(this.client, "getCreatedRides");
        sendDone.WaitOne();
        sendDone.Reset();

        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();

        Send(this.client, email);
        sendDone.WaitOne();
        sendDone.Reset();

        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();
        
        return response;
    }

    public string GetRides(){
        Send(this.client, "getRides");
        sendDone.WaitOne();
        sendDone.Reset();

        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();

        return response;
    }
    public string DeleteRide(Ride ride){
        String request = JsonConvert.SerializeObject(ride);

        Send(this.client, "deleteRide");
        sendDone.WaitOne();
        sendDone.Reset();

        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();

        Send(this.client, request);
        sendDone.WaitOne();
        sendDone.Reset();
        
        return response;
    }
    public string JoinRide(Ride ride){
        String request = JsonConvert.SerializeObject(ride);

        Send(this.client, "joinRide");
        sendDone.WaitOne();
        sendDone.Reset();

        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();

        Send(this.client, request);
        sendDone.WaitOne();
        sendDone.Reset();
        
        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();
        
        return response;
    }

    public string LeaveRide(Ride ride){
        String request = JsonConvert.SerializeObject(ride);
        
        Send(this.client, "leaveRide");
        sendDone.WaitOne();
        sendDone.Reset();

        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();

        Send(this.client, request);
        sendDone.WaitOne();
        sendDone.Reset();
        
        Receive(this.client);
        receiveDone.WaitOne();
        receiveDone.Reset();

        return response;
    }
}