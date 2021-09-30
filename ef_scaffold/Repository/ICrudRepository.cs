using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ICrudRepository<T, K>
    {
        public IEnumerable<T> GetAll();
        public T Create(T newElement);
        public T Delete(K id);
        public T FindbyId(K id);
        void Update(T newElement);
    }
}
