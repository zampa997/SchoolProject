using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            Competenzas = new HashSet<Competenza>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual ICollection<Competenza> Competenzas { get; set; }
    }
}
