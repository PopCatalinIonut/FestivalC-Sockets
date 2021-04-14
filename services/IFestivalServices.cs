using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using festival.model;

namespace festival.services
{
    public interface IFestivalServices
    
    {
        void login(User user, IFestivalObserver client);
        void logout(User user, IFestivalObserver client);
        Show[] findAllShows();
        Show[] findShowsByDate(DateTime date);
        void buyTickets(int showID, String buyerName, int seats);
    }
}