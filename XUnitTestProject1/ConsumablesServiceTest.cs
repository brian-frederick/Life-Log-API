using Life_Log_API.Models;
using Life_Log_API.Repositories;
using Life_Log_API.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class ConsumablesServiceTest
    {
        protected IConsumablesService ConsumablesServiceToTest { get; }
        protected Mock<IConsumablesRepository> ConsumablesRepositoryMock { get; }

        public ConsumablesServiceTest()
        {
            ConsumablesRepositoryMock = new Mock<IConsumablesRepository>();
            ConsumablesServiceToTest = new ConsumablesService(ConsumablesRepositoryMock.Object);
        }

        public class Get : ConsumablesServiceTest
        {
            [Fact]
            public void Should_return_all_consumables()
            {
                //Arrange
                var dateValue = new DateTime(2017, 1, 18);
                var expectedConsumables = new Consumable[]
                {
                    new Consumable {Id = 0, Name = "Buffalo Wings", CreatedAt = dateValue, Quantity = 12, Unit = "Pieces", ImmediateRating = 0, PostRating = 0},
                };
                ConsumablesRepositoryMock
                    .Setup(x => x.Get())
                    .Returns(expectedConsumables);

                //Act
                var result = ConsumablesServiceToTest.Get();

                //Assert
                Assert.Equal(expectedConsumables, result);
            }

        }

        public class GetById : ConsumablesServiceTest
        {


            [Fact]
            public void Should_return_ok_correct_consumable()
            {

                // assign
                var expectedConsumable = new Consumable { Id = 3, Name = "Buffalo Wings", CreatedAt = new DateTime(2017, 1, 18), Quantity = 12, Unit = "Pieces", ImmediateRating = 0, PostRating = 0 };
                var id = 3;
                ConsumablesRepositoryMock
                    .Setup(x => x.Get(id))
                    .Returns(expectedConsumable);

                // act
                var result = ConsumablesServiceToTest.Get(id);

                //assert
                Assert.Equal(expectedConsumable, result);
            }

        }

        public class Post : ConsumablesServiceTest
        {
            [Fact]
            public void Should_return_new_consumable()
            {
                //Arrange
                var newConsumable = new Consumable { Id = 0, Name = "Buffalo Wings", CreatedAt = new DateTime(2017, 1, 18), Quantity = 12, Unit = "Pieces", ImmediateRating = 0, PostRating = 0 };
                ConsumablesRepositoryMock
                    .Setup(x => x.Post(newConsumable))
                    .Returns(newConsumable);

                //Act
                var result = ConsumablesServiceToTest.Post(newConsumable);

                //Assert
                Assert.Equal(newConsumable, result);
            }

        }

    }
}
