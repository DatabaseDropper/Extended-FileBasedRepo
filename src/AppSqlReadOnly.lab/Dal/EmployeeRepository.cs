using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppSqlReadOnly.lab.Dal
{
    public class EmployeeRepository : Repository, IEmployeesRepository
    {
        public EmployeeRepository(IDbConnection connectnion, ISqlQueries sqlQueries) : base (connectnion, sqlQueries, nameof(EmployeeRepository))
        {
        }

        public async Task<IEnumerable<EmployeeDao>> GetAllAsync()
        {
            return await Connection.QueryAsync<EmployeeDao>(GetSqlQuery());
        }

        public async Task<EmployeeDao> GetAsync(int id)
        {
            return await Connection.QueryFirstOrDefaultAsync<EmployeeDao>(GetSqlQuery(), new { Param = id });
        }

        public async Task<IEnumerable<EmployeeDao>> GetByCityAsync(string city)
        {
            return await Connection.QueryAsync<EmployeeDao>(GetSqlQuery(), new { Param = city });
        }

        // Tests

        public async Task<EmployeeDao> Test_GetAsync(int id)
        {
            // kompromis korzystający tylko z jednego pliku, ale uzależniony od kodu SQL w kodzie
            // do podstawiania predykatu.

            var query = string.Format(GetWhereSQL(), $"WHERE {nameof(EmployeeDao.Id)} = @Param");
            return await Connection.QueryFirstOrDefaultAsync<EmployeeDao>(query, new { Param = id });
        }

        public async Task<IEnumerable<EmployeeDao>> Test_GetByCityAsync(string city)
        {
            var query = string.Format(GetWhereSQL(), $"WHERE {nameof(EmployeeDao.City)} = @Param");
            return await Connection.QueryAsync<EmployeeDao>(query, new { Param = city });
        }

        private string GetWhereSQL()
        {
            return GetSqlQuery();
        }
    }
}
