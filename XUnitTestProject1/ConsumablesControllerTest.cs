using Life_Log_API.Controllers;
using Life_Log_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class ConsumablesControllerTest
    {
        [Fact]
        public void Should_return_OkObjectResult_with_consumables()
        {

            // arrange
            var expectedConsumablesCount = 3;

            // act 
            var controller = new ConsumablesController();
            var result = controller.Get();

            // assert
            Assert.Equal(expectedConsumablesCount, result.Count());
        }
    }
}
