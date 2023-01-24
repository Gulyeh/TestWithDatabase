namespace Task5_0.Models
{
    public class ConnectionModel
    {
        public ConnectionModel()
        {
            Server = string.Empty;
            Database = string.Empty;
            User = string.Empty;
            Password = string.Empty;
        }

        public string Server { get; set; }
        public string Database { get; set; }
        public string User  { get; set; }
        public string Password { get; set; }
    }
}