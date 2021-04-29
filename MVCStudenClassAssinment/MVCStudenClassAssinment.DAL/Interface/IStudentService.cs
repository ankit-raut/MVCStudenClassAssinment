using MVCStudenClassAssinment.Model;
using System.Collections.Generic;

namespace MVCStudenClassAssinment.DAL
{
    public interface IStudentService
    {
        StudenParentViewModel GetStudentDetailById(int studentId);

        List<StudenParentViewModel> GetStudentDetailList();

        bool SaveStudentDetails(StudenParentViewModel model);
    }
}
