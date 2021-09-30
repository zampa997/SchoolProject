using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Iscrizione
    {
        public int Id { get; set; }
        public DateTime DataIscrizione { get; set; }
        public string ValutazioneCorso { get; set; }
        public int VotoCorso { get; set; }
        public bool Pagata { get; set; }
        public int IdPersona { get; set; }
        public int IdEdizione { get; set; }

        public virtual Edizioni IdEdizioneNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
