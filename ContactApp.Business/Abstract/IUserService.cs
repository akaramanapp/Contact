using ContactApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        bool UserAuthentication(string username, string password);
    }
}
