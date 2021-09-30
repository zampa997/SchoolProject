using DataLayer.Repositories;
using ef_scaffold.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold.Repository.InMemortRepository
{
    class MemoryCourseRepository : ICrudRepository<Corso, long>
    {
        public Corso Create(Corso newElement)
        {
            throw new NotImplementedException();
        }

        public Corso Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Corso FindbyId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Corso> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Corso newElement)
        {
            throw new NotImplementedException();
        }
    }
}
