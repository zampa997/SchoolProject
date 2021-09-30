using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Progetto
    {
        public Progetto()
        {
            Corsos = new HashSet<Corso>();
        }

        public int Id { get; set; }
        public string Descrizione { get; set; }
        public int IdAzienda { get; set; }

        public virtual Aziendum IdAziendaNavigation { get; set; }
        public virtual ICollection<Corso> Corsos { get; set; }
    }
}
