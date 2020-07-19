using Network.Client;

namespace ChatServer.Models
{
    public class User
    {
        public Client Client { get; }
        public string Name { get; set; }
        public int Id { get; set; }

        public User(Client client)
        {
            Client = client;
        }

        public override bool Equals(object obj)
        {
            User other = obj as User;
            return other?.Id == Id && other.Name == Name;
        }

        protected bool Equals(User other)
        {
            return Name == other.Name && Id == other.Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ Id;
            }
        }

        public override string ToString()
        {
            return $"{Name} #{Id}";
        }
    }
}