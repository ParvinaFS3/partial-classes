

using System;

public interface IAccount
{
    bool PasswordChecker(string password);
    void ShowInfo();
}

public class User : IAccount
{
    private string _email;
    private string _password;

    public string Fullname { get; }
    public string Email
    {
        get { return _email; }
        set
        {
            // Burada email formatını yoxlamaq üçün əlavə yoxlama əlavə edilə bilər
            _email = value;
        }
    }
    public string Password
    {
        get { return _password; }
        set
        {
            // PasswordChecker metodu şərtləri əsasında şifrəni yoxlayır
            if (PasswordChecker(value))
            {
                _password = value;
            }
            else
            {
                Console.WriteLine("Invalid password.dogru password yazdiginiza emin olun");
               
            }
        }
    }

    public User(string fullname, string email, string password)
    {
        Fullname = fullname;
        Email = email;
        Password = password;
    }

    public bool PasswordChecker(string password)
    {
        return password.Length >= 8 &&
               ContainsUpperCase(password) &&
               ContainsLowerCase(password) &&
               ContainsDigit(password);
    }
    private bool ContainsUpperCase(string str)
    {
        foreach (char c in str)
        {
            if (char.IsUpper(c))
            {
                return true;
            }
        }
        return false;
    }
    private bool ContainsLowerCase(string str)
    {
        foreach (char c in str)
        {
            if (char.IsLower(c))
            {
                return true;
            }
        }
        return false;
    }
    private bool ContainsDigit(string str)
    {
        foreach (char c in str)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Fullname: {Fullname}");
        Console.WriteLine($"Email: {Email}");
    }
}
class Program
{
    static void Main()
    {
        // Example usage
        User user = new User("Nargiz Aslanova", "Nargiz.Aslanova@example.com", "Password123");
        user.ShowInfo();
    }
}