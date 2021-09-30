using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Edizioni
    {
        public Edizioni()
        {
            Iscriziones = new HashSet<Iscrizione>();
            Modulos = new HashSet<Modulo>();
        }

        public int Id { get; set; }
        public string CodiceEdizione { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public decimal PrezzoFinale { get; set; }
        public int NumeroStudentiMassimo { get; set; }
        public int IdAula { get; set; }
        public int IdCorso { get; set; }
        public int? IdFinanziatore { get; set; }

        public virtual Aula IdAulaNavigation { get; set; }
        public virtual Corso IdCorsoNavigation { get; set; }
        public virtual Finanziatore IdFinanziatoreNavigation { get; set; }
        public virtual ICollection<Iscrizione> Iscriziones { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }
    }
}
