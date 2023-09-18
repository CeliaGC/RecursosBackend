sing Entities.Entities;
using Logic.Logic;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject
{
    [TestClass]
    public class EventsLogicUnitTest
    {

        public readonly EventsLogic _eventsLogic;
        [TestMethod]

        public void InsertEvents()
        {
            var EventA = new Events();

            EventA.Id = default;


            Assert.AreNotEqual(EventA.Id, null);
        }

    }


}