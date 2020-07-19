using System;

namespace ChatServer
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("Bad request"){}
    }
    
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("The user is not registered in the system"){}
    }
    
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base("Wrong password"){}
    }
    
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base("User already exists in the system"){}
    }
}