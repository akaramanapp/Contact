using ContactApp.Core.DataAccess.EntityFramework;
using ContactApp.DataAccess.Abstract;
using ContactApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.DataAccess.Concrete.EntityFramework
{
    public class EfContactDal: EfEntityRepositoryBase<Contact, ContactContext>, IContactDal
    {

    }
}
