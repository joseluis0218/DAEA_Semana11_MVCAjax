using System.Web.Mvc;
using MVCAJAX.Models;
using System.Threading.Tasks;

namespace MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        Proxy.StudentProxy proxy = new Proxy.StudentProxy();
        // GET: Student

        public ActionResult IndexRazor()
        {
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return View(response.Result.listado);
        }
        public ActionResult IndexTarea()
        {
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return View(response.Result.listado);
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getStudent(string id)
        {
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult studentDetail(int id)
        {
            var response = Task.Run(() => proxy.DetailStudentAsync(id));
            return Json(response.Result.objeto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult createStudent(StudentModel student)
        {   
            var response = Task.Run(() => proxy.InsertAsync(student));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public ActionResult updateStudent(StudentModel student)
        {
            var response = Task.Run(() => proxy.UpdateAsync(student));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public ActionResult deleteStudent(int id)
        {
            var response = Task.Run(() => proxy.DeleteStudentAsync(id));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult searchStudents(string query)
        {
            var response = Task.Run(() => proxy.SearchStudentsAsync(query));
            string message = response.Result.Mensaje;
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
        }
    }

}