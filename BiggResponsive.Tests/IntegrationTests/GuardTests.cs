using BiggResponsive.Domain.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BiggResponsive.Tests.IntegrationTests
{
    [TestClass]
    public class GuardTests
    {

        [TestInitialize]
        public void SetUp()
        {
            // stubbed
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNotNull_Takes_Null_Throws_Exception()
        {
            Guard.ArgumentNotNull(null, "unittest");
        }

        [TestMethod]
        public void ArgumentNotNull_Not_Null_No_Exception()
        {
            var someObject = new Object();
            Guard.ArgumentNotNull(someObject, "unittest some object");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ArgumentNotNullOrEmpty_Takes_Empty_Throws_Exception()
        {
            Guard.ArgumentNotNullOrEmpty(string.Empty, "unittest");
        }

        [TestMethod]
        public void ArgumentNotNullOrEmpty_Takes_String_No_Exception()
        {
            var foo = "foo";
            Guard.ArgumentNotNullOrEmpty(foo, "foo");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void DateTimeNotUnset_Takes_DefaultDateTime_Throws_Exception()
        {
            DateTime noDateTime = new DateTime();
            Guard.CheckDateTime(noDateTime, "unittest");
        }

        [TestMethod]
        public void DateTimeNotUnset_Takes_ValidDateTime_No_Exception()
        {
            var rightNow = DateTime.Now;
            Guard.CheckDateTime(rightNow, "unittest");
        }
    }
}

