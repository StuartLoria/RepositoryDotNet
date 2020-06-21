using CoursesLibrary.Models;
using RepositoryEF.Interfaces;
using RepositoryLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesLibrary.Interfaces
{
    public interface IAuthorRepository : IRepositoryEF<Author>
    {
    }
}
