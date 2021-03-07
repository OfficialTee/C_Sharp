using BusinessLayer;
using System;
using System.Collections.Generic;
using Xunit;

namespace BusinessLayerTests
{
    public class UserTest
    {

        [Fact]
        public void StaticTest()
        {
            //Arrange
            var user1 = new User(1)
            {
                LastName = "Onopriichuk",
                FirstName = "Artur",
                Email = "art@gmail.com",
            };
            User.InstanceCount += 1;
            var user2 = new User(2)
            {
                LastName = "Kirov",
                FirstName = "Dima",
                Email = "kd@gmail.com",
            };
            User.InstanceCount += 1;

            var expected = 2;

            //Act
            var actual = User.InstanceCount;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateTrueTest()
        {
            //Arrange
            var interaction = new Interaction();
            //Categories
            var category1 = new Category(1)
            {
                Name = "Food",
                Description = "Food purchase",
                Color = "Green",
                Icon = "Fruit"
            };
            var category2 = new Category(2)
            {
                Name = "Goods",
                Description = "Goods purchase",
                Color = "Red",
                Icon = "T-shirt"
            };

            //Users
            var user1 = new User(1)
            {
                LastName = "Onopriichuk",
                FirstName = "Artur",
                Email = "art@gmail.com",
            };
            var user2 = new User(2)
            {
                LastName = "Kirov",
                FirstName = "Dima",
                Email = "kd@gmail.com",
            };

            //Purses
            var purse = new Purse(1, new List<User>() { user1, user2 })
            {
                Name = "Family purse",
                Balance = 200,
                Description = "For family shopping",
                Currency = "USD"
            };
            user1.Purses.Add(purse);
            user2.Purses.Add(purse);
            interaction.SetCategories(new List<Category>() { category1, category2 }, purse);

            //Transactions
            var transaction1 = new Transaction(1, purse.Id, user1.Id)
            {
                Sum = -100,
                Currency = "USD",
                Category = category1,
                Description = "Novus purchase",
                Date = new DateTimeOffset(2021, 01, 14, 15, 0, 0, new TimeSpan(2, 0, 0))
            };          
            var transaction2 = new Transaction(2, purse.Id, user2.Id)
            {
                Sum = -1000,
                Currency = "UAH",
                Category = category2,
                Description = "HM purchase",
                Date = new DateTimeOffset(2021, 01, 20, 15, 0, 0, new TimeSpan(2, 0, 0))
            };
            purse.Transactions.Add(transaction1);
            purse.Transactions.Add(transaction2);

            var expected = true;

            //Act
            var actual = user1.Validate();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateFalseTest()
        {
            var interaction = new Interaction();
            //Arrange
            var category = new Category(1)
            {
                Name = "Food",
                Description = "Food purchase",
                Color = "Green",
                Icon = "Fruit"
            };

            var user = new User(1)
            {
                LastName = "Onopriichuk",
                FirstName = "Artur",
                Email = "art@gmail.com",
            };

            var purse = new Purse(1, new List<User>())
            {
                Name = "Family purse",
                Balance = -200,
                Description = "For family shopping",
                Currency = "USD"
            };
            purse.UserId.Add(user);
            interaction.SetCategories(new List<Category>() { category }, purse);

            var transaction = new Transaction(1, purse.Id, user.Id)
            {
                Sum = -100,
                Currency = "USD",
                Category = category,
                Description = "Novus purchase",
                Date = new DateTimeOffset(2021, 01, 14, 15, 0, 0, new TimeSpan(2, 0, 0))
            };
            purse.Transactions.Add(transaction);

            var expected = false;

            //Act
            var actual = user.Validate();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
