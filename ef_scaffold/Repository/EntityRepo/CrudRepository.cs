using ef_scaffold;
using ef_scaffold.EfData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CrudRepository<T, K> : IRepository<T, K> where T : class
    {
        private readonly SchoolContext ctx;
        private DbSet<T> entities;
        public CrudRepository(SchoolContext ctx)
        {
            this.ctx = ctx;
            this.entities = ctx.Set<T>();
        }

        public T Create(T newElement)
        {
            entities.Add(newElement);
            ctx.SaveChanges();
            return newElement;
        }

        public T Delete(K id)
        {
            T found = entities.Find(id);
            if (found == null)
            {
                return null;
            }
            entities.Remove(found);
            ctx.SaveChanges();
            return found;
        }
        public T Delete(T element)
        {
            entities.Remove(element);
            int r = ctx.SaveChanges();
            return r <= 0 ? null : element;
        }

        public T FindbyId(K id)
        {
            return entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public IEnumerable<T> GetEditionsByIdCourse(K idCorso)
        {
            return null;
        }

        public void Update(T newElement)
        {
            entities.Update(newElement);
            ctx.SaveChanges();
        }
    }
}
