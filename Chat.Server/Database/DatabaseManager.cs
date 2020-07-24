using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Chat.Server.Models;

namespace Chat.Server.Database
{
    public class DatabaseManager : IDatabase
    {
        private SQLiteConnection Connection { get; set; }

        public DatabaseManager(SQLiteConnection connection)
        {
            Connection = connection;
        }

        public DatabaseManager(string connection)
        {
            Connection = new SQLiteConnection(connection);
        }

        public bool UserExists(int id)
        {
            try
            {
                const string query = "Select Count(*) from Users where Id=@id";
                Connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, Connection);
                command.Parameters.AddWithValue("@id", id);
                int result = int.Parse(command.ExecuteScalar().ToString());
                Connection.Close();
                return result == 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Register(string name, string password)
        {
            try
            {
                const string query = "Insert Into Users (Name, Password) VALUES(@name, @password)";
                Connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, Connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@password", password);
                command.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetHashedPassword(int id)
        {
            try
            {
                const string query = "Select Password from Users where Id=@id";
                Connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, Connection);
                command.Parameters.AddWithValue("@id", id);
                string result = command.ExecuteScalar().ToString();
                Connection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public string GetName(int id)
        {
            try
            {
                const string query = "Select Name from Users where Id=@id";
                Connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, Connection);
                command.Parameters.AddWithValue("@id", id);
                string result = command.ExecuteScalar().ToString();
                Connection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public int GetId(string name)
        {
            try
            {
                const string query = "Select Id from Users where Name=@name";
                Connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, Connection);
                command.Parameters.AddWithValue("@name", name);
                int result = int.Parse(command.ExecuteScalar().ToString());
                Connection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }
    }
}