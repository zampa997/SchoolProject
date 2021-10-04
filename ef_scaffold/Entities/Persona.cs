using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Competenzas = new HashSet<Competenza>();
            Iscriziones = new HashSet<Iscrizione>();
            Leziones = new HashSet<Lezione>();
            Modulos = new HashSet<Modulo>();
            Presenzas = new HashSet<Presenza>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public string Sesso { get; set; }
        public string CittaResidenza { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string PartitaIva { get; set; }
        public string Ruolo { get; set; }
        public int? IdAzienda { get; set; }

        public virtual Azienda IdAziendaNavigation { get; set; }
        public virtual ICollection<Competenza> Competenzas { get; set; }
        public virtual ICollection<Iscrizione> Iscriziones { get; set; }
        public virtual ICollection<Lezione> Leziones { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }
        public virtual ICollection<Presenza> Presenzas { get; set; }
    }
}
