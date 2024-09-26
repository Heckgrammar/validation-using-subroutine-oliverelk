using System.Text.RegularExpressions;

namespace ValidationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                {
                    string firstName, lastName, username, password, emailAddress;
                    int age;

                    // Get valid first name

                    
                        Console.Write("Enter first name: ");
                        firstName = Console.ReadLine();
                        while (ValidName(firstName));

                    // Get valid last name
  
                        Console.Write("Enter last name: ");
                        lastName = Console.ReadLine();
                        while (ValidName(lastName));

                    // Get valid age
                    
                        Console.Write("Enter age: ");
                        if (!int.TryParse(Console.ReadLine(), out age) || ValidAge(age))
                        {
                            Console.WriteLine("Invalid age. Age must be between 11 and 18.");
                        }
                        while (ValidAge(age));

                    // Get valid password
                    
                    
                        Console.Write("Enter Password: ");
                        password = Console.ReadLine();
                        while (ValidPassword(password));

                    // Get valid email address
                    do
                    {
                        Console.Write("Enter email address: ");
                        emailAddress = Console.ReadLine();
                    } while (ValidEmail(emailAddress));

                    // Generate username
                    username = CreateUserName(firstName, lastName, age);
                    Console.WriteLine("Username is " ,username, ", you have successfully registered. Please remember your password.");
                }

                static bool ValidName(string name)
                {
                    // Name must be at least two characters and contain only letters
                    return name.Length >= 2 && name.All(char.IsLetter);
                }

                static bool ValidAge(int age)
                {
                    // Age must be between 11 and 18 inclusive
                    return age >= 11 && age <= 18;
                }

                static bool ValidPassword(string password)
                {
                    // Password must be at least 8 characters in length
                    if (password.Length < 8)
                    {
                        Console.WriteLine("Password must be at least 8 characters long.");
                        return false;
                    }

                    // Check password contains a mix of lowercase, uppercase, and non-letter characters
                    if (password.Any(char.IsLower) || password.Any(char.IsUpper) || password.Any(ch => char.IsLetterOrDigit(ch)))
                    {
                        Console.WriteLine("Password must contain at least one uppercase letter, one lowercase letter, and one special character.");
                        return false;
                    }

                    // Check password contains no runs of more than 2 consecutive or repeating letters or numbers
                    for (int i = 0; i < password.Length - 2; i++)
                    {
                        if ((password[i] == password[i + 1] && password[i + 1] == password[i + 2]) || // Repeating characters
                            (password[i + 1] == password[i] + 1 && password[i + 2] == password[i] + 2)) // Consecutive characters
                        {
                            Console.WriteLine("Password must not contain more than 2 consecutive or repeating characters.");
                            return false;
                        }
                    }

                    return true;
                }

                static bool ValidEmail(string email)
                {
                    // A valid email address has at least 2 characters followed by an @ symbol, 
                    // at least 2 characters followed by a '.', and at least 2 characters after the '.'.
                    // Email should also contain only one '@' and may have any number of '.' but no other special characters.

                    // Check email format with Regex
                    Regex emailPattern = new Regex(@"^[a-zA-Z0-9]{2,}@[a-zA-Z0-9]{2,}\.[a-zA-Z0-9]{2,}$");
                    if (!emailPattern.IsMatch(email))
                    {
                        Console.WriteLine("Invalid email address.");
                        return false;
                    }

                    return true;
                }

                static string CreateUserName(string firstName, string lastName, int age)
                {
                    // Username is made up from:
                    // First two characters of first name, last two characters of last name, and age
                    string firstPart = firstName.Length >= 2 ? firstName.Substring(0, 2) : firstName;
                    string lastPart = lastName.Length >= 2 ? lastName.Substring(lastName.Length - 2) : lastName;
                    return $"{firstPart}{lastPart}{age}";
                    Console.ReadLine();
                }
            }
        }
}   }
