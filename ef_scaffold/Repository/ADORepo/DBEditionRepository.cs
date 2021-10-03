using DataLayer.Repositories;
using ef_scaffold.Entities;
using Esercizi.Model.Data;
using Microsoft.Data.SqlClient;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold.Repository.ADORepo
{
    public class DBEditionRepository : IRepository<Edizioni, long>
    {
        const string CONNECTION_STRING = @"Server = localhost;             
                                            User=sa;             
                                            Password=1Secure*Password;             
                                            Database = scuola";
        const string INSERT_EDIZIONE = @"INSERT INTO dbo.edizioni (codice_edizione, data_inizio, data_fine, prezzo_finale, numero_studenti_massimo, in_presenza, id_aula, id_corso, id_finanziatore)
                                        OUTPUT INSERTED.id                   
                                        VALUES (@codice_edizione, @data_inizio, @data_fine, @prezzo_finale, @numero_studenti_massimo, @in_presenza, @id_aula, @id_corso, @id_finanziatore);";
        const string SELECT_ALL_EDITIONS = @"Select id, codice_edizione, data_inizio, data_fine, prezzo_finale, numero_studenti_massimo, id_presenza, id_aula, id_corso, id_finanziatore
                                           FROM dbo.edizioni";
        const string SELECT_EDITION = @"Select id, codice_edizione, data_inizio, data_fine, prezzo_finale, numero_studenti_massimo, id_aula, id_corso, id_finanziatore
                                        FROM dbo.edizioni
                                        WHERE id = @id";
        const string SELECT_EDITIONS_BY_ID = @"Select id, codice_edizione, data_inizio, data_fine, prezzo_finale, numero_studenti_massimo, id_aula, id_corso, id_finanziatore
                                            FROM dbo.edizioni
                                            WHERE id_corso = @id";
        const string DELETE_EDITION = @"DELETE FROM dbo.edizioni
                                        WHERE id = @id";
        const string UPDATE_EDITION = @"UPDATE dbo.edizioni SET codice_edizione = @codice_edizione, data_inizio = @data_inizio, data_fine = @data_fine, prezzo_finale = #prezzo_finale
                                         numero_studenti_massimo = @numero_studenti_massimo, id_aula = @id_aula, id_corso = @id_corso, id_finanziatore = @id_finanziatore
                                         WHERE id = @id";
        public Edizioni Create(Edizioni edizione)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {

                    SqlCommand cmd = new SqlCommand(INSERT_EDIZIONE, conn);
                    cmd.Parameters.AddWithValue("@codice_edizione", edizione.CodiceEdizione);
                    cmd.Parameters.AddWithValue("@data_inizio", edizione.DataInizio);
                    cmd.Parameters.AddWithValue("@data_fine", edizione.DataFine);
                    cmd.Parameters.AddWithValue("@prezzo_finale", edizione.PrezzoFinale);
                    cmd.Parameters.AddWithValue("@in_presenza", 1);
                    cmd.Parameters.AddWithValue("@numero_studenti_massimo", edizione.NumeroStudentiMassimo);
                    cmd.Parameters.AddWithValue("@id_aula", edizione.IdAula);
                    cmd.Parameters.AddWithValue("@id_corso", edizione.IdCorso);
                    cmd.Parameters.AddWithValue("@id_finanziatore", edizione.IdFinanziatore);
                    conn.Open();
                    //int newId = (int)cmd.ExecuteScalar();
                    //edizione.Id = newId;
                    cmd.ExecuteNonQuery();

                }
                return edizione;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }

        public Edizioni Delete(long id)
        {
            try
            {
                Edizioni e = FindbyId(id);
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(DELETE_EDITION, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = id;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return e;
                }               
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }

        public Edizioni FindbyId(long id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    Edizioni ez = null;
                    SqlCommand cmd = new SqlCommand(SELECT_EDITION, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = id;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string codice_edizione = reader.GetString("codice_edizione");
                            LocalDate data_inizio = reader.GetLocalDate("data_inizio");
                            LocalDate data_fine = reader.GetLocalDate("data_fine");
                            decimal prezzo_finale = reader.GetDecimal("prezzo_finale");
                            int numero_studenti_massimo = reader.GetInt32("numero_studenti_massimo");
                            long id_presenza = reader.GetInt32("id_presenza");
                            long id_aula = reader.GetInt32("id_aula");
                            long id_corso = reader.GetInt32("id_corso");
                            long id_finanziatore = reader.GetInt32("id_finanziatore");
                            ez = new Edizioni(id, codice_edizione, id_corso, data_inizio, data_fine, numero_studenti_massimo, prezzo_finale, id_aula, id_finanziatore);
                            return ez;
                        }
                        return ez;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }

        public IEnumerable<Edizioni> GetAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(SELECT_ALL_EDITIONS, conn);
                    List<Edizioni> r = new List<Edizioni>();
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long id = reader.GetInt32("id");
                            string codice_edizione = reader.GetString("codice_edizione");
                            LocalDate data_inizio = reader.GetLocalDate("data_inizio");
                            LocalDate data_fine = reader.GetLocalDate("data_fine");
                            decimal prezzo_finale = reader.GetDecimal("prezzo_finale");
                            int numero_studenti_massimo = reader.GetInt32("numero_studenti_massimo");
                            long id_presenza = reader.GetInt32("id_presenza");
                            long id_aula = reader.GetInt32("id_aula");
                            long id_corso = reader.GetInt32("id_corso");
                            long id_finanziatore = reader.GetInt32("id_finanziatore");
                            Edizioni cr = new Edizioni(id, codice_edizione, id_corso, data_inizio, data_fine, numero_studenti_massimo, prezzo_finale, id_aula, id_finanziatore);
                            r.Add(cr);
                        }
                    }

                    return r;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void Update(Edizioni edizione)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(UPDATE_EDITION, conn);
                    cmd.Parameters.AddWithValue("@codice_edizione", edizione.CodiceEdizione);
                    cmd.Parameters.AddWithValue("@data_inizio", edizione.DataInizio.AtMidnight().ToDateTimeUnspecified());
                    cmd.Parameters.AddWithValue("@data_fine", edizione.DataFine.AtMidnight().ToDateTimeUnspecified());
                    cmd.Parameters.AddWithValue("@prezzo_finale", edizione.PrezzoFinale);
                    cmd.Parameters.AddWithValue("@in_presenza", 1);
                    cmd.Parameters.AddWithValue("@numero_studenti_massimo", edizione.NumeroStudentiMassimo);
                    cmd.Parameters.AddWithValue("@id_aula", edizione.IdAula);
                    cmd.Parameters.AddWithValue("@id_corso", edizione.IdCorso);
                    cmd.Parameters.AddWithValue("@id_finanziatore", edizione.IdFinanziatore);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
            }
        }
        public IEnumerable<Edizioni> GetEditionsByIdCourse(long idCorso)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    List<Edizioni> ez = null;
                    SqlCommand cmd = new SqlCommand(SELECT_EDITIONS_BY_ID, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters["@id"].Value = idCorso;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            long id = reader.GetInt32("id");
                            string codice_edizione = reader.GetString("codice_edizione");
                            LocalDate data_inizio = reader.GetLocalDate("data_inizio");
                            LocalDate data_fine = reader.GetLocalDate("data_fine");
                            decimal prezzo_finale = reader.GetDecimal("prezzo_finale");
                            int numero_studenti_massimo = reader.GetInt32("numero_studenti_massimo");
                            long id_presenza = reader.GetInt32("id_presenza");
                            long id_aula = reader.GetInt32("id_aula");
                            long id_corso = reader.GetInt32("id_corso");
                            long id_finanziatore = reader.GetInt32("id_finanziatore");
                            Edizioni e = new Edizioni(id, codice_edizione, id_corso, data_inizio, data_fine, numero_studenti_massimo, prezzo_finale, id_aula, id_finanziatore);
                            ez.Add(e);
                            return ez;
                        }
                        return ez;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }
    }
}
