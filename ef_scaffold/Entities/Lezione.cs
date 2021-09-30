using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Lezione
    {
        public Lezione()
        {
            Presenzas = new HashSet<Presenza>();
        }

        public int Id { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Descrizione { get; set; }
        public int IdAula { get; set; }
        public int IdPersona { get; set; }
        public int IdModulo { get; set; }

        public virtual Aula IdAulaNavigation { get; set; }
        public virtual Modulo IdModuloNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Presenza> Presenzas { get; set; }
    }
}
