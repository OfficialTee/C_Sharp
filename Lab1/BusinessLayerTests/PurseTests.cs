using BusinessLayer;
using System;
using System.Collections.Generic;
using Xunit;

namespace BusinessLayerTests
{
    public class PurseTests
    {
        [Fact]
        public void StaticTest()
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
            var category3 = new Category(3)
            {
                Name = "Car",
                Description = "Car maintainance",
                Color = "Blue",
                Icon = "Car"
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
                FirstName = "Max",
                Email = "km@gmail.com",
            };

            //Purses
            var purse1 = new Purse(1, new List<User>() { user1 })
            {
                Name = "Personal purse",
                Balance = 200,
                Description = "For personal shopping",
                Currency = "USD"
            };
            user1.Purses.Add(purse1);

            interaction.SetCategories(new List<Category>() { category1, category2, category3 }, purse1);
            Purse.InstanceCount += 1;

            var purse2 = new Purse(2, new List<User>() { user1, user2 })
            {
                Name = "Family purse",
                Balance = 2000,
                Description = "For family shopping",
                Currency = "USD"
            };
            user1.Purses.Add(purse1);

            interaction.SetCategories(new List<Category>() { category1, category2 }, purse2);
            Purse.InstanceCount += 1;

            var expected = 2;

            //Act
            var actual = Purse.InstanceCount;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateSetCategories()
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
            var category3 = new Category(3)
            {
                Name = "Car",
                Description = "Car maintainance",
                Color = "Blue",
                Icon = "Car"
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

            interaction.SetCategories(new List<Category>() { category1, category2, category3 }, purse);

            var expected = category1.Name.ToString() + " " +
                           category2.Name.ToString() + " " +
                           category3.Name.ToString();

            //Act
            var actual = purse.Categories[0].Name.ToString() + " " +
                         purse.Categories[1].Name.ToString() + " " +
                         purse.Categories[2].Name.ToString();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateCheckBalance()
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

            var expected = 200;

            //Act
            var actual = interaction.CheckBalance(purse);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateGetIncome()
        {
            //Arrange
            var interaction = new Interaction();
            //Categories
            var category = new Category(1)
            {
                Name = "Rent",
                Description = "Flat rent",
                Color = "Black",
                Icon = "House"
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
                Name = "Personal purse",
                Balance = 20000,
                Description = "For personal icome",
                Currency = "USD"
            };
            user.Purses.Add(purse);

            interaction.SetCategories(new List<Category>() { category }, purse);

            var transaction1 = new Transaction(1, purse.Id, user.Id)
            {
                Sum = 100,
                Currency = "USD",
                Category = category,
                Description = "March",
                Date = new DateTime(2021, 03, 14, 15, 0, 0)
            };
            var transaction2 = new Transaction(2, purse.Id, user.Id)
            {
                Sum = 5000,
                Currency = "UAH",
                Category = category,
                Description = "March",
                Date = new DateTime(2021, 03, 10, 15, 0, 0)
            };
            var transaction3 = new Transaction(3, purse.Id, user.Id)
            {
                Sum = 222,
                Currency = "EUR",
                Category = category,
                Description = "April",
                Date = new DateTime(2021, 04, 20, 15, 0, 0),
                File = "Photo"
            };

            purse.Transactions.Add(transaction1);
            purse.Transactions.Add(transaction2);
            purse.Transactions.Add(transaction3);
          
            var expected = "100 in USD" + " " + "5000 in UAH ";

            //Act
            var actual = interaction.GetIncomeLastMonth(purse.Transactions);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateGetExpenses()
        {
            //Arrange
            var interaction = new Interaction();
            //Categories
            var category = new Category(1)
            {
                Name = "Household",
                Description = "Flat expenses",
                Color = "Black",
                Icon = "House"
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
                Name = "Personal purse",
                Balance = 2000,
                Description = "For personal expenses",
                Currency = "USD"
            };
            user.Purses.Add(purse);

            interaction.SetCategories(new List<Category>() { category }, purse);

            var transaction1 = new Transaction(1, purse.Id, user.Id)
            {
                Sum = -40,
                Currency = "USD",
                Category = category,
                Description = "March",
                Date = new DateTime(2021, 03, 14, 15, 0, 0)
            };
            var transaction2 = new Transaction(2, purse.Id, user.Id)
            {
                Sum = -500,
                Currency = "UAH",
                Category = category,
                Description = "August",
                Date = new DateTime(2021, 07, 10, 15, 0, 0)
            };
            var transaction3 = new Transaction(3, purse.Id, user.Id)
            {
                Sum = -42,
                Currency = "EUR",
                Category = category,
                Description = "December",
                Date = new DateTime(2021, 12, 20, 15, 0, 0),
                File = "Photo"
            };

            purse.Transactions.Add(transaction1);
            purse.Transactions.Add(transaction2);
            purse.Transactions.Add(transaction3);

            var expected = "-40 in USD ";

            //Act
            var actual = interaction.GetExpensesLastMonth(purse.Transactions);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateGetLastTransactions()
        {
            //Arrange
            var interaction = new Interaction();
            //Categories
            var category = new Category(1)
            {
                Name = "Household",
                Description = "Flat expenses",
                Color = "Black",
                Icon = "House"
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
                Name = "Personal purse",
                Balance = 2000,
                Description = "For personal expenses",
                Currency = "USD"
            };
            user.Purses.Add(purse);

            interaction.SetCategories(new List<Category>() { category }, purse);

            var transaction1 = new Transaction(1, purse.Id, user.Id)
            {
                Sum = -400,
                Currency = "UAH",
                Category = category,
                Description = "March",
                Date = new DateTime(2021, 03, 14, 15, 0, 0)
            };
            var transaction2 = new Transaction(2, purse.Id, user.Id)
            {
                Sum = -500,
                Currency = "UAH",
                Category = category,
                Description = "August",
                Date = new DateTime(2021, 07, 10, 15, 0, 0)
            };
            var transaction3 = new Transaction(3, purse.Id, user.Id)
            {
                Sum = -402,
                Currency = "UAH",
                Category = category,
                Description = "November",
                Date = new DateTime(2021, 11, 20, 15, 0, 0),
                File = "Photo"
            };
            var transaction4 = new Transaction(4, purse.Id, user.Id)
            {
                Sum = -1023,
                Currency = "UAH",
                Category = category,
                Description = "December",
                Date = new DateTime(2021, 12, 20, 15, 0, 0),
                File = "Photo"
            };

            purse.Transactions.Add(transaction1);
            purse.Transactions.Add(transaction2);
            purse.Transactions.Add(transaction3);
            purse.Transactions.Add(transaction4);

            var expected = 
                "1 -400 UAH Household March 14.03.2021 15:00:00 1 1" +
                "  2 -500 UAH Household August 10.07.2021 15:00:00 1 1" +
                "  3 -402 UAH Household November 20.11.2021 15:00:00 1 1" +
                "  4 -1023 UAH Household December 20.12.2021 15:00:00 1 1  ";

            //Act
            var actual = interaction.GetLastTansactions(purse);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateDownloadTransactionsFromIndex()
        {
            //Arrange
            var interaction = new Interaction();
            //Categories
            var category = new Category(1)
            {
                Name = "Household",
                Description = "Flat expenses",
                Color = "Black",
                Icon = "House"
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
                Name = "Personal purse",
                Balance = 2000,
                Description = "For personal expenses",
                Currency = "USD"
            };
            user.Purses.Add(purse);

            interaction.SetCategories(new List<Category>() { category }, purse);

            var transaction1 = new Transaction(1, purse.Id, user.Id)
            {
                Sum = -400,
                Currency = "UAH",
                Category = category,
                Description = "March",
                Date = new DateTime(2021, 03, 14, 15, 0, 0)
            };
            var transaction2 = new Transaction(2, purse.Id, user.Id)
            {
                Sum = -500,
                Currency = "UAH",
                Category = category,
                Description = "August",
                Date = new DateTime(2021, 07, 10, 15, 0, 0)
            };
            var transaction3 = new Transaction(3, purse.Id, user.Id)
            {
                Sum = -402,
                Currency = "UAH",
                Category = category,
                Description = "November",
                Date = new DateTime(2021, 11, 20, 15, 0, 0),
                File = "Photo"
            };
            var transaction4 = new Transaction(4, purse.Id, user.Id)
            {
                Sum = -1023,
                Currency = "UAH",
                Category = category,
                Description = "December",
                Date = new DateTime(2021, 12, 20, 15, 0, 0),
                File = "Photo"
            };

            purse.Transactions.Add(transaction1);
            purse.Transactions.Add(transaction2);
            purse.Transactions.Add(transaction3);
            purse.Transactions.Add(transaction4);

            var expected =
                "3 -402 UAH Household November 20.11.2021 15:00:00 1 1" +
                "  4 -1023 UAH Household December 20.12.2021 15:00:00 1 1  ";

            //Act
            var actual = interaction.DownloadTransactionsFromIndex(purse, 3);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
