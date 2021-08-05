using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services.IServices
{
    public interface ICourseService:IDisposable
    {
        Task<List<Course>> GetCourseList();

        Task<string> SaveCourse(Course course);
        Task<string> UpdateCourse(Course course);

        Task<string> DeleteCourse(int id);
        Task<Course> GetCourseById(int id);
    }
}
