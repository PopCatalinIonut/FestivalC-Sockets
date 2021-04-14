using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using festival.model;
using festival.network.protocol;
using festival.services;

namespace festival.network
{
	///
	/// <summary> * Created by IntelliJ IDEA.
	/// * User: grigo
	/// * Date: Mar 18, 2009
	/// * Time: 4:36:34 PM </summary>
	/// 
	public class FestivalServerProxy : IFestivalServices
	{
		private string host;
		private int port;

		private IFestivalObserver client;

		private NetworkStream stream;
		
        private IFormatter formatter;
		private TcpClient connection;

		private Queue<Response> responses;
		private volatile bool finished;
        private EventWaitHandle _waitHandle;
		public FestivalServerProxy(string host, int port)
		{
			this.host = host;
			this.port = port;
			responses=new Queue<Response>();
		}

		public virtual void login(User user, IFestivalObserver client)
		{
			initializeConnection();
			sendRequest(new LoginRequest(user));
			Response response =readResponse();
			if (response is OkResponse)
			{
				this.client=client;
				return;
			}
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				closeConnection();
				throw new FestivalException(err.Message);
			}
		}

		public void logout(User user, IFestivalObserver client)
		{
			sendRequest(new LogoutRequest(user));
			Response response =readResponse();
			if (response is OkResponse)
			{
				closeConnection();
				return;
			}
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				throw new FestivalException(err.Message);
			}
		}

		public Show[] findAllShows()
		{
			sendRequest(new GetAllShowsRequest());
			Response response =readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				throw new FestivalException(err.Message);
			}

			GetAllShowsResponse resp = (GetAllShowsResponse) response;
			return resp.Shows;
		}

		public Show[] findShowsByDate(DateTime date)
		{
			sendRequest(new GetShowsByDateRequest(date));
			Response response =readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				throw new FestivalException(err.Message);
			}

			GetShowsByDateResponse resp = (GetShowsByDateResponse) response;
			return resp.Shows;
		}

		public void buyTickets(int showID, string buyerName, int seats)
		{
			Ticket ticket = new Ticket(showID, buyerName, seats);
			sendRequest(new BuyTicketRequest(ticket));
			Response response =readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				throw new FestivalException(err.Message);
			}
		}


		private void closeConnection()
		{
			finished=true;
			try
			{
				stream.Close();
				//output.close();
				connection.Close();
                _waitHandle.Close();
				client=null;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}

		}

		private void sendRequest(Request request)
		{
			try
			{
                formatter.Serialize(stream, request);
                stream.Flush();
			}
			catch (Exception e)
			{
				throw new FestivalException("Error sending object "+e);
			}

		}

		private Response readResponse()
		{
			Response response =null;
			try
			{
                _waitHandle.WaitOne();
				lock (responses)
				{
					Trace.WriteLine("Got a response...");
					response = responses.Dequeue();
                    
				}
				

			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
			return response;
		}
		private void initializeConnection()
		{
			 try
			 {
				connection=new TcpClient(host,port);
				stream=connection.GetStream();
                formatter = new BinaryFormatter();
				finished=false;
                _waitHandle = new AutoResetEvent(false);
				startReader();
			}
			catch (Exception e)
			{
                Console.WriteLine(e.StackTrace);
			}
		}
		private void startReader()
		{
			Thread tw =new Thread(run);
			tw.Start();
		}

		
		private void handleUpdate(UpdateResponse update)
		{
			if (update is RefreshData)
			{
				Console.WriteLine("Refreshing data");
				try
				{
					client.ticketBought(new Ticket(0,null,0));
				}
				catch (FestivalException e)
				{
					Console.WriteLine(e.StackTrace);
				}
			}
		
		}
		public virtual void run()
			{
				while(!finished)
				{
					try
					{
                        object response = formatter.Deserialize(stream);
						Console.WriteLine("response received "+response);
						if (response is UpdateResponse)
						{
							 handleUpdate((UpdateResponse)response);
						}
						else
						{
							
							lock (responses)
							{
                                					
								 
                                responses.Enqueue((Response)response);
                               
							}
                            _waitHandle.Set();
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Reading error "+e);
					}
					
				}
			}
		//}
	}

}