using System;
using festival.model;

namespace festival.network.protocol
{
    using User = festival.model.User;

    public interface Response 
    {
    }

    [Serializable]
    public class OkResponse : Response
    {
		
    }

    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get
            {
                return message;
            }
        }
    }

   
    public interface UpdateResponse : Response
    {
    }
    [Serializable]
    public class RefreshData : UpdateResponse
    {
    }
    [Serializable]
    public class GetAllShowsResponse : Response
    {
        private Show[] shows;

        public GetAllShowsResponse(Show[] shows)
        {
            this.shows = shows;
        }

        public virtual Show[] Shows
        {
            get
            {
                return shows;
            }
        }
    }
    [Serializable]
    public class GetShowsByDateResponse : Response
    {
        private Show[] shows;

        public GetShowsByDateResponse(Show[] shows)
        {
            this.shows = shows;
        }

        public virtual Show[] Shows
        {
            get
            {
                return shows;
            }
        }
    }
    [Serializable]
    public class BuyTicketResponse : Response
    {
        private Ticket ticket;

        public BuyTicketResponse(Ticket ticket) { this.ticket = ticket; }

        public virtual Ticket Ticket
        {
            get
            {
                return ticket;
            }
        }
    }
}