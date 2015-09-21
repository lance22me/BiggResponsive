using System;
using BiggResponsive.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiggResponsive.Tests.IntegrationTests
{
    [TestClass]
    public class EnumTests
    {

        [TestInitialize]
        public void SetUp()
        {
            // stubbed
        }

        [TestMethod]
        public void PhoneNumberType_ValueToKey()
        {
            const string expected = "Mobile";
            var result = Enum.GetName(typeof(PhoneNumberType), 2);

            Assert.AreEqual(expected, result);
        }
    }
}
