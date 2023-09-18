using Entities.Entities;
using Logic.Logic;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject
{
    [TestClass]
    public class InsertProductItemTest
    {

        public readonly ProductLogic _productLogic;
        [TestMethod]

        public void InsertProductItem()
        {
            //Arrange Act
            var ProductA = new ProductItem();
            ProductA.IdWeb = default;


            //Assert

            Assert.IsNotNull(ProductA.IdWeb);
        }

    }


}