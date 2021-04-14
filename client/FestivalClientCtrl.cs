using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using chat.client;
using festival.model;
using festival.services;

namespace festival.client
{
    public class FestivalClientCtrl : IFestivalObserver
    { 
        public event EventHandler<FestivalUserEventArgs> updateEvent; //ctrl calls it when it has received an update
        private readonly IFestivalServices server;
        private User currentUser;
        
        public FestivalClientCtrl(IFestivalServices server)
        {
            this.server = server;
        }

        public void login(string username, string password)
        {
            User user=new User(username,password);
            try
            {
                server.login(user, this);
                Console.WriteLine("Login succeeded ....");
                currentUser = user;
                Console.WriteLine("Current user {0}", user);
            }
            catch (FestivalException e)
            {
                MessageBox.Show("Invalid username or password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Show[] findAllShows()
        {
            return this.server.findAllShows().ToArray();
        }
        
        private void OnUserEvent(FestivalUserEventArgs userArgs)
        {
            if (updateEvent == null) return;
            updateEvent(this, userArgs);
            Trace.WriteLine("Update Event called");
        }

        public Show[] findAllShowsByDate(DateTime date)
        {
            return this.server.findShowsByDate(date);
        }

        public void buyTickets(Ticket ticket)
        {      
            Trace.WriteLine("ticketssss");
            this.server.buyTickets(ticket.showID,ticket.buyerName,ticket.seats);
        }
        public void ticketBought(Ticket ticket)
        {
            Console.WriteLine("Buying ticket and telling everyone...");
            FestivalUserEventArgs userArgs = new FestivalUserEventArgs(FestivalUserEvent.TicketBought,ticket);
            OnUserEvent(userArgs);
        }

        public void logout()
        {
            try
            {
                this.server.logout(currentUser, this);
            }
            catch (FestivalException e)
            {
                MessageBox.Show("Logout error", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}