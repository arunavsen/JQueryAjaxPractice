using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using Test.Services.IServices;

namespace Test.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        // GET: Course
        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<PartialViewResult> PartialCourseList()
        {
            var courseList = await _service.GetCourseList();
            return PartialView(courseList);
        }

        [HttpGet]
        public async Task<JsonResult> GetCourseById(int id)
        {
            var coursedata = await _service.GetCourseById(id);
            return Json(new { course = coursedata }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public async Task<JsonResult> Save(Course course)
        {
            if (course.Id == 0)
            {
                var x = await _service.SaveCourse(course);
                return Json(x);
            }
            else
            {
                var x = await _service.UpdateCourse(course);
                return Json(x);
            }

        }

        public async Task<JsonResult> Delete(int id)
        {
            var tt = await _service.DeleteCourse(id);
            return Json(tt);
        }

    }
}