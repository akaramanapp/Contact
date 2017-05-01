using ContactApp.Core.Entities;

namespace ContactApp.Entities.Concrete
{
    public class Contact: IEntity
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
