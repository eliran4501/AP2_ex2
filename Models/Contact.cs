using System.ComponentModel.DataAnnotations;

namespace AP2_ex2.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ContactPicPath { get; set; }
        public List<Message> Messages { get; set; }
        public Contact(int id, string name, string picPath, List<Message> msgs) {
            Id = id;
            Name = name;    
            ContactPicPath = picPath;
            Messages = msgs;
        }
      
    }
}
