using MVCStudenClassAssinment.BAL;
using MVCStudenClassAssinment.Model;
using MVCStudenClassAssinment.Model.ViewModel;

using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCStudenClassAssinment.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService = null;

        public StudentController()
        {
            studentService = new StudentService();
        }

        /// <summary>
        /// List of Students
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View(GetStudenDetailsList());
        }

        /// <summary>
        /// Call Edit action get method
        /// </summary>
        /// <param name="studentId">by studentId</param>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Edit(int studentId) => View(GetStudenDetailById(studentId));

        /// <summary>
        ///  Call Edit action post method to update data in database
        /// </summary>
        /// <param name="model">StudenParentViewModel</param>
        /// <returns>view</returns>
        [HttpPost]
        public ActionResult Edit(StudenParentViewModel model)
        {
            ModelState.Remove("StudentEmail");
            if (ModelState.IsValid && SaveStudentDetails(model) && model.StudentClassId != 0)
            {
                ViewBag.Message = TempData["Message"] = "Successfully Updated !";
                return RedirectToAction("Index");
            }
            else           
                ModelState.AddModelError(nameof(model.StudentClassId), "Select valid Class");
            ViewBag.Message = "Not Updated !";
            model.StudentClassList = studentService.GetClassList();
            return View(model);
        }

        /// <summary>
        /// This method is used to update Active status of student.
        /// </summary>
        /// <param name="studentId">array of StudentStatusModel</param>
        /// <returns>true=> success, false=> error</returns>
        [HttpPost]
        public JsonResult UpdateStudentStatus(StudentStatusModel[] studentStatus)
        {
            Tuple<bool, string> response = UpdateStatus(studentStatus);
            return Json(new { IsSuccess = response.Item1, IsCommonException = response.Item2 }, JsonRequestBehavior.AllowGet);
        }

        #region Private Method

        private List<StudenParentViewModel> GetStudenDetailsList() => studentService.GetStudenDetailsList();

        private StudenParentViewModel GetStudenDetailById(int studentId) => studentService.GetStudenDetailById(studentId);

        private bool SaveStudentDetails(StudenParentViewModel model) => studentService.SaveStudentDetails(model);

        private Tuple<bool, string> UpdateStatus(StudentStatusModel[] studentStatus)
        {
            string exceptionMessage = string.Empty;
            bool isSuccess = false;
            try
            {
                isSuccess = studentService.UpdateStatus(studentStatus);
            }
            catch (System.Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return new Tuple<bool, string>(isSuccess, exceptionMessage);
        }

        #endregion


    }
}