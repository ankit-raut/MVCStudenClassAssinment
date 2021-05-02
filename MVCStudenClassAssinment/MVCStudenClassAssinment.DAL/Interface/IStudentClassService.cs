using MVCStudentClassAssignment.Model;
using MVCStudentClassAssignment.Model.Model;
using MVCStudentClassAssignment.Model.ViewModel;
using System.Collections.Generic;

namespace MVCStudentClassAssignment.DAL
{
    public interface IStudentClassService
    {
        List<SchoolClassViewModel> GetSchoolClasses();

        bool UpdateStatus(List<StudenParentViewModel> studentStatusModels);
    }
}
