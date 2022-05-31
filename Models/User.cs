using System.ComponentModel.DataAnnotations;

namespace AP2_ex2.Models
{
    public class User
    {
        public User(int id, string username, string password,
            string nickname, string picturePath, List<Contact> contacts)
        {
            this.Id = id;
            this.UserName = username;
            this.Password = password;
            this.Nickname = nickname;
            this.PicturePath = picturePath;
            this.contacts = contacts;
            this.currentContact = null; 
        }
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Nickname { get; set; }

        public string PicturePath { get; set; }

        public List<Contact> contacts { get; set; }

        public Contact currentContact { get; set; } 
    }
}
