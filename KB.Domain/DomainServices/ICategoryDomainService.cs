using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KB.Domain.DomainServices
{
    public interface ICategoryDomainService
    {
        Category Insert(Category category);
        Category Update(Category category);
        int Delete(Category category);
        int Delete(int id);
        IQueryable<Category> GetAll();
    }
}
