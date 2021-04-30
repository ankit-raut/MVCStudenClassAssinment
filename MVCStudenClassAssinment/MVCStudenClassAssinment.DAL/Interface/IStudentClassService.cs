using MVCStudenClassAssinment.Model;
using MVCStudenClassAssinment.Model.Model;
using MVCStudenClassAssinment.Model.ViewModel;
using System.Collections.Generic;

namespace MVCStudenClassAssinment.DAL
{
    public interface IStudentClassService
    {
        List<SchoolClassViewModel> GetSchoolClasses();

        bool UpdateStatus(List<StudenParentViewModel> studentStatusModels);
    }
}
