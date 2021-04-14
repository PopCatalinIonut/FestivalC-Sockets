using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using festival.persistance;
using festival.model;
using festival.services;

namespace festival.server
{
    public class FestivalService : IFestivalServices
    {
       

        private ArtistsDBRepository artistsRepo;
        private ShowsDBRepository showsRepo;
        private TicketsDBRepository ticketsRepo;
        private EmployeeRepository employeeRepo;
        private readonly IDictionary <String, IFestivalObserver> loggedClients;

        public FestivalService(ArtistsDBRepository artistsRepo, ShowsDBRepository showsRepo, TicketsDBRepository ticketsRepo, EmployeeRepository employeeRepo)
        {
            this.artistsRepo = artistsRepo;
            this.showsRepo = showsRepo;
            this.ticketsRepo = ticketsRepo;
            this.employeeRepo = employeeRepo;
            loggedClients=new Dictionary<String, IFestivalObserver>();
        }
        

        public Show[] findShowsByDate(DateTime date)
        {
            return this.showsRepo.FindAll().ToArray();
        }

        void IFestivalServices.buyTickets(int showID, string buyerName, int seats)
        {
            if (this.showsRepo.hasAvailableSeats(showID, seats))
            {
                this.showsRepo.updateSeats(showID,seats);
                Ticket ticket = new Ticket(showID, buyerName, seats);
                this.ticketsRepo.Save(ticket);
                foreach (var el in loggedClients)
                {
                    if (el.Value != null)
                        el.Value.ticketBought(ticket);
                }
            }
            else throw new FestivalException("Not so many seats available");
        }

        public bool existsEmployee(String username, String password)
        {
            return this.employeeRepo.existsEmployee(username, password);
        }


        public void buyTickets(int showId, string buyerName, int tickets)
        {
            Ticket ticket = new Ticket( showId, buyerName, tickets);
            if (this.showsRepo.hasAvailableSeats(showId, tickets) == true)
            {
                this.showsRepo.updateSeats(showId,tickets);
                this.ticketsRepo.Save(ticket);
                foreach (KeyValuePair<string, IFestivalObserver> client in loggedClients)
                {
                    client.Value.ticketBought(ticket);
                }
            }
            else 
                throw new IOException("Not so many seats available!");
        }
        

        public void login(User user, IFestivalObserver client)
        {
            if (employeeRepo.existsEmployee(user.username, user.password) == true)
            {
               if (loggedClients.ContainsKey(user.username))
                    throw new FestivalException("User already logged in.");
                loggedClients[user.username] = client;
            }
            else
                    throw new FestivalException("Authentication failed."); 
        }

        public void logout(User user, IFestivalObserver client)
        {
            bool removed = this.loggedClients.Remove(user.username);
            if (removed == false)
                throw new FestivalException("User " + user.username + " its not logged on");
        }

        Show[] IFestivalServices.findAllShows()
        {
            return  this.showsRepo.FindAll().ToArray();
        }
    }
}