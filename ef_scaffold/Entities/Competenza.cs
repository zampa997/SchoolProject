using System;
using System.Collections.Generic;

#nullable disable

namespace ef_scaffold.Entities
{
    public partial class Competenza
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int IdPersona { get; set; }
        public int IdSkill { get; set; }
        public int IdLevel { get; set; }

        public virtual Livello IdLevelNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Skill IdSkillNavigation { get; set; }
    }
}
