/*
 * Copyright (c) Jan Sohn & Tommy31
 * All rights reserved.
 * Only people with the explicit permission from Jan Sohn or Tommy31 are allowed to modify, share or distribute this code.
 *
 * You are NOT allowed to do any kind of modification to this software.
 * You are NOT allowed to share this software with others without the explicit permission from Jan Sohn or Tommy31.
 * You MUST acquire this software from official sources.
 * You MUST run this software on your device as compiled file from our releases.
 */

using System.Net;
using RichPresenceClient.socket;

namespace RichPresenceClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string host = config.ipForServer;
            int port = config.portForServer;

            string result = RichPresenceClient.socket.socket.SocketSendReceive(host, port);
            Console.WriteLine(result);

        }
    }
}