using Microsoft.AspNetCore.Mvc;
using practice1.Models;
using practice1.Repository.Interface;

namespace practice1.Controllers
{
    [ServiceFilter(typeof(CustomExceptionFilter))]
    public class IndexController : Controller
    {
        private readonly IStudentInterface _studentRepo;

        public IndexController(IStudentInterface studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var student = await _studentRepo.GetAllStudentRepo();
            if (student != null && student.Count > 0)
            {
                return Json(new { Success = true, data = student });
            }
            else
            {
                return Json(new { Success = false, Message = "No Data Found" });
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetStateData()
        {
            var student = await _studentRepo.GetStateData();
            if (student != null && student.Count > 0)
            {
                return Json(new { Success = true, data = student });
            }
            else
            {
                return Json(new { Success = false, Message = "No Data Found" });
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetCityData(int StateID)
        {
            var student = await _studentRepo.GetCityData(StateID);
            if (student != null && student.Count > 0)
            {
                return Json(new { Success = true, data = student });
            }
            else
            {
                return Json(new { Success = false, Message = "No Data Found" });
            }

        }



        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            int b = 0;
            int a  = 10/b;
            if (student == null)
            {
                return View();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            int res = await _studentRepo.AddStudentRepo(student);

            if (res > 0)
            {
                return Json(new { Success = true,Message = "Student Added Succesfully" } );
            }
            else
            {
                return Json(new { Success = false, Message = "Student Not Added" });
            }

        }

    }
}
