using ContactApp.Core.DataAccess;
using ContactApp.Entities.Concrete;


namespace ContactApp.DataAccess.Abstract
{
    public interface IContactDal: IEntityRepository<Contact>
    {
    }
}
