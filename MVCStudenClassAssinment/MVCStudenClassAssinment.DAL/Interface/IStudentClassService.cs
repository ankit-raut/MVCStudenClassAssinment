using MVCStudenClassAssinment.Model;
using MVCStudenClassAssinment.Model.Model;
using System.Collections.Generic;

namespace MVCStudenClassAssinment.DAL
{
    public interface IStudentClassService
    {
        List<SchoolClassViewModel> GetSchoolClasses();
    }
}
