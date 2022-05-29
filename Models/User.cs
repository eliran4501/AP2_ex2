using System.ComponentModel.DataAnnotations;

namespace AP2_ex2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Contact> contacts { get; set; }
    }
}
