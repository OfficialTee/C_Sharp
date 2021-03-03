using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Purse
    {
        private int _id;
        private string _name;
        private int _balance;
        private string _description;
        private string _currency;
        private List<User> _userId;
        private List<Category> _categories;
        private List<Transaction> _transactions;

        public static int InstanceCount { get; set; }
        public int Id { get => _id; private set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Balance { get => _balance; set => _balance = value; }
        public string Description { get => _description; set => _description = value; }
        public string Currency { get => _currency; set => _currency = value; }
        public List<User> UserId { get => _userId; set => _userId = value; }
        public List<Category> Categories { get => _categories; set => _categories = value; }
        public List<Transaction> Transactions { get => _transactions; set => _transactions = value; }

        public Purse(List<User> userId)
        {
            _userId = userId;
            _categories = new List<Category>();
            _transactions = new List<Transaction>();
        }

        public Purse(int id, List<User> userId) : this(userId)
        {
            _id = id;
        }

        public bool Validate()
        {
            var result = true;

            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (Balance < 0)
                result = false;
            if (String.IsNullOrWhiteSpace(Description))
                result = false;
            if (String.IsNullOrWhiteSpace(Currency))
                result = false;
            if (UserId.Count == 0)
                result = false;
            if (Categories.Count == 0)
                result = false;
            if (Transactions.Count == 0)
                result = false;

            return result;
        }
    }
}
