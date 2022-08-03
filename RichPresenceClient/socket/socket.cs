// /*
//  * Copyright (c) Tommy31
//  * All rights reserved.
//  * Only people with the explicit permission from Tommy31 are allowed to modify, share or distribute this code.
//  *
//  * You are NOT allowed to do any kind of modification to this software.
//  * You are NOT allowed to share this software with others without the explicit permission from Tommy31.
//  * You MUST acquire this software from official sources.
//  * You MUST run this software on your device as compiled file from our releases.
//  */

using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace RichPresenceClient.socket;

public class socket {

    private static Socket ConnectSocket(string server, int port)
    {
        Socket s = null;
        IPHostEntry hostEntry = null;

        hostEntry = Dns.GetHostEntry(server);
        
        foreach(IPAddress address in hostEntry.AddressList)
        {
            IPEndPoint ipe = new IPEndPoint(address, port);
            Socket tempSocket =
                new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            tempSocket.Connect(ipe);

            if(tempSocket.Connected)
            {
                s = tempSocket;
                break;
            }
            else
            {
                continue;
            }
        }
        return s;
    }

    public static string SocketSendReceive(string server, int port)
    {
        string request = "GET / HTTP/1.1\r\nHost: " + server +
                         "\r\nConnection: Close\r\n\r\n";

        Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
        Byte[] bytesReceived = new byte[256];
        string page = "";

        using (Socket s = ConnectSocket(server, port))
        {
            if (s == null)
            {
                return ("Connection failed");
            }

            s.Send(bytesSent, bytesSent.Length, 0);

            int bytes = 0;

            page = "Default HTML page on " + server + ":\r\n";

            do
            {
                bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            } while (bytes > 0);

            return page;
        }
    }
}

