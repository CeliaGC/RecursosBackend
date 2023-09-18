using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities.Entities;

[TestClass]
public class OrderItemLogicTests
{

    [TestMethod]
    public void GetOrders_WhenMultipleUsers_ReturnsOrdersGroupedByUser()
    {
        // Arrange
        var orderItems = new List<OrderItem>
        {
            new OrderItem { IdUser = 1, Username = "User1" },
            new OrderItem { IdUser = 1, Username = "User1" },
            new OrderItem { IdUser = 2, Username = "User2" }
        };

        // Act
        var result = _orderItemLogic.GetOrders();

        // Assert
        Assert.AreEqual(2, result.Count); // 2 Users
        Assert.AreEqual(2, result.First().Count); // User1 has 2 orders
        Assert.AreEqual(1, result.Last().Count);  // User2 has 1 order
    }
}
