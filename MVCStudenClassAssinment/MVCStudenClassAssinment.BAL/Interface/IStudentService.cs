using MVCStudenClassAssinment.Model;
using MVCStudenClassAssinment.Model.ViewModel;
using System.Collections.Generic;

namespace MVCStudenClassAssinment.BAL
{
    public interface IStudentService
    {

        /// <summary>
        /// This method is used to get Student Details 
        /// </summary>
        /// <param name="studentId">Get by studentId</param>
        /// <returns>Model</returns>
        StudenParentViewModel GetStudenDetailById(int studentId);

        /// <summary>
        /// This method is used to get List of student 
        /// </summary>
        /// <returns>List of model</returns>
        List<StudenParentViewModel> GetStudenDetailsList();

        /// <summary>
        /// This method is used update Student Details list
        /// </summary>
        /// <param name="model">updated Model</param>
        /// <returns>true=> success, false=> error</returns>
         bool SaveStudentDetails(StudenParentViewModel model);

        /// <summary>
        /// This method is used get list of Classes
        /// </summary>
        /// <returns>list of Classes</returns>
         List<SchoolClassViewModel> GetClassList();

        /// <summary>
        /// This method is used to update Active status from List page.
        /// </summary>
        /// <param name="studentStatusModel">array of StudentStatusModel</param>
        /// <returns>true=> success, false=> error</returns>
         bool UpdateStatus(StudentStatusModel[] studentStatusModel);

    }
}
