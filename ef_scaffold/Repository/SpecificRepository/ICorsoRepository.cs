using DataLayer.Repositories;
using ef_scaffold.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold.Repository
{
    public interface ICorsoRepository : ICrudRepository<Corso, long>
    {

    }
}
