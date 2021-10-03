using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Corso
    {
        public Corso()
        {
            Edizionis = new HashSet<Edizioni>();
        }
        

        public long Id { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public long AmmontareOre { get; set; }
        public decimal CostoDiRiferimento { get; set; }
        public long IdLivello { get; set; }
        public long IdProgetto { get; set; }
        public long IdCategoria { get; set; }       
        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual Livello IdLivelloNavigation { get; set; }
        public virtual Progetto IdProgettoNavigation { get; set; }
        public virtual ICollection<Edizioni> Edizionis { get; set; }

        public Corso(long id, string titolo, int ammontareOre, decimal costoDiRiferimento,
           long idLivello, long idProgetto, long idCategoria, string descrizione)
        {
            Id = id;
            Titolo = titolo;
            AmmontareOre = ammontareOre;
            CostoDiRiferimento = costoDiRiferimento;
            this.IdProgetto = idProgetto;
            this.IdLivello = idLivello;
            this.IdCategoria = idCategoria;
            Descrizione = descrizione;
        }
        public Corso(long id, string titolo, int ammontareOre, decimal costoDiRiferimento,
           Livello livello, Progetto progetto, Categorium categioria, string descrizione)
        {
            Id = id;
            Titolo = titolo;
            AmmontareOre = ammontareOre;
            CostoDiRiferimento = costoDiRiferimento;
            Descrizione = descrizione;
            IdCategoriaNavigation = categioria;
            IdLivelloNavigation = livello;
            IdProgettoNavigation = progetto;
        }
        public override string ToString()
        {
            return $@"Id:{Id}
                    Titolo:{Titolo}";
        }

        public override bool Equals(object obj)
        {
            return obj is Corso corso && Id == corso.Id;
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }
    }
}
