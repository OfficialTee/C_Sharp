using BusinessLayer;
using System;
using System.Collections.Generic;
using Xunit;

namespace BusinessLayerTests
{
    public class CategoryTests
    {
        [Fact]
        public void StaticTest()
        {
            //Arrange
            var category1 = new Category
            {
                Name = "Food",
                Description = "Food shopping",
                Color = "Green",
                Icon = "Apple"
            };
            Category.InstanceCount += 1;

            var category2 = new Category
            {
                Name = "Electronics",
                Description = "Electronics shopping",
                Color = "Black",
                Icon = "Phone"
            };
            Category.InstanceCount += 1;

            var category3 = new Category
            {
                Name = "Real estate",
                Description = "Real estate shopping",
                Color = "Yellow",
                Icon = "House"
            };
            Category.InstanceCount += 1;


            var expected = 3;

            //Act
            var actual = Category.InstanceCount;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateTrueTest()
        {
            //Arrange

            //Categories
            var category = new Category(1)
            {
                Name = "Food",
                Description = "Food purchase",
                Color = "Green",
                Icon = "Fruit"
            };       

            var expected = true;

            //Act
            var actual = category.Validate();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateFalseTest()
        {
            //Arrange

            //Categories
            var category = new Category(1)
            {
                Name = "Food",
                Description = "Food purchase",
            };

            var expected = false;

            //Act
            var actual = category.Validate();

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
