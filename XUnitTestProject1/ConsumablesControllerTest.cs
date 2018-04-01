using Life_Log_API.Controllers;
using Life_Log_API.Models;
using Life_Log_API.Services;
using Microsoft.AspNetCore.Mvc;
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

        public class GetById : ConsumablesControllerTest
        {

            [Fact]
            public void Should_return_ok_correct_consumable()
            {
                // assign
                var id = 3;
                var expectedConsumable = new Consumable { Id = 3, Name = "Buffalo Wings", CreatedAt = new DateTime(2017,1,18), Quantity = 12, Unit = "Pieces", ImmediateRating = 0, PostRating = 0 };
                ConsumablesServiceMock
                    .Setup(x => x.Get(id))
                    .Returns(expectedConsumable);

                // act
                var result = ControllerUnderTest.Get(id);

                //assert
                Assert.IsType<OkObjectResult>(result);
            }

            [Fact]
            public void Should_return_not_found_result()
            {
                // assign
                var id = 205;
                ConsumablesServiceMock
                    .Setup(x => x.Get(id))
                    .Throws(new Exception());

                // act
                var result = ControllerUnderTest.Get(id);

                //assert
                Assert.IsType<NotFoundObjectResult>(result);
            }


        }

        public class Post: ConsumablesControllerTest
        {

            [Fact]
            public void Should_return_ok_new_consumable()
            {
                // assign
                var dateValue = new DateTime(2017, 1, 18);
                var expectedConsumable = new Consumable { Id = 0, Name = "Buffalo Wings", CreatedAt = dateValue, Quantity = 12, Unit = "Pieces", ImmediateRating = 0, PostRating = 0 };
                ConsumablesServiceMock
                    .Setup(x => x.Post(expectedConsumable))
                    .Returns(expectedConsumable);

                // act
                var result = ControllerUnderTest.Post(expectedConsumable);

                //assert
                Assert.IsType<OkObjectResult>(result);
            }
        }
        
    }
}
