using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Categoria
    {
        public Categoria()
        {
            Corsos = new HashSet<Corso>();
            Skills = new HashSet<Skill>();
        }

        public int Id { get; set; }
        public string Descrizione { get; set; }
        public string Argomento { get; set; }

        public virtual ICollection<Corso> Corsos { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
