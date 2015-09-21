using BiggResponsive.Domain.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiggResponsive.Tests.IntegrationTests
{
    [TestClass]
    public class ExtensionTests
    {

        [TestInitialize]
        public void SetUp()
        {
            // stubbed
        }

        [TestMethod]
        public void HasUpperCase_HasUpper_ExpectsTrue()
        {
            const string password = "MastaPatrolla";
            var hasUpper = password.HasUpperCase();

            Assert.IsTrue(hasUpper);
        }

        [TestMethod]
        public void HasUpperCase_NoUpper_ExpectsFalse()
        {
            const string password = "mastapatrolla";
            var hasUpper = password.HasUpperCase();

            Assert.IsFalse(hasUpper);
        }

        [TestMethod]
        public void HasLowerCase_HasUpper_ExpectsTrue()
        {
            const string password = "MastaPatrolla";
            var hasLower = password.HasLowerCase();

            Assert.IsTrue(hasLower);
        }

        [TestMethod]
        public void HasLowerCase_NoUpper_ExpectsFalse()
        {
            const string password = "MASTAPATROLLA";
            var hasLower = password.HasLowerCase();

            Assert.IsFalse(hasLower);
        }

        [TestMethod]
        public void HasSpecialCharacters_HasSpace_ExpectsTrue()
        {
            const string password = "Masta Patrolla";
            var hasLower = password.HasSpecialCharacter();

            Assert.IsTrue(hasLower);
        }

        [TestMethod]
        public void HasSpecialCharacters_HasAmpesand_ExpectsTrue()
        {
            const string password = "M@staPatrolla";
            var hasLower = password.HasSpecialCharacter();

            Assert.IsTrue(hasLower);
        }

        [TestMethod]
        public void HasSpecialCharacters_HasPlusSign_ExpectsTrue()
        {
            const string password = "Mas+aPatrolla";
            var hasLower = password.HasSpecialCharacter();

            Assert.IsTrue(hasLower);
        }

        [TestMethod]
        public void HasSpecialCharacters_NoSpecial_ExpectsFalse()
        {
            const string password = "MastaPatrolla";
            var hasLower = password.HasSpecialCharacter();

            Assert.IsFalse(hasLower);
        }
    }
}
