using Entities.Entities;

namespace TestProject1
{
    [TestClass]
    public class OrderItemTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange & Act

            var newOrder = new OrderItem();

            // Assert

            Assert.IsTrue(newOrder.IsActive);
            Assert.IsTrue((DateTime.Now - newOrder.InsertDate).TotalSeconds < 1);

        }
    }
}