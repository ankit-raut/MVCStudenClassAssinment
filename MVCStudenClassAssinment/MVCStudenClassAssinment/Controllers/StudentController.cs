using MVCStudenClassAssinment.BAL;
using MVCStudenClassAssinment.Model;
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
            return View(studentService.GetStudenDetailsList());
        }

        [HttpGet]
        public ActionResult Edit(int studentId)
        {
            return View(studentService.GetStudenDetailById(studentId));
        }

        [HttpPost]
        public ActionResult Edit(StudenParentViewModel model)
        {
            return View(studentService.SaveStudentDetails(model));
        }


    }
}