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

        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public int AmmontareOre { get; set; }
        public decimal CostoDiRiferimento { get; set; }
        public int IdLivello { get; set; }
        public int IdProgetto { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual Livello IdLivelloNavigation { get; set; }
        public virtual Progetto IdProgettoNavigation { get; set; }
        public virtual ICollection<Edizioni> Edizionis { get; set; }
    }
}
