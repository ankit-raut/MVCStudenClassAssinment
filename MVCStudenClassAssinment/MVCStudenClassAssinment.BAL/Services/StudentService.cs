using MVCStudenClassAssinment.Model;

using System.Collections.Generic;

namespace MVCStudenClassAssinment.BAL
{
    public class StudentService : IStudentService
    {
        #region Private variable
        private readonly MVCStudenClassAssinment.DAL.IStudentService _studentService = null;
        #endregion

        #region Constructor

        public StudentService()
        {
            _studentService = new MVCStudenClassAssinment.DAL.StudentService();
        }

        #endregion

        #region Public Method

        public StudenParentViewModel GetStudenDetailById(int studentId) => _studentService.GetStudentDetailById(studentId);

        public List<StudenParentViewModel> GetStudenDetailsList() => _studentService.GetStudentDetailList();

        public bool SaveStudentDetails(StudenParentViewModel model)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
