using System;

public class Program
{
    private static User[] users = new User[100];
    private static int userCount = 0;

    public static void Main(string[] args)
    {
        InitializeUsers();
        Console.WriteLine("Welcome to the Authentication System!");

        while (true)
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            User EnteredUser = Authenticate(username, password);
            if (EnteredUser != null)
            {
                Console.WriteLine("Login Successful!");
                ShowUserMenu(EnteredUser);
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }
        }
    }

    private static void InitializeUsers()
    {
        users[0] = new User("admin", "admin@1234", "administrator");
        users[1] = new User("ela", "ela@1234", "normal user");
        users[2] = new User("amir", "amir@1234", "normal user");
        users[3] = new User("leila", "leila@1234", "normal user");
        users[4] = new User("sara", "sara@1234", "normal user");
        userCount = 5;
    }

    private static User Authenticate(string username, string password)
    {
        foreach (User user in users)
        {
            if (user != null && user.ValidateUser(password,username))
            {
                return user;
            }
        }
        return null;
    }

    private static void ShowUserMenu(User entereduser)
    {
        while (true)
        {
            Console.WriteLine($"Hello, {entereduser.Username} ({entereduser.Role})!");
            Console.WriteLine("1. Change Password");
            Console.WriteLine("2. View User Information");
            Console.WriteLine("3. Add User (Admin only)");
            Console.WriteLine("4. List Users (Admin only)");
            Console.WriteLine("5. Logout");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter new password: ");
                string newPassword = Console.ReadLine();
                if (entereduser.ChangePassword(newPassword))
                {
                    Console.WriteLine("Password changed successfully.");
                }
                else
                {
                    Console.WriteLine("Password change failed.");
                }
            }
            else if (choice == "2")
            {
                entereduser.DisplayUserInfo();
            }
            else if (choice == "3" && entereduser.Role == "administrator")
            {
                AddUser();
            }
            else if (choice == "4" && entereduser.Role == "administrator")
            {
                ListUsers();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Logging out..");
                break;
            }
            else
            {
                Console.WriteLine("Invalid selection, please try again.");
            }
        }
    }

    private static void AddUser()
    {
        if (userCount == users.Length)
        {
            Console.WriteLine("User limit reached. Cannot add more users.");
            return;
        }

        Console.Write("Enter new username: ");
        string username = Console.ReadLine();
        Console.Write("Enter new password: ");
        string password = Console.ReadLine();
        string role = "normal user"; // Default role

        users[userCount] = new User(username, password, role);
        userCount++;
        Console.WriteLine("User added successfully.\n");
    }

    private static void ListUsers()
    {
        Console.WriteLine("List of users:");
        foreach (User user in users)
        {
            if (user != null)
            {
                user.DisplayUserInfo();
            }
        }
        Console.WriteLine();
    }
}
