using ContactApp.Core.DataAccess;
using ContactApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
    }
}
