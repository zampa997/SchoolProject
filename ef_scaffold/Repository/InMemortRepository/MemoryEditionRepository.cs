using DataLayer.Repositories;
using ef_scaffold.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold.Repository.InMemortRepository
{
    class MemoryEditionRepository : IRepository<Edizioni, long>
    {
        private List<Edizioni> courseEditions = new List<Edizioni>();
        public Edizioni Create(Edizioni newElement)
        {
            courseEditions.Add(newElement);
            return newElement;
        }

        public Edizioni Delete(long id) // PARKUOURURRU
        {
            Edizioni c = FindbyId(id);
            courseEditions.Remove(c);
            return c;
        }

        public Edizioni FindbyId(long id)
        {
            return courseEditions.Find(e => e.Id == id);
        }

        public IEnumerable<Edizioni> GetAll()
        {
            return courseEditions;
        }

        public IEnumerable<Edizioni> GetEditionsByIdCourse(long idCorso)
        {
            return courseEditions.Where(e => e.IdCorso == idCorso);
        }

        public void Update(Edizioni newElement)
        {
            Delete(newElement.Id);
            Create(newElement);
        }
    }
}
