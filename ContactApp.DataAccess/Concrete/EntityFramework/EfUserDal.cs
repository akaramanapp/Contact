using ContactApp.Core.DataAccess.EntityFramework;
using ContactApp.DataAccess.Abstract;
using ContactApp.Entities.Concrete;


namespace ContactApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ContactContext>, IUserDal
    {
    }
}
