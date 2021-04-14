using System;

namespace festival.model
{
    [Serializable]
    public class Ticket : Entity<int>
    {
        public int showID { get; set; }
        public String buyerName { get; set; }
        public int seats { get; set; }
        public  Ticket(int ID,int showID, String buyerName, int seats)
        {
            this.showID = showID;
            this.ID = ID;
            this.buyerName = buyerName;
            this.seats = seats;
        }
        
        public  Ticket(int show, String buyerName, int seats)
        {
            this.showID = show;
            this.buyerName = buyerName;
            this.seats = seats;
        }
        
        public override string ToString() {
            return "ID: "+ ID.ToString() + ", show: "+ showID+ ", name: " + buyerName + " seats: " + seats;
        }
    }
}
