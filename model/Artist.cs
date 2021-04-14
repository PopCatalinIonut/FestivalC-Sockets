using System;

namespace festival.model
{
    [Serializable]
    public class Artist: Entity<int>
    {
        public String name { get; set; }

        public Artist(int ID, String name) {
            this.ID = ID;
            this.name = name;
        }
        
        public override string ToString()
        {
            return "ID: "+ ID.ToString()+" name: "+name+" ";
        }
    }
}
