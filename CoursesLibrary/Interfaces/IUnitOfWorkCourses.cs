using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesLibrary.Interfaces
{
    public interface IUnitOfWorkCourses : IDisposable
    {
        ICourseRepository CoursesRepo { get; }
        IAuthorRepository AuthorsRepo { get; }
        int Complete();
    }
}
