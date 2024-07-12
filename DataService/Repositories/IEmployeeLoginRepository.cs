using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repositories
{
    public interface IEmployeeLoginRepository
    {
        public Task<bool> Validate(string username, string password);
    }
}
