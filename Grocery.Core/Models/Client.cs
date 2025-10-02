
namespace Grocery.Core.Models
{
    public partial class Client : Model
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Role Metb { get; set; }
        public Client(int id, string name, string emailAddress, string password) : base(id, name)
        {
            EmailAddress = emailAddress;
            Password = password;
            Metb = Role.None;
        }
        public Client(int id, string name, string emailAddress, string password, Role role) : this(id, name, emailAddress, password)
        {
            Metb = role;
        }
    }
}
