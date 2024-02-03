

using System.Numerics;
using System.IO;
namespace PasswordClass;
public class PasswordGenerator
{
    private string currentDirectory = Directory.GetCurrentDirectory();
    string filter = ".txt";


    private int[] passwordCharacters = 
    {33,34,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51,52,53,54,55,56,57,58,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,85,87,88,89,90,91,92,93,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122

    };
    
    private Random _random;
    DateTime _time;
    long ticks = DateTime.Now.Ticks;

    public void Start()
    {
        currentDirectory = currentDirectory.Substring(0, currentDirectory.Length - 9);
        currentDirectory += @"Passwords\";
        Directory.CreateDirectory(currentDirectory);
        Console.WriteLine(currentDirectory);

        _random = new Random((int)ticks);
        int passwordLength = 0;
        Console.WriteLine("How long?");
        string length = Console.ReadLine();
        Console.WriteLine("Name of Password");
        string name = Console.ReadLine();

        passwordLength = Int32.Parse(length);
        
        string _password = GeneratePassword(passwordLength);
        SavePassword(_password, name, currentDirectory);
    }
        
    private string GeneratePassword(int _passwordLength)
    {
        string _password = "";
        for(int i = 0; i < _passwordLength; i++)
        {
            
            _password += (char)passwordCharacters[_random.Next(0,passwordCharacters.Length)];
        }
        return _password;
    }

    public void SavePassword(string _password, string _fileName, string _directory)
    {
        Console.WriteLine(_directory + _fileName + filter);
        File.WriteAllText(_directory + _fileName + filter, _password);
    }
}
