using System.Collections.Generic;
using festival.model;

namespace festival.persistance
{
    interface IRepository<ID, E> where E : Entity<ID>
    {
        IEnumerable<E> FindAll();
        E Save(E entity);
    }
}
