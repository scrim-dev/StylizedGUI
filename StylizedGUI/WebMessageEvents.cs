using Photino.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StylizedGUI
{
    internal class WebMessageEvents
    {
        //Handling all your button presses and whatnot
        public static void EventReceived(object sender, string message)
        {
            var window = (PhotinoWindow)sender;

            // The message argument is coming in from sendMessage.
            // "window.external.sendMessage(message: string)"
            string response = $"Received message: \"{message}\"";

            // Send a message back the to JavaScript event handler.
            // "window.external.receiveMessage(callback: Function)"
            window.SendWebMessage(response);
            Console.WriteLine($"{sender}: {message}");

            //Ur event names and functions
            if (message == "ButtonEvent")
            {
                Console.WriteLine($"{sender}: {message}");
                MessageBox.Show("Button Pressed! (Received from JavaScript)", "HTML");
            }
        }
    }
}