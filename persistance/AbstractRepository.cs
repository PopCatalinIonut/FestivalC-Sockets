
using System;
using System.Collections.Generic;
using System.Linq;
using festival.model;
using festival.model.validator;

namespace festival.persistance
{

    class AbstractRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
    {
        protected IValidator<E> vali;

        protected IDictionary<ID, E> entities = new Dictionary<ID, E>();

        public AbstractRepository(IValidator<E> vali) {    this.vali = vali;}

        public IEnumerable<E> FindAll(){
            return entities.Values.ToList<E>();
        }

        public E Save(E entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity must not be null");
            this.vali.Validate(entity);
            if (this.entities.ContainsKey(entity.ID))
                return entity;

            this.entities[entity.ID] = entity;
            return default(E);
        }

        public E Update(E entity)
        {
            throw new NotImplementedException();
        }
    }
}
