using System.ComponentModel.DataAnnotations;

namespace contact.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string contact { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        


    }
}
