using DataLayer.Repositories;
using ef_scaffold.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold.Repository.ADORepo
{
    public class DBCourseRepository : IRepository<Corso, long>
    {
        const string CONNECTION_STRING = @"Server = localhost;             
                                            User=sa;             
                                            Password=1Secure*Password;             
                                            Database = scuola";
        const string INSERT_CORSO = @"INSERT INTO dbo.corso (titolo, descrizione, ammontare_ore, costo_di_riferimento, id_progetto, id_livello, id_categoria)
                                          OUTPUT INSERTED.id  
                                          VALUES (@titolo, @descrizione, @ammontare_ore, @costo_di_riferimento, @id_progetto, @id_livello, @id_categoria);";
        const string SELECT_CORSO = @"Select id, titolo, descrizzione, ammontare_ore, costo_di_riferimento, id_livello, id_progetto, id_categoria
                                          FROM dbo.corso
                                          where @id=id";
        const string SELECT_ALL_CORSO = @"Select id, titolo, descrizione, ammontare_ore, costo_di_riferimento, id_livello, id_progetto, id_categoria
                                            FROM dbo.corso";
        const string DELETE_CORSO = @"DELETE FROM dbo.corso
                                        WHERE id = @id";
        const string UPDATE_CORSO = @"UPDATE dbo.edizioni SET titolo = @titolo, descrizione = @descrizione, ammontare_ore = @ammontare_ore, costo_di_riferimento = @costo_di_riferimento
                                      id_livello = @id_livello, id_progetto = @id_progetto, id_categoria = @id_categoria
                                      WHERE id = @id";

        public Corso Create(Corso corso)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_CORSO, conn);
                    cmd.Parameters.AddWithValue("@nome", corso.Titolo);
                    cmd.Parameters.AddWithValue("@descrizione", corso.Descrizione);
                    cmd.Parameters.AddWithValue("@ammontare_ore", corso.AmmontareOre);
                    cmd.Parameters.AddWithValue("@costo_di_riferimento", corso.CostoDiRiferimento);
                    cmd.Parameters.AddWithValue("@id_livello", corso.IdLivello);
                    cmd.Parameters.AddWithValue("@id_progetto", corso.IdProgetto);
                    cmd.Parameters.AddWithValue("@id_categoria", corso.IdCategoria);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //int newId = (int)cmd.ExecuteScalar();
                    //corso.Id = newId;
                    //return corso;
                }
                return corso;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
                return null;
            }
        }

        public Corso Delete(long id)
        {
            try
            {
                Corso e = FindbyId(id);
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(DELETE_CORSO, conn);
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

        public Corso FindbyId(long id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    Corso cr = null;
                    SqlCommand cmd = new SqlCommand(SELECT_CORSO, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    conn.Open();
                    cmd.Parameters["@id"].Value = id;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string titolo = reader.GetString("nome");
                            string descrizione = reader.GetString("descrizione");
                            int ammontare_ore = reader.GetInt32("ammontare_ore");
                            decimal costo_di_riferimento = reader.GetDecimal("costo_di_riferimento");
                            int id_livello = reader.GetInt32("id_livello");
                            int id_progetto = reader.GetInt32("id_progetto");
                            int id_categoria = reader.GetInt32("id_categoria");
                            cr = new Corso(id, titolo, ammontare_ore, (long)costo_di_riferimento, id_livello, id_progetto, id_categoria, descrizione);
                        }
                        return cr;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<Corso> GetAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(SELECT_ALL_CORSO, conn);
                    List<Corso> r = new List<Corso>();
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string titolo = reader.GetString("titolo");
                            string descrizione = reader.GetString("descrizzione");
                            int ammontare_ore = reader.GetInt32("ammontare_ore");
                            decimal costo_di_riferimento = reader.GetDecimal("costo_di_riferimento");
                            int id_livello = reader.GetInt32("id_livello");
                            int id_progetto = reader.GetInt32("id_progetto");
                            int id_categoria = reader.GetInt32("id_categoria");
                            Corso cr = new Corso(id, titolo, ammontare_ore, (long)costo_di_riferimento, id_livello, id_progetto, id_categoria, descrizione);
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

        public IEnumerable<Corso> GetEditionsByIdCourse(long idCorso)
        {
            return null;
        }

        public void Update(Corso corso)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand(UPDATE_CORSO, conn);
                    cmd.Parameters.AddWithValue("@titolo", corso.Titolo);
                    cmd.Parameters.AddWithValue("@descrizzione", corso.Descrizione);
                    cmd.Parameters.AddWithValue("@ammontare_ore", corso.AmmontareOre);
                    cmd.Parameters.AddWithValue("@costo_di_riferimento", corso.CostoDiRiferimento);
                    cmd.Parameters.AddWithValue("@id_livello", corso.IdLivello);
                    cmd.Parameters.AddWithValue("@id_progetto", corso.IdProgetto);
                    cmd.Parameters.AddWithValue("@id_categoria", corso.IdCategoria);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Errore, inserimento non andato a buon fine: " + e.Message);
            }
        }
    }
}
