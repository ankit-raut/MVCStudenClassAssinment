using MVCStudenClassAssinment.Model;
using MVCStudenClassAssinment.Model.Model;
using MVCStudenClassAssinment.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCStudenClassAssinment.DAL
{
    public class StudentClassService : IStudentClassService
    {
        #region Public Method
        public List<SchoolClassViewModel> GetSchoolClasses() => GetClasses();

        public bool UpdateStatus(List<StudenParentViewModel> studentStatusModels) => UpdatUserStatus(studentStatusModels);
        #endregion

        #region Private Method
        private static List<SchoolClassViewModel> GetClasses()
        {
            List<SchoolClass> list = null;
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                list = db.SchoolClasss.ToList();
            }
            return list.Select(x => new SchoolClassViewModel { ClassId = x.Id, Name = x.Name }).ToList<SchoolClassViewModel>();
        }


        private static bool UpdatUserStatus(List<StudenParentViewModel> model)
        {
            if (model.Count > 0)
            {
                using (ApplicationDBContext db = new ApplicationDBContext())
                {
                    model.ForEach(x =>
                    {
                        foreach (var item in db.Users.Where(y => y.Id == x.StudentId))
                        {
                            item.Active = x.Active;
                        }
                    });

                    return db.SaveChanges() > 0;
                }
            }
            return true;
        }
        #endregion
    }
}
