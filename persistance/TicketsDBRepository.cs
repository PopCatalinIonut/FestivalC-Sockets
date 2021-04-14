
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using festival.model.validator;
using festival.model;

namespace festival.persistance
{
    public class TicketsDBRepository : TicketsRepositoryInterface
    {
        private TicketValidator vali = new TicketValidator();
        public IEnumerable<Ticket> FindAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Ticket> tickets = new List<Ticket>();
            using (var ticketsComm = con.CreateCommand())
            {
                ticketsComm.CommandText = "select * from Tickets";
                using (var ticketsReader=ticketsComm.ExecuteReader())
                {
                    while (ticketsReader.Read())
                    {
                        int ticketID = ticketsReader.GetInt32(0);
                        int showID = ticketsReader.GetInt32(1);
                        String buyerName = ticketsReader.GetString(2);
                        int seats = ticketsReader.GetInt32(3);
                        
                        using (var showsComm = con.CreateCommand())
                        {
                            showsComm.CommandText = "select S.*, A.name from Shows S left join Artists A where S.ID = @showID and S.artistId = A.ID";
                            
                            var showsIdParam = showsComm.CreateParameter();
                            showsIdParam.ParameterName = "@showID";
                            showsIdParam.Value = showID;
                            showsComm.Parameters.Add(showsIdParam);
                            
                            using (var showsReader = showsComm.ExecuteReader())
                            {
                                while (showsReader.Read())
                                {                             
                                    String location = showsReader.GetString(1);
                                    DateTime date = Convert.ToDateTime(showsReader.GetDateTime(2));
                                    int artistID = showsReader.GetInt32(3);
                                    String name = showsReader.GetString(4);
                                    int totalSeats = showsReader.GetInt32(5);
                                    int soldSeats = showsReader.GetInt32(6);
                                    String artistName = showsReader.GetString(7);

                                    Artist artist = new Artist(artistID, artistName);
                                    Ticket ticket = new Ticket(ticketID, showID, buyerName, seats);
                                    tickets.Add(ticket);
                                    
                                }
                            }
                        }
                    }
                }
            }
            con.Close();
            return tickets;
        }

        public Ticket Save(Ticket entity)
        {
            try
            {
                vali.Validate(entity);
                var con = DBUtils.getConnection();
                using (var comm = con.CreateCommand())
                {
                    comm.CommandText =
                        "insert into Tickets(showId,buyerName,seats) values (@showID, @buyerName, @seats)";
                    

                    var paramShowId = comm.CreateParameter();
                    paramShowId.ParameterName = "@showID";
                    paramShowId.Value = entity.showID;
                    comm.Parameters.Add(paramShowId);

                    var paramBuyerName = comm.CreateParameter();
                    paramBuyerName.ParameterName = "@buyerName";
                    paramBuyerName.Value = entity.buyerName;
                    comm.Parameters.Add(paramBuyerName);

                    var paramSeats = comm.CreateParameter();
                    paramSeats.ParameterName = "@seats";
                    paramSeats.Value = entity.seats;
                    comm.Parameters.Add(paramSeats);

                    var result = comm.ExecuteNonQuery();
                    if (result == 0)
                        Trace.WriteLine("No tickets added!");
                    else                                
                        Trace.WriteLine("Ticket added");

                }
            }
            catch (ValidationException val) {
                Trace.WriteLine(val.ToString());
            }

            return entity;
        }
        
    }
}
