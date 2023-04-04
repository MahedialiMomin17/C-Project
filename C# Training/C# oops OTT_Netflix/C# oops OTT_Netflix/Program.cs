using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__oops_OTT_Netflix
{
    using System;

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string name, int age, string email, string password)
        {
            Name = name;
            Age = age;
            Email = email;
            Password = password;
        }

        public virtual void DisplayProfile()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Email: {0}", Email);
            Console.WriteLine("Password: {0}\n", Password);

        }
    }

    public class RegularUser : User
    {
        public int WatchedMovies { get; set; }

        public RegularUser(string name, int age, string email, string password, int watchedMovies)
            : base(name, age, email, password)
        {
            WatchedMovies = watchedMovies;
        }

        public override void DisplayProfile()
        {
            base.DisplayProfile();
            Console.WriteLine("Watched Movies: {0}", WatchedMovies);
        }
    }

    public class PremiumUser : User
    {
        public DateTime SubscriptionEndDate { get; set; }

        public PremiumUser(string name, int age, string email, string password, DateTime subscriptionEndDate)
            : base(name, age, email, password)
        {
            SubscriptionEndDate = subscriptionEndDate;
        }

        public override void DisplayProfile()
        {
            base.DisplayProfile();
            Console.WriteLine("Subscription End Date: {0}", SubscriptionEndDate.ToShortDateString());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Mahediali", 23, "abc@example.com", "password123");
            user1.DisplayProfile(); 

            RegularUser regularUser1 = new RegularUser("krinal", 25, "xyz@example.com", "password456", 10);
            regularUser1.DisplayProfile(); 

            DateTime subscriptionEndDate = DateTime.Now.AddDays(20);
            PremiumUser premiumUser1 = new PremiumUser("Amit", 40, "amit@example.com", "password789", subscriptionEndDate);
            premiumUser1.DisplayProfile();

        }
    }
}
