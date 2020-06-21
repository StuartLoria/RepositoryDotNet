using CoursesLibrary.Interfaces;
using CoursesLibrary.Models;
using RepositoryEF.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesLibrary.Implementations
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public CoursesDBContext CoursesContext 
        {
            get
            {
                //Since we know the type of the context via the constructor we can do the following
                return Context as CoursesDBContext;
            }
        }

        public AuthorRepository(CoursesDBContext context)
            : base(context)
        {
        }
    }
}
