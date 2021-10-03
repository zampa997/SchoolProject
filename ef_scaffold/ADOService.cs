using ef_scaffold.Entities;
using ef_scaffold.Repository.ADORepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold
{
    public class ADOService : Service
    {
        public DBCourseRepository CourseRepo { get; set; }
        public DBEditionRepository EditionRepo { get; set; }

        public void CreateCourse(Corso c)
        {
            CourseRepo.Create(c);
        }
        public void CreateEdition(Edizioni e)
        {
            EditionRepo.Create(e);
        }
        public IEnumerable<Corso> GetAllCourses()
        {
            return CourseRepo.GetAll();
        }
        public IEnumerable<Edizioni> GetAllEditions()
        {
            return EditionRepo.GetAll();
        }
        public Corso DeleteCourse(long id)
        {
            return CourseRepo.Delete(id);
        }
        public Edizioni DeleteEdition(long id)
        {
            return EditionRepo.Delete(id);
        }
        public Corso FindCoursebyId(long id)
        {
            return CourseRepo.FindbyId(id);
        }
        public Edizioni FindEditionbyId(long id)
        {
            return EditionRepo.FindbyId(id);
        }
        public void UpdateCourse(Corso newElement)
        {
            CourseRepo.Update(newElement);
        }
        public void UpdateEdition(Edizioni newElement)
        {
            EditionRepo.Update(newElement);
        }
    }
}
