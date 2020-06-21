using CoursesLibrary.Interfaces;
using CoursesLibrary.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryEF.Implementations;
using RepositoryLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoursesLibrary.Implementations
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(CoursesDBContext context)
            :base(context)
        {
        }
        private CoursesDBContext CoursesContext
        {
            get
            {
                //Since we know the type of the context via the constructor we can do the following
                return Context as CoursesDBContext;
            }
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex = 0, int pageSize = 10)
        {
            List<Course> coursesCollection = null;

            int recordsToSkip = (pageIndex - 1) * pageSize;

            coursesCollection = CoursesContext.Courses
                .Include(c => c.Authors)
                .OrderBy(c => c.Id)
                .Skip(recordsToSkip)
                .Take(pageSize)
                .ToList();

            return coursesCollection;
        }

        public IEnumerable<Course> GetTopSellingCourses(int count = 10)
        {
            return CoursesContext.Courses.OrderByDescending(c => c.SalesTimes).Take(count).ToList();
        }
    }
}
