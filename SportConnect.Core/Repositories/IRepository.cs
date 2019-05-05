using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportConnect.Core.Repositories
{
    //marker interface
    public interface IRepository <T>
    {      
        IQueryable<T> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
