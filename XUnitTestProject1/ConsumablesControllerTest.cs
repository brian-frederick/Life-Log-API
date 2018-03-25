using Life_Log_API.Controllers;
using Life_Log_API.Models;
using Life_Log_API.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class ConsumablesControllerTest
    {
        protected ConsumablesController ControllerUnderTest { get; }
        protected Mock<IConsumablesService> ConsumablesServiceMock { get; }

        public ConsumablesControllerTest()
        {
            ConsumablesServiceMock = new Mock<IConsumablesService>();
            ControllerUnderTest = new ConsumablesController(ConsumablesServiceMock.Object);
        }

        public class Get : ConsumablesControllerTest
        {
            [Fact]
            public void Should_return_all_consumables()
            {

                // arrange
                var dateValue = new DateTime(2017, 1, 18);
                var expectedConsumables = new Consumable[]
                {
                    new Consumable {Id = 0, Name = "Buffalo Wings", CreatedAt = dateValue, Quantity = 12, Unit = "Pieces", ImmediateRating = 0, PostRating = 0},
                };
                ConsumablesServiceMock
                    .Setup(x => x.Get())
                    .Returns(expectedConsumables);

                // act 
                var result = ControllerUnderTest.Get();

                // assert
                Assert.Equal(expectedConsumables, result);
            }
        }
        
    }
}
