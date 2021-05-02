using MVCStudentClassAssignment.Model;

using System.Collections.Generic;
using System.Linq;

namespace MVCStudentClassAssignment.DAL
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

        public StudenParentViewModel GetStudentDetailById(int studentId) => GetStudentDetailsByIdModelReady(studentId);

        public List<StudenParentViewModel> GetStudentDetailList() => GetParentStudentDetails();

        public bool SaveStudentDetails(StudenParentViewModel model) => SaveParentStudentDetails(model);

        public List<SchoolClassViewModel> GetClassList() => GetSchoolClassList();

        #endregion

        #region Private Method

        private List<StudenParentViewModel> GetParentStudentDetails()
        {
            List<StudenParentViewModel> models;

            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                models = (from parentStudent in db.ParentStudents
                          join studentClass in db.StudentClasss on parentStudent.Student.Id equals studentClass.Student.Id
                          where parentStudent.Student.UserType == UserTypes.Student
                          select new StudenParentViewModel
                          {
                              Active = parentStudent.Student.Active,
                              ParentEmail = parentStudent.Parent.Email,
                              ParentId = parentStudent.Parent.Id,
                              StudentId = parentStudent.Student.Id,
                              ParentMobile = parentStudent.Parent.Phone,
                              StudentEmail = parentStudent.Student.Email,
                              StudentFirstName = parentStudent.Student.FirstName,
                              StudentLastName = parentStudent.Student.LastName,
                              ParentFirstName = parentStudent.Parent.FirstName,
                              ParentLastName = parentStudent.Parent.LastName,
                              UserType = parentStudent.Student.UserType,
                              StudentClassId = studentClass.Class.Id,
                              StudentClass = studentClass.Class.Name
                          }).ToList<StudenParentViewModel>();
            }
            return models;
        }

        private StudenParentViewModel GetStudentDetailsByIdModelReady(int studentId)
        {
            StudenParentViewModel model = GetParentStudentDetails().FirstOrDefault(x => x.StudentId == studentId);
            model = model ?? new StudenParentViewModel();
            model.StudentClassList = model?.StudentClassList ?? new List<SchoolClassViewModel>();
            model.StudentClassList = GetSchoolClassList();
            return model;
        }

        private List<SchoolClassViewModel> GetSchoolClassList() => studentClassService.GetSchoolClasses();

        private bool SaveParentStudentDetails(StudenParentViewModel model)
        {
            if (Equals(model, null))
                return false;

            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var student = db.ParentStudents.FirstOrDefault(x => x.Student.Id == model.StudentId);

                student.Student.FirstName = model.StudentFirstName;
                student.Student.LastName = model.StudentLastName;
                student.Student.Active = model.Active;
                student.Parent.FirstName = model.ParentFirstName;
                student.Parent.LastName = model.ParentLastName;
                student.Parent.Email = model.ParentEmail;
                student.Parent.Phone = model.ParentMobile;

                var studentClass = db.StudentClasss.FirstOrDefault(x => x.Student.Id == model.StudentId);
                studentClass.Class = db.SchoolClasss.FirstOrDefault(x => x.Id == model.StudentClassId);

                if (db.SaveChanges() > 0)
                    return true;
            }

            return true;
        }

        #endregion
    }
}
