using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
namespace BL
{
    class communicationLayer
    {
        string UserName;
        Socket sender;
        public communicationLayer()
        {
            
            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 8080 on the local computer.  
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8080);

                // Create a TCP/IP  socket.  
                sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(remoteEP);
                Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
                ThreadStart childref = new ThreadStart(StartClient);
                Thread childThread = new Thread(childref);
                childThread.Start();
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }

            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }

        public void StartClient()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[4096];
            string recived = "";
            try
            {
                while (true)
                {
                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    recived = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    Console.WriteLine("Recived: "+recived);
                    // Release the socket.  
                    if (recived.Contains("LOGOUT") && recived.Contains("DONE"))
                        UserName = null;
                    if (recived.Contains("REG"))
                        businessLayer.getBL().registered(recived);
                    if (recived.Contains("LOGIN"))
                        businessLayer.getBL().loggedin(recived);
                    if (recived.Contains("EDITPASS"))
                        businessLayer.getBL().edittedUserPassword(recived);
                    if (recived.Contains("EDITUSERNAME"))
                        businessLayer.getBL().edittedUserName(recived);
                    if (recived.Contains("EDITUSEREMAIL"))
                        businessLayer.getBL().edittedUserEmail(recived);
                    if (recived.Contains("SEARCHGAMESBYPOTSIZE"))
                        businessLayer.getBL().searchedGamesByPotSize(recived);
                    if (recived.Contains("LISTSPECTATEABLEGAMES"))
                        businessLayer.getBL().searchedGamesByPotSize(recived);
                    if (recived.Contains("LISTJOINABLEGAMES"))
                        businessLayer.getBL().searchedGamesByPotSize(recived);

                    


                }
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }

            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

        }

        public bool send(string msg) {
            byte[] bytes = new byte[4096];
            try
            { // Encode the data string into a byte array.  
                bytes = Encoding.ASCII.GetBytes(msg);
                Console.WriteLine("Sending: " + msg);
                // Send the data through the socket.  
                int bytesSent = sender.Send(bytes);
                Console.WriteLine("number of bytes send: " + bytesSent);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
                return false;
            }

        }

        public static int START()
        {
            communicationLayer CL = new communicationLayer();


            return 0;
        }


    }
}

