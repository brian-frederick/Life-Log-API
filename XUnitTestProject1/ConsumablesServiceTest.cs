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
                    new Consumable {Id = 0, Name = "Buffalo Wings", CreatedAt = dateValue, Quantity = "1", Unit = "serving", Rating = 1},
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

    }
}
