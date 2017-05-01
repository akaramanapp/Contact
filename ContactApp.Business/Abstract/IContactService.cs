using ContactApp.Entities.Concrete;
using System.Collections.Generic;

namespace ContactApp.Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();

        void Add(Contact contact);

        Contact Get(int contactId);

        void Update(Contact contact);

        void Delete(Contact contact);
    }
}
