using DataLayer.Repositories;
using ef_scaffold.EfData;
using ef_scaffold.Entities;
using ef_scaffold.Repository.ADORepo;
using ef_scaffold.Repository.InMemortRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold
{
    public class Service // => Service generale da chiedere a Riccardo
    {
        static SchoolContext ctx = new SchoolContext();
        IRepository<Corso, long> repoCorsi = new MemoryCourseRepository();//new CrudRepository<Corso, long>(ctx);
        IRepository<Edizioni, long> repoEdizioni = new MemoryEditionRepository(); //new CrudRepository<Edizioni, long>(ctx);

        public void ChangeRepo(long name)
        {            
            switch (name)
            {
                case 1:
                    repoCorsi = new CrudRepository<Corso, long>(ctx);
                    repoEdizioni = new CrudRepository<Edizioni, long>(ctx);
                    break;
                case 2:
                    repoCorsi = new DBCourseRepository();
                    repoEdizioni = new DBEditionRepository();
                    break;
                case 3:
                    repoCorsi = new MemoryCourseRepository();
                    repoEdizioni = new MemoryEditionRepository();
                    break;
            };
        }

        #region Corso
        public void CreateCourse(Corso c)
        {
            repoCorsi.Create(c);
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
