using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserClass;

public class User
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }

        public User (string firstName, string lastName, string type)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }
 }

