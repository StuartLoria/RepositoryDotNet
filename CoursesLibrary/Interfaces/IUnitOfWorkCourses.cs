using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesLibrary.Interfaces
{
    public interface IUnitOfWorkCourses : IDisposable
    {
        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }
        int Complete();
    }
}
