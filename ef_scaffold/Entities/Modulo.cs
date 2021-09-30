using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Modulo
    {
        public Modulo()
        {
            Leziones = new HashSet<Lezione>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Ore { get; set; }
        public string Descrizione { get; set; }
        public int IdPersona { get; set; }
        public int IdEdizione { get; set; }

        public virtual Edizioni IdEdizioneNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Lezione> Leziones { get; set; }
    }
}
