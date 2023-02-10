using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_To_Do_List.Repositories
{
    public class ConnectionString : IConnectionString
    {
        private readonly IConfiguration _config;
        public ConnectionString(IConfiguration config){
            _config = config;
        }
        public string? GetString(){
            return _config["ConnectionString:Sqlite"];
        }
    }
}