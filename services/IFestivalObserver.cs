

using festival.model;

namespace festival.services
{
    public interface IFestivalObserver
    {
        void ticketBought(Ticket ticket);
    }
}