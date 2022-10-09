using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// I tried to create like you showed in the lecture,
// but it didn't work, so I had to try something else.

// Custom name to call it from a main file
namespace UserClass;
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }

    // Constructor of a class
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
