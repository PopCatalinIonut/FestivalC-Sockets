using System;
using System.Windows.Forms;
using client;
using festival.network;
using festival.services;

namespace festival.client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            IFestivalServices server = new FestivalServerProxy("127.0.0.1", 55555);
            FestivalClientCtrl ctrl=new FestivalClientCtrl(server);
            LoginWindow win=new LoginWindow(ctrl);
            Application.Run(win);
     
        }
    }
}