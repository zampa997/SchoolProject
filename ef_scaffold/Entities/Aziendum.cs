using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Aziendum
    {
        public Aziendum()
        {
            Personas = new HashSet<Persona>();
            Progettos = new HashSet<Progetto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Citta { get; set; }
        public string Indirizzo { get; set; }
        public string Cap { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string PartitaIva { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<Progetto> Progettos { get; set; }
    }
}
