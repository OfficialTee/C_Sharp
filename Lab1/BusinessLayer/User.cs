using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class User
    {
        private int _id; 
        private string _firstName;
        private string _lastName;
        private string _email;
        private List<Purse> _purses;

        public static int InstanceCount { get; set; }
        public int Id { get => _id; private set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public List<Purse> Purses { get => _purses; set => _purses = value; }

        public User()
        {
            _purses = new List<Purse>();
        }
        
        public User(int id) : this()
        {
            _id = id;
        }

        public bool Validate()
        {
            var result = true;

            if (String.IsNullOrWhiteSpace(LastName))
                result = false;
            if (String.IsNullOrWhiteSpace(FirstName))
                result = false;
            if (String.IsNullOrWhiteSpace(Email))
                result = false;
            if (Purses.Count == 0)
                result = false;

            return result;
        }

    }
}
