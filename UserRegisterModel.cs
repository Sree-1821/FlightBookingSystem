namespace Web_API.Controllers
{
    public class UserRegisterModel
    {
        internal int CustomerID;
        internal string Firstname;
        internal string Lastname;
        internal int Age;
        internal string Gender;

        public string Password { get; internal set; }
        public string Username { get; internal set; }
        public object MobileNumber { get; internal set; }
        public string EmailID { get; internal set; }
    }
}