using System;
using System.Net.Sockets;

using System.Threading;
using festival.client;
using festival.persistance;
using festival.services;
using ServerTemplate;
namespace festival
{
    using server;
    class StartServer
    {
        static void Main(string[] args)
        {
            
            ShowsDBRepository  showRepo= new ShowsDBRepository();
            TicketsDBRepository ticketsRepo = new TicketsDBRepository(); 
            ArtistsDBRepository artistsRepo = new ArtistsDBRepository();
            EmployeeRepository employeeRepo = new EmployeeRepository();
            IFestivalServices service = new FestivalService(artistsRepo, showRepo, ticketsRepo, employeeRepo);

          
            SerialChatServer server = new SerialChatServer("127.0.0.1", 55555, service);
            server.Start();
            Console.WriteLine("Server started ...");
            Console.ReadLine();
            
        }
    }

    public class SerialChatServer: ConcurrentServer 
    {
        private IFestivalServices server;
        private FestivalClientWorker worker;
        public SerialChatServer(string host, int port, IFestivalServices server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("FestivalServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new FestivalClientWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
    
}