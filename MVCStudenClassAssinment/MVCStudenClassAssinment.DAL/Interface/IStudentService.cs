using MVCStudentClassAssignment.Model;
using System.Collections.Generic;

namespace MVCStudentClassAssignment.DAL
{
    public interface IStudentService
    {
        StudenParentViewModel GetStudentDetailById(int studentId);

        List<StudenParentViewModel> GetStudentDetailList();

        bool SaveStudentDetails(StudenParentViewModel model);

        List<SchoolClassViewModel> GetClassList();
    }
}
