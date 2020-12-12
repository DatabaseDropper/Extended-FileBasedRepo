using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppSqlReadOnly.lab.Dal
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IConfiguration _configuration;
        private ISqlQueries _sqlQueries;
        private SqlConnection _connection;
        private bool _disposed;

        public IEmployeesRepository EmployeesRepository => throw new NotImplementedException();

        public UnitOfWork(IConfiguration configuration, ISqlQueries sqlQueries)
        {
            _configuration = configuration;
            _sqlQueries = sqlQueries;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                //connection string do app settings
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    if(_configuration!=null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        _connection = null;
                    }
                    _disposed = true;
                }
            }
        }

    }
}
