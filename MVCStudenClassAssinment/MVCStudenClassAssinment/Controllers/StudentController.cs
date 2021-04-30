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

        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View(GetStudenDetailsList());
        }

        [HttpGet]
        public ActionResult Edit(int studentId) => View(GetStudenDetailById(studentId));

        [HttpPost]
        public ActionResult Edit(StudenParentViewModel model)
        {
            ModelState.Remove("StudentEmail");
            if (ModelState.IsValid && SaveStudentDetails(model))
            {
                ViewBag.Message = TempData["Message"] = "Successfully Updated !";
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Not Updated !";
            model.StudentClassList = studentService.GetClassList();
            return View(model);
        }

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