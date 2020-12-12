using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSqlReadOnly.lab.Dal
{
    public interface ISqlQueries
    {
        Dictionary<string, string> Values { get; }
        string this [string key] { get; }

    }
}
