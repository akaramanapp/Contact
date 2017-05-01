using System;
using System.Collections.Generic;
using ContactApp.Business.Abstract;
using ContactApp.Entities.Concrete;
using ContactApp.DataAccess.Abstract;

namespace ContactApp.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetList();
        }

        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public Contact Get(int contactId)
        {
            return _contactDal.Get(x => x.ContactId == contactId);
        }

        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public void Delete(Contact contact)
        {
            _contactDal.Delete(contact);
        }
    }
}
