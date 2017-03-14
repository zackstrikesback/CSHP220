using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            Console.WriteLine("Current users");
            Display(users);

            Console.WriteLine("Passwords that are hello");
            var hello = users.Where(user => user.Password.Equals("hello"));
            foreach(Models.User login in hello)
            {
                Console.WriteLine("Password = " + login.Password);
            }
            Console.WriteLine();

            Console.WriteLine("Remove users that passwords are lowercase versions of their name");
            users.RemoveAll(user => user.Password.Equals(user.Name.ToLower()));
            Display(users);

            Console.WriteLine("Remove first user that has the password hello");
            users.Remove(users.FirstOrDefault(user => user.Password == "hello"));
            Display(users);
        }

        public static void Display(List<Models.User> u)
        {
            foreach (Models.User login in u)
            {
                Console.WriteLine("Name = " + login.Name + ", Password = " + login.Password);
            }
            Console.WriteLine();
        }
    }
}
