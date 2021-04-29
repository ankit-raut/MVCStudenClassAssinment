using MVCStudenClassAssinment.Model;
using System.Collections.Generic;

namespace MVCStudenClassAssinment.BAL
{
    public interface IStudentService
    {
        StudenParentViewModel GetStudenDetailById(int studentId);

        List<StudenParentViewModel> GetStudenDetailsList();

        bool SaveStudentDetails(StudenParentViewModel model);
    }
}
