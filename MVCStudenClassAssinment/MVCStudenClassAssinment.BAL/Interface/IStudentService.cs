using MVCStudenClassAssinment.Model;
using MVCStudenClassAssinment.Model.ViewModel;
using System.Collections.Generic;

namespace MVCStudenClassAssinment.BAL
{
    public interface IStudentService
    {
        StudenParentViewModel GetStudenDetailById(int studentId);

        List<StudenParentViewModel> GetStudenDetailsList();

        bool SaveStudentDetails(StudenParentViewModel model);

        List<SchoolClassViewModel> GetClassList();

        bool UpdateStatus(StudentStatusModel[] studentStatusModel);

    }
}
