using CoursesLibrary.Models;
using RepositoryEF.Interfaces;
using RepositoryLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesLibrary.Interfaces
{
    public interface ICourseRepository : IRepositoryEF<Course>
    {
        IEnumerable<Course> GetTopSellingCourses(int count = 10);
        IEnumerable<Course> GetCoursesWithAuthors(int pageIndex = 0, int pageSize = 10);
    }
}
