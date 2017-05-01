using ContactApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ContactApp.Entities.Concrete
{
    public class Contact: IEntity
    {
        public int ContactId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
