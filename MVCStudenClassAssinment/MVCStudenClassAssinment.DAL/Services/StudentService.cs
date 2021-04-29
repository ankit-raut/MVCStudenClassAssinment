using MVCStudenClassAssinment.Model;

using System.Collections.Generic;
using System.Linq;

namespace MVCStudenClassAssinment.DAL
{
    public class StudentService : IStudentService
    {
        #region Private variable
        private readonly IStudentClassService studentClassService = null;
        #endregion

        #region Constructor
        public StudentService()
        {
            studentClassService = new StudentClassService();
        }
        #endregion

        #region Public Method

        public StudenParentViewModel GetStudentDetailById(int studentId)
        {
            StudenParentViewModel model = GetParentStudentDetails().FirstOrDefault(x => x.StudentId == studentId);
            model = model ?? new StudenParentViewModel();
            model.StudentClassList = model?.StudentClassList ?? new List<SchoolClassViewModel>();
            model.StudentClassList = studentClassService.GetSchoolClasses();
            return model;
        }

        public List<StudenParentViewModel> GetStudentDetailList() => GetParentStudentDetails();

        public bool SaveStudentDetails(StudenParentViewModel model)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Private Method

        private List<StudenParentViewModel> GetParentStudentDetails()
        {
            List<StudenParentViewModel> models;

            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                models = (from parentStudent in context.ParentStudents
                          join student in context.Users on parentStudent.Student equals student
                          join parent in context.Users on parentStudent.Parent equals parent
                          join studentClass in context.StudentClasss on student equals studentClass.Student
                          select new StudenParentViewModel
                          {
                              Active = student.Active,
                              ParentEmail = parent.Email,
                              StudentEmail = student.Email,
                              ParentId = parent.Id,
                              StudentId = student.Id,
                              ParentMobile = parent.Phone,
                              StudentFirstName = student.FirstName,
                              StudentLastName = student.LastName,
                              ParentFullName = parent.FirstName,
                              UserType = student.UserType,
                              StudentClassId = studentClass.Id
                          }).Where(x => x.UserType == UserTypes.Student).ToList();
            }
            return models;
        }

        //private bool SaveStudentDetails()
        //{

        //}

        #endregion
    }
}
