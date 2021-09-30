using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ef_scaffold.Entities;
using Microsoft.Extensions.Logging;

#nullable disable

namespace ef_scaffold.EfData
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aula> Aulas { get; set; }
        public virtual DbSet<Aziendum> Azienda { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Competenza> Competenzas { get; set; }
        public virtual DbSet<Corso> Corsos { get; set; }
        public virtual DbSet<Edizioni> Edizionis { get; set; }
        public virtual DbSet<Finanziatore> Finanziatores { get; set; }
        public virtual DbSet<Iscrizione> Iscriziones { get; set; }
        public virtual DbSet<Lezione> Leziones { get; set; }
        public virtual DbSet<Livello> Livellos { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Presenza> Presenzas { get; set; }
        public virtual DbSet<Progetto> Progettos { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {               
                optionsBuilder.UseSqlServer("server=localhost; database=Education; User Id=sa; Password=1Secure*Password;")
               .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name, DbLoggerCategory.Database.Transaction.Name },
                LogLevel.Information).EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.ToTable("aula");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CapacitaMassima).HasColumnName("capacita_massima");

                entity.Property(e => e.Computerizzata).HasColumnName("computerizzata");

                entity.Property(e => e.Fisica).HasColumnName("fisica");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Proiettore).HasColumnName("proiettore");
            });

            modelBuilder.Entity<Aziendum>(entity =>
            {
                entity.ToTable("azienda");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cap)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("cap")
                    .IsFixedLength(true);

                entity.Property(e => e.Citta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("citta");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Indirizzo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("indirizzo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.PartitaIva)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("partita_iva")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Argomento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("argomento");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descrizione");
            });

            modelBuilder.Entity<Competenza>(entity =>
            {
                entity.ToTable("competenza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdLevel).HasColumnName("id_level");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.IdSkill).HasColumnName("id_skill");

                entity.Property(e => e.Note)
                    .HasMaxLength(150)
                    .HasColumnName("note");

                entity.HasOne(d => d.IdLevelNavigation)
                    .WithMany(p => p.Competenzas)
                    .HasForeignKey(d => d.IdLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_livello_competenza");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Competenzas)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_persona_competenza");

                entity.HasOne(d => d.IdSkillNavigation)
                    .WithMany(p => p.Competenzas)
                    .HasForeignKey(d => d.IdSkill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_skill_competenza");
            });

            modelBuilder.Entity<Corso>(entity =>
            {
                entity.ToTable("corso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmmontareOre).HasColumnName("ammontare_ore");

                entity.Property(e => e.CostoDiRiferimento)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("costo_di_riferimento");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descrizione");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdLivello).HasColumnName("id_livello");

                entity.Property(e => e.IdProgetto).HasColumnName("id_progetto");

                entity.Property(e => e.Titolo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("titolo");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Corsos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_categoria_corso");

                entity.HasOne(d => d.IdLivelloNavigation)
                    .WithMany(p => p.Corsos)
                    .HasForeignKey(d => d.IdLivello)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_livello_corso");

                entity.HasOne(d => d.IdProgettoNavigation)
                    .WithMany(p => p.Corsos)
                    .HasForeignKey(d => d.IdProgetto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_progetto_corso");
            });

            modelBuilder.Entity<Edizioni>(entity =>
            {
                entity.ToTable("edizioni");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodiceEdizione)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codice_edizione")
                    .IsFixedLength(true);

                entity.Property(e => e.DataFine)
                    .HasColumnType("date")
                    .HasColumnName("data_fine");

                entity.Property(e => e.DataInizio)
                    .HasColumnType("date")
                    .HasColumnName("data_inizio");

                entity.Property(e => e.IdAula).HasColumnName("id_aula");

                entity.Property(e => e.IdCorso).HasColumnName("id_corso");

                entity.Property(e => e.IdFinanziatore).HasColumnName("id_finanziatore");

                entity.Property(e => e.NumeroStudentiMassimo).HasColumnName("numero_studenti_massimo");

                entity.Property(e => e.PrezzoFinale)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("prezzo_finale");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.Edizionis)
                    .HasForeignKey(d => d.IdAula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_aula_edizioni");

                entity.HasOne(d => d.IdCorsoNavigation)
                    .WithMany(p => p.Edizionis)
                    .HasForeignKey(d => d.IdCorso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_corso_edizioni");

                entity.HasOne(d => d.IdFinanziatoreNavigation)
                    .WithMany(p => p.Edizionis)
                    .HasForeignKey(d => d.IdFinanziatore)
                    .HasConstraintName("FK_id_finanziatore_edizioni");
            });

            modelBuilder.Entity<Finanziatore>(entity =>
            {
                entity.ToTable("finanziatore");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descrizione");
            });

            modelBuilder.Entity<Iscrizione>(entity =>
            {
                entity.ToTable("iscrizione");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataIscrizione)
                    .HasColumnType("date")
                    .HasColumnName("data_iscrizione");

                entity.Property(e => e.IdEdizione).HasColumnName("id_edizione");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Pagata).HasColumnName("pagata");

                entity.Property(e => e.ValutazioneCorso)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("valutazione_corso");

                entity.Property(e => e.VotoCorso).HasColumnName("voto_corso");

                entity.HasOne(d => d.IdEdizioneNavigation)
                    .WithMany(p => p.Iscriziones)
                    .HasForeignKey(d => d.IdEdizione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_edizione_iscrizione");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Iscriziones)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_persona_iscrizione");
            });

            modelBuilder.Entity<Lezione>(entity =>
            {
                entity.ToTable("lezione");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(150)
                    .HasColumnName("descrizione");

                entity.Property(e => e.Fine)
                    .HasColumnType("date")
                    .HasColumnName("fine");

                entity.Property(e => e.IdAula).HasColumnName("id_aula");

                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Inizio)
                    .HasColumnType("date")
                    .HasColumnName("inizio");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.Leziones)
                    .HasForeignKey(d => d.IdAula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_aula_lezione");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Leziones)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_modulo_lezione");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Leziones)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_persona_lezione");
            });

            modelBuilder.Entity<Livello>(entity =>
            {
                entity.ToTable("livello");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descrizione");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("modulo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("descrizione");

                entity.Property(e => e.IdEdizione).HasColumnName("id_edizione");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Ore)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ore");

                entity.HasOne(d => d.IdEdizioneNavigation)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.IdEdizione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_edizione_modulo");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_persona_modulo");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("persona");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CittaResidenza)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("citta_residenza");

                entity.Property(e => e.CodiceFiscale)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("codice_fiscale")
                    .IsFixedLength(true);

                entity.Property(e => e.Cognome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cognome");

                entity.Property(e => e.DataDiNascita)
                    .HasColumnType("date")
                    .HasColumnName("data_di_nascita");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IdAzienda).HasColumnName("id_azienda");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("nome");

                entity.Property(e => e.PartitaIva)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("partita_iva")
                    .IsFixedLength(true);

                entity.Property(e => e.Ruolo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("ruolo");

                entity.Property(e => e.Sesso)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sesso")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdAziendaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdAzienda)
                    .HasConstraintName("FK_id_azienda_persona");
            });

            modelBuilder.Entity<Presenza>(entity =>
            {
                entity.ToTable("presenza");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fine)
                    .HasColumnType("date")
                    .HasColumnName("fine");

                entity.Property(e => e.IdLezione).HasColumnName("id_lezione");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Inizio)
                    .HasColumnType("date")
                    .HasColumnName("inizio");

                entity.Property(e => e.Nota)
                    .HasMaxLength(150)
                    .HasColumnName("nota");

                entity.HasOne(d => d.IdLezioneNavigation)
                    .WithMany(p => p.Presenzas)
                    .HasForeignKey(d => d.IdLezione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_lezione_presenza");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Presenzas)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_persona_presenza");
            });

            modelBuilder.Entity<Progetto>(entity =>
            {
                entity.ToTable("progetto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descrizione");

                entity.Property(e => e.IdAzienda).HasColumnName("id_azienda");

                entity.HasOne(d => d.IdAziendaNavigation)
                    .WithMany(p => p.Progettos)
                    .HasForeignKey(d => d.IdAzienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_aziendaProgetto");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(150)
                    .HasColumnName("descrizione");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_categoria_skill");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
