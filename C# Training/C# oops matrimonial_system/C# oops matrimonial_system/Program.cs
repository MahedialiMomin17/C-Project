using System;
using System.Collections.Generic;

// User class (base class)
public class User
{
    public string Name { get; set; }


    public virtual string GetUserType()
    {
        return "User";
    }
}

// RegisteredUser class (inherits from User)
public class RegisteredUser : User
{
    public bool IsVerified { get; set; }

    public override string GetUserType()
    {
        return "Registered User";
    }
}

// PremiumUser class (inherits from RegisteredUser)
public class PremiumUser : RegisteredUser
{
    public string MembershipType { get; set; }

    public override string GetUserType()
    {
        return "Premium User";
    }
}

// ShaadiSystem class
public class ShaadiSystem
{
    private List<User> users = new List<User>();

    public void Register(User user)
    {
        users.Add(user);
        Console.WriteLine("User {0} registered successfully as a {1}", user.Name, user.GetUserType());
        Console.WriteLine(" ");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        ShaadiSystem system = new ShaadiSystem();

        // Register users
        User user1 = new User
        {
            Name = "Mahediali",

        };
        system.Register(user1);

        RegisteredUser user2 = new RegisteredUser
        {
            Name = "soham",

        };
        system.Register(user2);

        PremiumUser user3 = new PremiumUser
        {
            Name = "Amit",

        };
        system.Register(user3);
    }
}
