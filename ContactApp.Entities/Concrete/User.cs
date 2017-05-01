using ContactApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Entities.Concrete
{
    public class User: IEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
