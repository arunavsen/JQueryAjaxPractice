using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Test.Models;
using Test.Services.IServices;

namespace Test.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCourseList()
        {
            var courses = await _context.Courses.ToListAsync();

            return courses;
        }

        public async Task<Course> GetCourseById(int id)
        {
            var courses = await _context.Courses.FindAsync(id);
            return courses;
        }

        public async Task<string> SaveCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return "Saved Successfully";
        }

        public async Task<string> UpdateCourse(Course course)
        {
            var item = await _context.Courses.FindAsync(course.Id);
            if (item != null)
            {
                item.Name = course.Name;
                item.Code = course.Code;
                await _context.SaveChangesAsync();

                return "Updated Successfully";
            }
            return "Item not found";
        }

        public async Task<string> DeleteCourse(int id)
        {
            var item =  _context.Courses.Find(id);
            if (item != null)
            {
                _context.Courses.Remove(item);
                await _context.SaveChangesAsync();

                return "Deleted Successfully";
            }
            return "Course not found";
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}