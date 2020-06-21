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
        public ICourseRepository CoursesRepo { get; private set; }

        public IAuthorRepository AuthorsRepo { get; private set; }

        public UnitOfWorkCourses(CoursesDBContext context, ICourseRepository courses, IAuthorRepository authors)
        {
            _context = context;
            
            CoursesRepo = courses;
            CoursesRepo.SetContext(_context);

            AuthorsRepo = authors;
            AuthorsRepo.SetContext(_context);
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
