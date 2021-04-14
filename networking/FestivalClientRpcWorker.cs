using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using festival.model;
using festival.network.protocol;
using festival.services;

namespace festival.client
{
	public class FestivalClientWorker :  IFestivalObserver //, Runnable
	{
		private IFestivalServices server;
		private TcpClient connection;

		private NetworkStream stream;
		private IFormatter formatter;
		private volatile bool connected;
		public FestivalClientWorker(IFestivalServices server, TcpClient connection)
		{
			this.server = server;
			this.connection = connection;
			try
			{
				
				stream=connection.GetStream();
                formatter = new BinaryFormatter();
				connected=true;
			}
			catch (Exception e)
			{
                Console.WriteLine(e.StackTrace);
			}
		}

		public virtual void run()
		{
			while(connected)
			{
				try
				{
                    object request = formatter.Deserialize(stream);
					object response =handleRequest((Request)request);
					if (response!=null)
					{
					   sendResponse((Response) response);
					}
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.StackTrace);
				}
				
				try
				{
					Thread.Sleep(1000);
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.StackTrace);
				}
			}
			try
			{
				stream.Close();
				connection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error "+e);
			}
		}
		private Response handleRequest(Request request)
		{
			Response response =null;
			if (request is LoginRequest)
			{
				Console.WriteLine("Login request ...");
				LoginRequest logReq =(LoginRequest)request;
				User user =logReq.User;
				try
                {
                    lock (server)
                    {
                        server.login(user, this);
                    }
					return new OkResponse();
				}
				catch (FestivalException e)
				{
					connected=false;
					return new ErrorResponse(e.Message);
				}
			}
			if (request is LogoutRequest)
			{
				Console.WriteLine("Logout request ...");
				LogoutRequest logReq =(LogoutRequest)request;
				User user =logReq.User;
				try
				{
					lock (server)
					{
						server.logout(user, this);
					}
					return new OkResponse();
				}
				catch (FestivalException e)
				{
					return new ErrorResponse(e.Message);
				}
			}

			if (request is GetAllShowsRequest)
			{
				Console.WriteLine("Get all shows request...");
				try
				{
					Show[] shows;
					lock (server)
					{
						shows = server.findAllShows();
					}

					return new GetAllShowsResponse(shows);
				}
				catch (FestivalException e)
				{
					return new ErrorResponse(e.Message);
				}
				
			}if (request is GetShowsByDateRequest)
			{
				GetShowsByDateRequest showsReq =(GetShowsByDateRequest)request;
				DateTime date = showsReq.Date;
				Console.WriteLine("Get shows by date request..." + date);
				try
				{
					Show[] shows;
					lock (server)
					{
						shows = server.findShowsByDate(date);
					}

					return new GetShowsByDateResponse(shows);
				}
				catch (FestivalException e)
				{
					return new ErrorResponse(e.Message);
				}
				
			}
			if (request is BuyTicketRequest)
			{
				BuyTicketRequest showsReq =(BuyTicketRequest)request;
				var ticket = showsReq.Ticket;
				Console.WriteLine("Buying a ticket request..." + ticket);
				try
				{
					lock (server)
					{
						 server.buyTickets(ticket.showID,ticket.buyerName,ticket.seats);
					}

					return new BuyTicketResponse(ticket);
				}
				catch (FestivalException e)
				{
					return new ErrorResponse(e.Message);
				}
				
			}
			return response;
		}

	private void sendResponse(Response response)
		{
			Console.WriteLine("sending response "+response);
            formatter.Serialize(stream, response);
            stream.Flush();
			
		}

	public void ticketBought(Ticket ticket)
	{
		Console.WriteLine("Ticket bought...");
		try
		{
			sendResponse(new RefreshData());
		}
		catch (Exception e)
		{
			Console.WriteLine(e.StackTrace);
		}
	}
	}

}