using BusinessLayer;
using System;
using System.Collections.Generic;
using Xunit;

namespace BusinessLayerTests
{
    public class TransactionTests
    {
        [Fact]
        public void StaticTest()
        {
            //Arrange
            var interaction = new Interaction();
            //Categories
            var category = new Category(1)
            {
                Name = "Food",
                Description = "Food purchase",
                Color = "Green",
                Icon = "Fruit"
            };

            //Users
            var user = new User(1)
            {
                LastName = "Onopriichuk",
                FirstName = "Artur",
                Email = "art@gmail.com",
            };

            //Purses
            var purse = new Purse(1, new List<User>() { user })
            {
                Name = "Family purse",
                Balance = 200,
                Description = "For family shopping",
                Currency = "USD"
            };
            user.Purses.Add(purse);
            interaction.SetCategories(new List<Category>() { category }, purse);

            //Transactions
            var transaction1 = new Transaction(1, purse.Id, user.Id)
            {
                Sum = 100,
                Currency = "USD",
                Category = category,
                Description = "Novus purchase",
                Date = new DateTime(2021, 01, 14, 15, 0, 0)
            };
            Transaction.InstanceCount += 1;
            var transaction2 = new Transaction(2, purse.Id, user.Id)
            {
                Sum = 500,
                Currency = "UAH",
                Category = category,
                Description = "Ashan purchase",
                Date = new DateTime(2021, 01, 10, 15, 0, 0)
            };
            Transaction.InstanceCount += 1;
            var transaction3 = new Transaction(3, purse.Id, user.Id)
            {
                Sum = 22,
                Currency = "EUR",
                Category = category,
                Description = "McDonalds purchase",
                Date = new DateTime(2021, 01, 20, 15, 0, 0),
                File = "Photo"
            };
            Transaction.InstanceCount += 1;
            purse.Transactions.Add(transaction1);
            purse.Transactions.Add(transaction2);
            purse.Transactions.Add(transaction3);

            var expected = 3;

            //Act
            var actual = Transaction.InstanceCount;

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
                Name = "Household",
                Description = "Household expences",
                Color = "Yelow",
                Icon = "House"
            };

            //Users
            var user1 = new User(1)
            {
                LastName = "Onopriichuk",
                FirstName = "Artur",
                Email = "art@gmail.com",
            };

            //Purses
            var purse = new Purse(1, new List<User>() { user1 })
            {
                Name = "Family purse",
                Balance = 200,
                Description = "For family shopping",
                Currency = "USD"
            };
            user1.Purses.Add(purse);
            interaction.SetCategories(new List<Category>() { category2 }, purse);

            //Transactions
            var transaction1 = new Transaction(1, purse.Id, user1.Id)
            {
                Sum = -100,
                Currency = "USD",
                Category = category1,
                Description = "Novus purchase",
                Date = new DateTime(2021, 01, 14, 15, 0, 0)
            };
            var transaction2 = new Transaction(2, purse.Id, user1.Id)
            {
                Sum = -500,
                Currency = "UAH",
                Category = category1,
                Description = "Ashan purchase",
                Date = new DateTime(2021, 01, 10, 15, 0, 0)
            };
            var transaction3 = new Transaction(3, purse.Id, user1.Id)
            {
                Sum = -22,
                Currency = "EUR",
                Category = category1,
                Description = "McDonalds purchase",
                Date = new DateTime(2021, 01, 20, 15, 0, 0),
                File = "Photo"
            };
            purse.Transactions.Add(transaction1);
            purse.Transactions.Add(transaction2);
            purse.Transactions.Add(transaction3);

            var expected = true;

            //Act
            var actual = transaction1.Validate() && transaction2.Validate() && transaction3.Validate();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateFalseTest()
        {
            //Arrange
            var interaction = new Interaction();
            //Categories
            var category = new Category(1)
            {
                Name = "Food",
                Description = "Food purchase",
                Color = "Green",
                Icon = "Fruit"
            };

            //Users
            var user = new User(1)
            {
                LastName = "Onopriichuk",
                FirstName = "Artur",
                Email = "art@gmail.com",
            };

            //Purses
            var purse = new Purse(1, new List<User>() { user })
            {
                Name = "Family purse",
                Balance = 200,
                Description = "For family shopping",
                Currency = "USD"
            };
            user.Purses.Add(purse);
            interaction.SetCategories(new List<Category>() { category }, purse);

            //Transactions
            var transaction1 = new Transaction(1, purse.Id, user.Id)
            {
                Sum = -100,
                Currency = "USD",
            };
            purse.Transactions.Add(transaction1);

            var expected = false;

            //Act
            var actual = transaction1.Validate();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateTransactionChange()
        {

            var interaction = new Interaction();
            //Categories
            var category = new Category(1)
            {
                Name = "Food",
                Description = "Food purchase",
                Color = "Green",
                Icon = "Fruit"
            };

            //Users
            var user = new User(1)
            {
                LastName = "Onopriichuk",
                FirstName = "Artur",
                Email = "art@gmail.com",
            };

            //Purses
            var purse = new Purse(1, new List<User>() { user })
            {
                Name = "Family purse",
                Balance = 200,
                Description = "For family shopping",
                Currency = "USD"
            };
            user.Purses.Add(purse);
            interaction.SetCategories(new List<Category>() { category }, purse);

            var transaction = new Transaction(1, purse.Id, user.Id)
            {
                Sum = 22,
                Currency = "EUR",
                Category = category,
                Description = "McDonalds purchase",
                Date = new DateTime(2021, 01, 20, 15, 0, 0),
                File = "Photo"
            };

            transaction.ChangeTransaction(new Transaction(2, purse.Id, user.Id)
            {
                Sum = 25,
                Currency = "EUR",
                Category = category,
                Description = "KFC purchase",
                Date = new DateTime(2021, 01, 20, 15, 0, 0),
                File = "Photo"
            });

            var expected = 25;

            //Act
            var actual = transaction.Sum;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateTransactionDelete()
        {

            var interaction = new Interaction();
            //Categories
            var category = new Category(1)
            {
                Name = "Food",
                Description = "Food purchase",
                Color = "Green",
                Icon = "Fruit"
            };

            //Users
            var user = new User(1)
            {
                LastName = "Onopriichuk",
                FirstName = "Artur",
                Email = "art@gmail.com",
            };

            //Purses
            var purse = new Purse(1, new List<User>() { user })
            {
                Name = "Family purse",
                Balance = 200,
                Description = "For family shopping",
                Currency = "USD"
            };
            user.Purses.Add(purse);
            interaction.SetCategories(new List<Category>() { category }, purse);

            var transaction = new Transaction(1, purse.Id, user.Id)
            {
                Sum = 22,
                Currency = "EUR",
                Category = category,
                Description = "McDonalds purchase",
                Date = new DateTime(2021, 01, 20, 15, 0, 0),
                File = "Photo"
            };
            purse.Transactions.Add(transaction);

            interaction.DeleteTransaction(transaction, purse);

            bool res = purse.Transactions.Contains(transaction);

            //Assert
            Assert.False(res);
        }
    }
}
