using DataLayer.Repositories;
using ef_scaffold.Entities;
using ef_scaffold.Repository.ADORepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold.Repository.InMemortRepository
{
    class MemoryCourseRepository :IRepository<Corso, long>
    {
        private List<Corso> courses = new List<Corso>();
        
        public Corso Create(Corso newElement)
        {
            courses.Add(newElement);
            return newElement;
        }

        public Corso Delete(long id)
        {
            Corso c = FindbyId(id);
            courses.Remove(c);
            return c;
        }

        public Corso FindbyId(long id)
        {           
            return courses.Find(e => e.Id == id);
        }

        public IEnumerable<Corso> GetAll()
        {
            return courses;
        }

        public IEnumerable<Corso> GetEditionsByIdCourse(long idCorso)
        {
            return null;
        }

        public void Update(Corso newElement)
        {
            Delete(newElement.Id);
            Create(newElement);
        }
    }
}
