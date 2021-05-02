using MVCStudenClassAssinment.DAL;
using MVCStudenClassAssinment.Model;
using MVCStudenClassAssinment.Model.ViewModel;

using System;
using System.Collections.Generic;

namespace MVCStudenClassAssinment.BAL
{
    public class StudentService : IStudentService
    {
        #region Private variable
        private readonly MVCStudenClassAssinment.DAL.IStudentService _studentService = null;
        private readonly IStudentClassService _studentClassService = null;

        #endregion

        #region Constructor

        public StudentService()
        {
            _studentService = new MVCStudenClassAssinment.DAL.StudentService();
            _studentClassService = new StudentClassService();
        }

        #endregion

        #region Public Method

        /// <summary>
        /// This method is used to get Student Details 
        /// </summary>
        /// <param name="studentId">Get by studentId</param>
        /// <returns>Model</returns>
        public StudenParentViewModel GetStudenDetailById(int studentId) => GetStudentDetailsById(studentId);

        /// <summary>
        /// This method is used to get List of student 
        /// </summary>
        /// <returns>List of model</returns>
        public List<StudenParentViewModel> GetStudenDetailsList() => GetStudentDetailsList();

        /// <summary>
        /// This method is used update Student Details list
        /// </summary>
        /// <param name="model">updated Model</param>
        /// <returns>true=> success, false=> error</returns>
        public bool SaveStudentDetails(StudenParentViewModel model) => SaveStudentDetail(model);

        /// <summary>
        /// This method is used get list of Classes
        /// </summary>
        /// <returns>list of Classes</returns>
        public List<SchoolClassViewModel> GetClassList() => GetStudentClassList();

        /// <summary>
        /// This method is used to update Active status from List page.
        /// </summary>
        /// <param name="studentStatusModel">array of StudentStatusModel</param>
        /// <returns>true=> success, false=> error</returns>
        public bool UpdateStatus(StudentStatusModel[] studentStatusModel) => UpdateUserStatus(studentStatusModel);

        #endregion

        #region Private Methods

        private List<SchoolClassViewModel> GetStudentClassList()
        {
            return _studentService.GetClassList();
        }

        private bool SaveStudentDetail(StudenParentViewModel model)
        {
            return _studentService.SaveStudentDetails(model);
        }

        private List<StudenParentViewModel> GetStudentDetailsList()
        {
            return _studentService.GetStudentDetailList();
        }

        private StudenParentViewModel GetStudentDetailsById(int studentId)
        {
            return _studentService.GetStudentDetailById(studentId);
        }

        private bool UpdateUserStatus(StudentStatusModel[] studentStatusModel)
        {
            List<StudenParentViewModel> model = new List<StudenParentViewModel>();

            foreach (StudentStatusModel item in studentStatusModel)
                model.Add(new StudenParentViewModel { StudentId = Convert.ToInt32(item.Studentid), Active = Convert.ToBoolean(item.Status) });

            return _studentClassService.UpdateStatus(model);
        }

        #endregion
    }
}
