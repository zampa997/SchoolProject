using DataLayer.Repositories;
using ef_scaffold.EfData;
using ef_scaffold.Entities;
using ef_scaffold.Repository.ADORepo;
using ef_scaffold.Repository.InMemortRepository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold
{
    public class Service // => Service unitario per tipo di memoria.
                         // vuole il costruttore con i suoi Repo da iniettare.
    {
        /*
            public IRepository<Corso,long> RepoCorsi {set; get;}
            ... {set; get;}
            ... {set; get;}
            ...

            public ServiceADO(IRepository<Corso,long> repoCorsi, ..., ..., ...)
            {
                RepoCorsi = repoCorsi;
                ...;
                ...;
                ...
            }
         */
        static SchoolContext ctx = new SchoolContext();
        //static SqlConnection conn = new SqlConnection(CONNECTION_STRING); => DA PASSARE AI REPO DI ADO
        IRepository<Corso, long> repoCorsi = new MemoryCourseRepository();//new CrudRepository<Corso, long>(ctx);
        IRepository<Edizioni, long> repoEdizioni = new MemoryEditionRepository(); //new CrudRepository<Edizioni, long>(ctx);

        IRepository<Categoria, long> repoCategoria = new CrudRepository<Categoria, long>(ctx);
        IRepository<Livello, long> repoLivello = new CrudRepository<Livello, long>(ctx);
        IRepository<Azienda, long> repoAzienda = new CrudRepository<Azienda, long>(ctx);
        IRepository<Aula, long> repoAula = new CrudRepository<Aula, long>(ctx);
        IRepository<Finanziatore, long> repoFinanziatore = new CrudRepository<Finanziatore, long>(ctx);
        IRepository<Progetto, long> repoProgetto = new CrudRepository<Progetto, long>(ctx);

        public void ChangeRepo(long name)
        {            
            switch (name)
            {             
                case 1:
                    repoCorsi = new CrudRepository<Corso, long>(ctx);                  
                    repoEdizioni = new CrudRepository<Edizioni, long>(ctx);
                    repoCategoria = new CrudRepository<Categoria, long>(ctx);
                    repoLivello = new CrudRepository<Livello, long>(ctx);
                    repoAzienda = new CrudRepository<Azienda, long>(ctx);
                    repoAula = new CrudRepository<Aula, long>(ctx);
                    repoFinanziatore = new CrudRepository<Finanziatore, long>(ctx);
                    repoProgetto = new CrudRepository<Progetto, long>(ctx);
                    break;
                case 2:
                    repoCorsi = new DBCourseRepository();
                    repoEdizioni = new DBEditionRepository();
                    //repoCategoria
                    //repoLivello
                    //repoAzienda
                    //repoAula
                    //repoFinanziatore
                    //repoProgetto
                    break;
                case 3:
                    repoCorsi = new MemoryCourseRepository();
                    repoEdizioni = new MemoryEditionRepository();
                    //repoCategoria
                    //repoLivello
                    //repoAzienda
                    //repoAula
                    //repoFinanziatore
                    //repoProgetto
                    break;
            };
        }

        //i controlli agli ID dentro gli oggetti andranno fatti qui
        //Il service userà il metodo SaveChanges o Commit sulla connessione
        //Il service creerà la connessione che passerà ai repository

        #region Corso
        public void CreateCourse(Corso c)
        {
            repoCorsi.Create(c);
            //ctx.SaveChanges() : null;
            //conn.Commit : RollBack;
        }
        public IEnumerable<Corso> GetAllCourses()
        {
            return repoCorsi.GetAll();
        }
        public Corso DeleteCourse(long id)
        {
            return repoCorsi.Delete(id);
        }
        public Corso FindCoursebyId(long id)
        {
            return repoCorsi.FindbyId(id);
        }
        public void UpdateCourse(Corso newElement)
        {
            repoCorsi.Update(newElement);
        }
        #endregion

        #region Edizioni
        public void CreateEdition(Edizioni e)
        {
            repoEdizioni.Create(e);
        }
        public IEnumerable<Edizioni> GetAllEditions()
        {
            return repoEdizioni.GetAll();
        }
        public Edizioni DeleteEdition(long id)
        {
            return repoEdizioni.Delete(id);
        }
        public Edizioni FindEditionbyId(long id)
        {
            return repoEdizioni.FindbyId(id);
        }
        public void UpdateEdition(Edizioni newElement)
        {
            repoEdizioni.Update(newElement);
        }
        public IEnumerable<Edizioni> FindEditionsByIdCourse(long id)
        {
            return repoEdizioni.GetEditionsByIdCourse(id);
        }
        #endregion

        //#region Utilities
        //public static bool ProjectExist(long id)
        //{

        //}
        //#endregion
    }
}
