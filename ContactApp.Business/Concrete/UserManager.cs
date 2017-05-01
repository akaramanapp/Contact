using ContactApp.Business.Abstract;
using ContactApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Entities.Concrete;
using ContactApp.Business.Infrastructure;

namespace ContactApp.Business.Concrete
{
    public class UserManager: IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            user.Password = EncryptData.Encrypt(user.Password);
            _userDal.Add(user);
        }

        public bool UserAuthentication(string username, string password)
        {
            var pass = EncryptData.Encrypt(password);
            var user = _userDal.Get(x => x.Username == username && x.Password == pass);
            return user != null ? true : false;
        }
    }
}
