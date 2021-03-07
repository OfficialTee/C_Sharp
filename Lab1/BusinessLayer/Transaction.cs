using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Transaction
    {
        private int _id;
        private int _sum;
        private string _currency;
        private Category _category;
        private string _description;
        private DateTimeOffset _date;
        private string? _file;
        private int _purseId;
        private int _userId;

        public static int InstanceCount { get; set; }
        public int Id { get => _id; private set => _id = value; }
        public int Sum { get => _sum; set => _sum = value; }
        public string Currency { get => _currency; set => _currency = value; }
        public Category Category { get => _category; set => _category = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTimeOffset Date { get => _date; set => _date = value; }
        public string File { get => _file; set => _file = value; }
        public int PurseId { get => _purseId; set => _purseId = value; }
        public int UserId { get => _userId; set => _userId = value; }

        public void ChangeTransaction(Transaction transaction)
        {
            _id = transaction._id;
            _sum = transaction._sum;
            _currency = transaction._currency;
            _category = transaction._category;
            _description = transaction._description;
            _date = transaction._date;
            _purseId = transaction._purseId;
            _userId = transaction._userId;
            if (transaction._file != null)
                _file = transaction._file;
        }

        public Transaction(int purseId, int userId)
        {          
            _purseId = purseId;
            _userId = userId;
            _category = new Category();
        }

        public Transaction(int id, int purseId, int userId) : this(purseId, userId)
        {
            _id = id;
        }

        public bool Validate()
        {
            var result = true;

            if (Sum == 0)
                result = false;
            if (String.IsNullOrWhiteSpace(Currency))
                result = false;
            if (Category == null)
                result = false;
            if (String.IsNullOrWhiteSpace(Description))
                result = false;
            if (Date == null)
                result = false;
            if (PurseId < 0)
                result = false;
            if (UserId < 0)
                result = false;

            return result;
        }
    }
}
