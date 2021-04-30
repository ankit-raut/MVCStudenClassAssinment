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

        public StudenParentViewModel GetStudenDetailById(int studentId) => _studentService.GetStudentDetailById(studentId);

        public List<StudenParentViewModel> GetStudenDetailsList() => _studentService.GetStudentDetailList();

        public bool SaveStudentDetails(StudenParentViewModel model) => _studentService.SaveStudentDetails(model);

        public List<SchoolClassViewModel> GetClassList() => _studentService.GetClassList();

        public bool UpdateStatus(StudentStatusModel[] studentStatusModel) => UpdateUserStatus(studentStatusModel);

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
