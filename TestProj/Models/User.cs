using SQLite;

namespace TestProj.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public bool CheckInformation()
        {
            if (!this.Username.Equals("") && !this.Username.Equals(""))
                return true;
            else
                return false;
        }
    }
}
