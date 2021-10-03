using NodaTime;
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

        public long Id { get; set; }
        public string CodiceEdizione { get; set; }
        public LocalDate DataInizio { get; set; }
        public LocalDate DataFine { get; set; }
        public decimal PrezzoFinale { get; set; }
        public long NumeroStudentiMassimo { get; set; }
        public long IdAula { get; set; }
        public long IdCorso { get; set; }
        public long? IdFinanziatore { get; set; }

        public virtual Aula IdAulaNavigation { get; set; }
        public virtual Corso IdCorsoNavigation { get; set; }
        public virtual Finanziatore IdFinanziatoreNavigation { get; set; }
        public virtual ICollection<Iscrizione> Iscriziones { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }

        public Edizioni(long id, string codice, long idCorso, LocalDate start, LocalDate end,
         int numStudents, decimal realPrice, long idAula, long idFinanziatore)
        {
            this.Id = id;
            this.CodiceEdizione = codice;
            this.DataInizio = start;
            this.DataFine = end;
            this.NumeroStudentiMassimo = numStudents;
            this.PrezzoFinale = realPrice;            
            this.IdAula = idAula;
            this.IdFinanziatore = idFinanziatore;
            this.IdCorso = idCorso;
        }
        public override string ToString()
        {
            return $@"Id:{Id}
                    Titolo corso:{IdCorsoNavigation.Titolo}
                    Data inizio:{DataInizio}
                    Prezzo finale:{PrezzoFinale}";
        }
    }
}
