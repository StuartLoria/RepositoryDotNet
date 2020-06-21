using CoursesLibrary.Interfaces;
using CoursesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesLibrary.Implementations
{
    public class UnitOfWorkCourses : IUnitOfWorkCourses
    {
        private readonly CoursesDBContext _context;
        public ICourseRepository Courses { get; private set; }

        public IAuthorRepository Authors { get; private set; }

        public UnitOfWorkCourses(CoursesDBContext context, ICourseRepository courses, IAuthorRepository authors)
        {
            _context = context;
            Courses = courses;
            Authors = authors;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
