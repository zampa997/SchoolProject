using DataLayer.Repositories;
using ef_scaffold.EfData;
using ef_scaffold.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold.Repository.SpecificRepository
{
    public class CorsoRepository : CrudRepository<Corso, long>, ICorsoRepository
    {
        public CorsoRepository(SchoolContext ctx) : base(ctx)
        {

        }
    }
}
