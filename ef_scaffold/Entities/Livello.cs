using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Livello
    {
        public Livello()
        {
            Competenzas = new HashSet<Competenza>();
            Corsos = new HashSet<Corso>();
        }

        public int Id { get; set; }
        public string Descrizione { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Competenza> Competenzas { get; set; }
        public virtual ICollection<Corso> Corsos { get; set; }
    }
}
