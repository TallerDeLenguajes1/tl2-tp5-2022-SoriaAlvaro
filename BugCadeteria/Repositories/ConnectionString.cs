using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class ConnectionString : IConnectionString
    {
        private readonly IConfiguration _config;
        public ConnectionString(IConfiguration config){
            _config = config;
        }
        public string? GetString(){
            return _config["ConnectionString:Default"];
        }
    }
}