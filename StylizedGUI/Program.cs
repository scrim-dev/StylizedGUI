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
                .RegisterCustomSchemeHandler("app", CustomScheme)
                .RegisterWebMessageReceivedHandler(WebMessageEvents.EventReceived) //Handle all events
                .Load("wwwroot/index.html");
            window.WaitForClose();
        }

        private static Stream CustomScheme(object sender, string scheme, string url, out string contentType)
        {
            contentType = "text/javascript";
            var js = @"
                        (() =>{
                            window.setTimeout(() => {
                                alert(`Loaded!`);
                            }, 1000);
                        })();
                    ";

            return new MemoryStream(Encoding.UTF8.GetBytes(js));
        }
    }
}
