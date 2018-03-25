using Life_Log_API.Models;
using Life_Log_API.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class ConsumablesRepositoryTest
    {
        protected ConsumablesRepository ConsumablesRepositoryToTest { get; set; }
        protected List<Consumable> Consumables { get; set; }

        public ConsumablesRepositoryTest()
        {
            var dateValue = new DateTime(2017, 1, 18);

            Consumables = new List<Consumable>
            {
                new Consumable {Id = 0, Name = "Buffalo Wings", CreatedAt = dateValue, Quantity = 12, Unit = "Pieces", ImmediateRating = 0, PostRating = 0}
            };

            ConsumablesRepositoryToTest = new ConsumablesRepository(Consumables);
        }

        public class Get : ConsumablesRepositoryTest
        {
            [Fact]
            public void Should_return_all_consumables()
            {
                // arrange
                var dateValue = new DateTime(2017, 1, 18);
                var expectedConsumables = new List<Consumable>
                {
                    new Consumable {Id = 0, Name = "Buffalo Wings", CreatedAt = dateValue, Quantity = 1, Unit = "piece", ImmediateRating = 0, PostRating = 1},
                };

                // act
                var result = ConsumablesRepositoryToTest.Get();

                // assert
                Assert.Collection(result,
                    consumable => Assert.Same(Consumables[0], consumable)
                );

            }
        }
    }
}
