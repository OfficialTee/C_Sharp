using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Category
    {
        private int _id;
        private string _name;
        private string _description;
        private string _color;
        private string _icon;

        public static int InstanceCount { get; set; }
        public int Id { get => _id; private set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Color { get => _color; set => _color = value; }
        public string Icon { get => _icon; set => _icon = value; }

        public Category()
        {

        }

        public Category(int id)
        {
            _id = id;
        }

        public bool Validate()
        {
            var result = true;

            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (String.IsNullOrWhiteSpace(Description))
                result = false;
            if (String.IsNullOrWhiteSpace(Color))
                result = false;
            if (String.IsNullOrWhiteSpace(Icon))
                result = false;

            return result;
        }
    }
}
