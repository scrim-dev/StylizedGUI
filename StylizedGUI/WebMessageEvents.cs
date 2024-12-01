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
            if (string.Compare(message, "Button_Event", true) == 0)
            {
                Console.WriteLine($"{sender}: {message}");
                MessageBox.Show("Button Pressed!", "HTML");
            }
        }
    }
}