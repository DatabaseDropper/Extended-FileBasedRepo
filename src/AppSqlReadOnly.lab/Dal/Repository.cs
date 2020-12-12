using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;

namespace AppSqlReadOnly.lab.Dal
{
    public abstract class Repository
    {
        private IDbConnection _dbConnection;
        private ISqlQueries _sqlQueries;
        private string _name;

        protected IDbConnection Connection => _dbConnection;
        public Repository(IDbConnection dbConnection, ISqlQueries sqlQueries, string name)
        {
            _dbConnection = dbConnection;
            _sqlQueries = sqlQueries;
            _name = name;

            if(_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
        }

        public string GetSqlQuery([CallerMemberName] string methodName = "")
        {
            string key = $"{_name}.{methodName}"
                            .Replace("Repository", string.Empty)
                            .Replace("Async", string.Empty);
            return _sqlQueries[key];
        }
    }
}
