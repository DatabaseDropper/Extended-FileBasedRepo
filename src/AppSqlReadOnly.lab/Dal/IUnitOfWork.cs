using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSqlReadOnly.lab.Dal
{
    public interface IUnitOfWork
    {
        IEmployeesRepository EmployeesRepository { get; }
    }
}
