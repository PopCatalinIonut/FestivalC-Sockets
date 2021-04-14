using System;
namespace festival.model
{
    [Serializable]
    public class Show : Entity<int>
    {
        public String name { get; set; }
        public String location { get; set; }
        public DateTime date { get; set; }

      
        public Artist artist { get; set; }
        public int totalSeats { get; set; }
        public int soldSeats { get; set; }

        public Show(int ID, String name, String location, DateTime date, Artist artist, int totalSeats, int soldSeats)
        {
            this.ID = ID;
            this.name = name;
            this.location = location;
            this.date = date;
            this.artist = artist;
            this.totalSeats = totalSeats;
            this.soldSeats = soldSeats;
        }
        
        public override string ToString() {
            return "ID: "+ ID.ToString() + ", location: "+ location + ", name: " + name + ", artist{ " + artist.ToString() + " }, date: " + date.ToString();
        }
    }
}
