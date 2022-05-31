using AP2_ex2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace AP2_ex2.Controllers
{
    public class UserController : Controller
    {
        private static List<User> usersList = new List<User>();
        private static User currentUser;

        public UserController()
        {
            if (usersList.Count == 0)
            {
                List<Contact> contacts1 = new List<Contact>();
                List<Message> messages1 = new List<Message>();
                messages1.Add(new Message("hello "));
                messages1.Add(new Message("World!"));
                List<Contact> contacts2 = new List<Contact>();
                List<Message> messages2 = new List<Message>();
                messages2.Add(new Message("hi "));
                messages2.Add(new Message("?!"));
                List<Contact> contacts3 = new List<Contact>();
                List<Message> messages3 = new List<Message>();
                messages3.Add(new Message("what's up?"));
                contacts1.Add(new Contact(1, "eliran", "pic2.jpg", messages1));
                contacts1.Add(new Contact(2, "ben", "pic3.jpg", messages2));
                contacts1.Add(new Contact(3, "yon", "pic2.jpg", messages3));
                usersList.Add(new User(1, "benny", "1234asdf", "BB", "pic2.jpg", contacts1));
                usersList.Add(new User(2, "ben", "Hjkl1234", "CC", "pic3.jpg", contacts2));
                usersList.Add(new User(3, "eliran", "Zxcv1234", "DD", "pic2.jpg", contacts3));
                usersList.Add(new User(4, "eli", "Zxcv1234", "EE", "pic2.jpg", contacts3));
            }
        }

        public bool Validation(string username, string password, string password2,
        string nickname)
        {
            if (username == null || password == null || password2 == null || nickname == null)
            {
                return false;
            }
            if (username.Length < 2 || nickname.Length < 2)
            {
                //console.log("names input wrong");
                return false;
            }
            if (password != password2)
            {
                //console.log("Passwords don't match");
                return false;
            }
            if (password.Length < 8 || password.Length > 14)
            {
                //console.log("Passwords don't meet the requirements");
                return false;
            }
            if (!Regex.IsMatch(password, @"[a-zA-Z]") && Regex.IsMatch(password, @"\d"))
            {
                return false;
            }
            /*return /^[A-Za-z0-9]*$/.test(pass1);*/
            User user1 = usersList.Find(o => o.UserName == username);
            if (user1 != null)
            {
                //console.log("This username is already taken");
                return false;
            }
            return true;
        }
        public IActionResult Index()
        {
            return View("login");
        }
        public IActionResult ChatScreen()
        {
            return View(currentUser);
        }
        [HttpPost]
        public IActionResult ChatScreen(String username, String password)
        {
            if (username == null || password == null)
            {
                return View("login");
            }
            foreach (var user in usersList)
            {
                if (user.UserName == username && user.Password == password)
                {
                    currentUser = user;
                    return Redirect(nameof(ChatScreen));
                }
            }
            return View("login");

        }
        public IActionResult Create()
        {
            return View("register");
        }

        public IActionResult UpdateCurrentContact()
        {
            currentUser.currentContact = null;
            return View("register");
        }

        public IActionResult AddMessage(string msgString)
        {
            if (!string.IsNullOrEmpty(msgString) && currentUser.currentContact != null)
            {
                currentUser.currentContact.Messages.Add(new Message(msgString));
                User otherUser = usersList.Find(o => o.UserName == currentUser.currentContact.Name);
                otherUser.contacts.Find(o => o.Name == currentUser.UserName).Messages.Add(new Message(msgString));
            }
            return Redirect(nameof(ChatScreen));
        }

        [HttpPost]
        public IActionResult AddContact(string contactName)
        {
            foreach (var user in usersList)
            {
                if (user.UserName == contactName && currentUser.contacts != null && currentUser.contacts.Find(o => o.Name == contactName) == null
                    && currentUser.UserName != contactName)
                {
                    Contact addedContact = new Contact(user.Id, user.UserName, user.PicturePath, new List<Message>());
                    currentUser.contacts.Add(addedContact);
                    user.contacts.Add(new Contact(currentUser.Id, currentUser.UserName, currentUser.PicturePath, new List<Message>()));
                    currentUser.currentContact = addedContact;  
                    break;
                }
            }
            return Redirect(nameof(ChatScreen));
        }

        [HttpPost]
        public IActionResult Create(string username, string password, string password2,
            string nickname, string picturePath)
        {
            if (!Validation(username, password, password2, nickname))
            {
                return View("register");
            }
            var id = 1;
            if (usersList.Count != 0)
            {
                id = usersList.Max(o => o.Id) + 1;
            }
            User user = new User(id, username, password, nickname, "pic2.jpg", new List<Contact>());
            usersList.Add(user);
            currentUser = user;
            return Redirect(nameof(ChatScreen));
        }
    }

}

