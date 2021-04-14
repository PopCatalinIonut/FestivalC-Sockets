
using System;

namespace festival.model
{
    [Serializable]
    public class Entity<TID>
    {
        public TID ID { get; set; }
    }
}
