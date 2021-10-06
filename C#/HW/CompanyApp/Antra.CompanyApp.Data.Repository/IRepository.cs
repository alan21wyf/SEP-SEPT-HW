using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CompanyApp.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        int Insert(T item);
        int Update(T item);
        int Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
