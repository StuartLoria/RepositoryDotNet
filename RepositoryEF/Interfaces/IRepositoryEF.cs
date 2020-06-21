using Microsoft.EntityFrameworkCore;
using RepositoryLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryEF.Interfaces
{
    public interface IRepositoryEF<TEntity> : IRepository<TEntity> where TEntity : class
    {
        bool SetContext(DbContext context);
    }
}
