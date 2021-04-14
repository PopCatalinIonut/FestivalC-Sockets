using System;
using festival.model;

namespace festival.network.protocol
{
    
    public interface Request 
    {
    }


    [Serializable]
    public class LoginRequest : Request
    {
        private User user;

        public LoginRequest(User user) { this.user = user; }

        public virtual User User
        {
            get
            {
                return user;
            }
        }
    }
    
      
    [Serializable]
    public class BuyTicketRequest : Request
    {
        private Ticket ticket;

        public BuyTicketRequest(Ticket ticket) { this.ticket = ticket; }

        public virtual Ticket Ticket
        {
            get
            {
                return ticket;
            }
        }

    }
    [Serializable]
    public class LogoutRequest : Request
    {
        private User user;

        public LogoutRequest(User user) { this.user = user; }

        public virtual User User
        {
            get
            {
                return user;
            }
        }

    }
    [Serializable]
    public class GetAllShowsRequest : Request { }
    [Serializable]
    public class GetShowsByDateRequest : Request
    {
        private DateTime date;

        public GetShowsByDateRequest(DateTime date) { this.date = date; }

        public virtual DateTime Date
        {
            get
            {
                return date;
            }
        }
        
    }
  
}