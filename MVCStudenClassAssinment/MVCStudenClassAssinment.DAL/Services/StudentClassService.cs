using MVCStudenClassAssinment.Model;
using MVCStudenClassAssinment.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace MVCStudenClassAssinment.DAL
{
    public class StudentClassService : IStudentClassService
    {
        public List<SchoolClassViewModel> GetSchoolClasses()
        {
            List<SchoolClassViewModel> viewModelList = new List<SchoolClassViewModel>() ;
            List<SchoolClass> list = null;
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                //viewModelList = context.SchoolClasss.Select(x=> new SchoolClass { Id = x.Id, Name=x.Name }).ToList<SchoolClass>();

                //viewModelList = (from schoolClass in context.SchoolClasss
                //                 select new SchoolClassViewModel { ClassId = schoolClass.Id, Name = schoolClass.Name }).ToList<SchoolClassViewModel>();


                 list = context.SchoolClasss.ToList();
            }
            return list.Select(x=> new SchoolClassViewModel { ClassId = x.Id, Name = x.Name }).ToList<SchoolClassViewModel>();
        }
    }
}
