using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Aula
    {
        public Aula()
        {
            Edizionis = new HashSet<Edizioni>();
            Leziones = new HashSet<Lezione>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int CapacitaMassima { get; set; }
        public bool Fisica { get; set; }
        public bool? Computerizzata { get; set; }
        public bool? Proiettore { get; set; }

        public virtual ICollection<Edizioni> Edizionis { get; set; }
        public virtual ICollection<Lezione> Leziones { get; set; }
    }
}
