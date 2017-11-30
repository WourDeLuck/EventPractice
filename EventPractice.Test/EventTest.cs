using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventPractice;
using System.IO;

namespace EventPractice.Test
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void EventRaiseTest()
        {
            ShowEvent showEvent = new ShowEvent();

            showEvent.RaiseEvent();

            Assert.IsTrue(showEvent.checkFlag);
        }
    }
}
