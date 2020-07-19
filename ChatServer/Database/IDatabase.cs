namespace ChatServer.Database
{
    public interface IDatabase
    {
        bool UserExists(int id);
        bool Register(string name, string password);
        string GetHashedPassword(int id);
        string GetName(int id);
        int GetId(string name);
    }
}