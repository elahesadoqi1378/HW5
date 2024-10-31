

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    public User(string username, string password, string role)
    {
        Username = username;
        Password = password;
        Role = role;
    }

    public bool ValidateUser(string password , string username)
    {
        return Password == password && Username==username;
    }

    public bool ChangePassword(string newPassword)
    {
        if (IsValidPassword(newPassword))
        {
            Password = newPassword;
            return true;
        }
        return false;
    }

    public bool IsValidPassword(string password)
    {
        bool IncludeUpperCase = false, IncludeLowerCase = false, IncludeNumber = false, IncludeSpecialChar = false;
        foreach (char c in password)
        {
            if (char.IsUpper(c)) IncludeUpperCase = true;
            else if (char.IsLower(c)) IncludeLowerCase = true;
            else if (char.IsDigit(c)) IncludeNumber = true;
            else if (!char.IsLetterOrDigit(c)) IncludeSpecialChar = true;
        }
        return IncludeUpperCase && IncludeLowerCase && IncludeNumber && IncludeSpecialChar;
    }
    public bool UserPermission(string role)
    {
        if (Role == "administrator")
            return true;

        if (Role == "normal user" && role == "change password")
            return true;

        return false;
    }

    public void DisplayUserInfo()
    {
        Console.WriteLine($"Username: {Username}, Role: {Role}");
    }
}
