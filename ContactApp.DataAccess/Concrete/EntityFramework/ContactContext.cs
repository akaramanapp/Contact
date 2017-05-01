using ContactApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.DataAccess.Concrete.EntityFramework
{
    public class ContactContext : DbContext
    {
        public ContactContext()
        : base("ContactApp.DataAccess.Concrete.EntityFramework.ContactContext")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
