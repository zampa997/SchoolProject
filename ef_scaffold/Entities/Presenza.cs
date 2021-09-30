using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Presenza
    {
        public int Id { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Nota { get; set; }
        public int IdPersona { get; set; }
        public int IdLezione { get; set; }

        public virtual Lezione IdLezioneNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
