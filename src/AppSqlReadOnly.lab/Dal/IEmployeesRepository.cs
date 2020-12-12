using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSqlReadOnly.lab.Dal
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<EmployeeDao>> GetAllAsync();
        Task<IEnumerable<EmployeeDao>> GetByCityAsync(string city);
        Task<EmployeeDao> GetAsync(int id);
    }
}
