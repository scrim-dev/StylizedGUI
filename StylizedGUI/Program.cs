using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Photino.NET;

namespace StylizedGUI
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            string windowTitle = "GUI";
            var window = new PhotinoWindow()
                .SetTitle(windowTitle)
                .SetUseOsDefaultSize(false)
                .SetSize(new Size(950, 650))
                .Center()
                .SetResizable(true)
                .RegisterCustomSchemeHandler("app", (object sender, string scheme, string url, out string contentType) =>
                {
                    contentType = "text/javascript";
                    return new MemoryStream(Encoding.UTF8.GetBytes(@"
                        (() =>{
                            window.setTimeout(() => {
                                alert(`Loaded!`);
                            }, 1000);
                        })();
                    "));
                })
                .RegisterWebMessageReceivedHandler((sender, message) =>
                {
                    var window = sender as PhotinoWindow;
                    string response = $"Received message: \"{message}\"";
                    window.SendWebMessage(response);

                    WebMessageEvents.EventReceived(sender, message); //All events go here
                })
                .Load("wwwroot/index.html");
            window.WaitForClose();
        }
    }
}
