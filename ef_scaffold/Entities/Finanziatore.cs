using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Finanziatore
    {
        public Finanziatore()
        {
            Edizionis = new HashSet<Edizioni>();
        }

        public int Id { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<Edizioni> Edizionis { get; set; }
    }
}
