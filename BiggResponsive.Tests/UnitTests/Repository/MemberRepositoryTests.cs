using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;
using BiggResponsive.Domain.Exceptions;
using BiggResponsive.Domain.Repository;

namespace BiggResponsive.Tests.UnitTests.Repository
{
    [TestClass]
    public class MemberRepositoryTests
    {
        private IEnumerable<Member> people;
        private IMemberRepository repository;

        [TestInitialize]
        public void SetUp()
        {
            this.people = MemberCatalogue();
            this.repository = new MemberRepository();
        }

        [TestMethod]
        public void GetAll_NotMuchCanGoWrong_ExpectsResults()
        {
            var result = this.repository.GetAll().ToList();

            Assert.IsTrue(result.Count > 0);
        }


        [TestMethod, ExpectedException(typeof(ParameterNullException))]
        public void GetByTag_PassEmpty_ExpectedException()
        {
            var result = this.repository.GetByTag(string.Empty).ToList();
        }

        [TestMethod]
        public void GetByTag_PassLegitTag_ExpectsResults()
        {
            var expected = 0;
            const string tag = "hero";
            var result = this.repository.GetByTag(tag).ToList();

            Assert.IsTrue(result.Count > expected);
        }

        [TestMethod]
        public void GetByTag_PassNonLegitTag_ExpectsZeroResults()
        {
            var expected = 0;
            const string tag = "zombie";  // zombies no longer allowed after customers complained of bites.
            var result = this.repository.GetByTag(tag).ToList();

            Assert.IsTrue(result.Count == expected);
        }

        [TestMethod]
        public void GetByTag_PassPartialTag_ExpectsZeroResults()
        {
            var expected = 0;
            const string tag = "iction";  // four letters short of legit tag "fictional"
            var result = this.repository.GetByTag(tag).ToList();

            Assert.IsTrue(result.Count == expected);
        }


        #region initial experiments

        /// <summary>
        /// Works, but not in a way we trus
        /// </summary>
        [TestMethod]
        public void MemberCatalog_GetHero_DumbWay()
        {
            var expected = 1;
            var result = this.people.Where(p => p.Tags.Contains("hero")).ToList();

            Assert.AreEqual(expected, result.Count());
        }

        /// <summary>
        /// Shows why we don't trust this - need a word-per-word comparison.
        /// </summary>
        [TestMethod]
        public void MemberCatalog_GetHero_DumbWay_ShowsFault()
        {
            var expected = 0;
            const string aCoupleLetters = "ate"; // part of the word "animated" - 7 occurrances
            var result = this.people.Where(p => p.Tags.Contains(aCoupleLetters)).ToList();

            Assert.IsTrue(expected < result.Count()); // more results than expected
        }

        [TestMethod]
        public void MemberCatalog_TagMatch_RightWay()
        {
            const string tag = "hero";
            var pattern = string.Concat(@"\b(", tag, @")\b");
            var expected = 1;

            var result = this.people.Where(p => Regex.IsMatch(p.Tags, pattern)).ToList();

            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod]
        public void MemberCatalog_TagMatch_RightWayAgain()
        {
            const string tag = "villian";
            var pattern = string.Concat(@"\b(", tag, @")\b");
            var expected = 8;

            var result = this.people.Where(p => Regex.IsMatch(p.Tags, pattern)).ToList();

            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod]
        public void MemberCatalog_TagMatch_VefifyNoPartialMatch()
        {
            const string tag = "at";
            var pattern = string.Concat(@"\b(", tag, @")\b"); // just an fyi, the hyphen is a legit boundary, so would return 7 records for "fi" as in "sci-fi".
            var expected = 0;

            var result = this.people.Where(p => Regex.IsMatch(p.Tags, pattern)).ToList();

            Assert.AreEqual(expected, result.Count());
        }


        #endregion

      
        #region test data

        private IEnumerable<Member> MemberCatalogue()
        {
            var people = new List<Member>();

            var person1 = new Member
            {
                PersonId = 309,
                FirstName = "Tsuneo",
                LastName = "Hasegawa",
                Zip = "92113",
                State = "CA",
                City = "San Diego",
                Address = "925 High Alpine Drive",
                Email = "ICanSeeForMiles@nowhere.com",
                Phone = "619.324.6592",
                ProfileImage = "Tsuneo_Hasegawa.jpg",
                Tags = "athlete, explorer"
            };

            var person2 = new Member
            {
                PersonId = 310,
                FirstName = "Ahsoka",
                LastName = "Tano",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "1 Coruscant J-Tower",
                Email = "PadawanGurl@nowhere.com",
                Phone = "425.908.3492",
                ProfileImage = "Ahsoka_Tano.jpg",
                Tags = "animated, fictional, hero, sci-fi"
            };

            var person3 = new Member
            {
                PersonId = 311,
                FirstName = "Commander",
                LastName = "Sela",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "123 Cold St.",
                Email = "CommanderSela@nowhere.com",
                Phone = "425.908.3442",
                ProfileImage = "Commander_Sela.jpg",
                Tags = "fictional, sci-fi, villian"
            };

            var person4 = new Member
            {
                PersonId = 312,
                FirstName = "Gul",
                LastName = "Dukat",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "1245 Clever Bad Guy Ave.",
                Email = "2Smart4U@nowhere.com",
                Phone = "425.908.3292",
                ProfileImage = "Gul-Dukat.jpg",
                Tags = "fictional, sci-fi, villian"
            };

            var person5 = new Member
            {
                PersonId = 313,
                FirstName = "Hondo",
                LastName = "Ohnaka",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "125 Skullduggery St.",
                Email = "Stuff4Sale@nowhere.com",
                Phone = "425.908.9892",
                ProfileImage = "Hondo_Ohnaka.png",
                Tags = "animated, fictional, sci-fi, villian" /* though a useful villian */
            };

            var person6 = new Member
            {
                PersonId = 314,
                FirstName = "Asajj",
                LastName = "Ventress",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "2356 Betrayed Again Road",
                Email = "CollectBountiesNow@nowhere.com",
                Phone = "425.903.9842",
                ProfileImage = "Asajj_Ventress.jpg",
                Tags = "animated, fictional, sci-fi, villian"
            };

            var person7 = new Member
            {
                PersonId = 315,
                FirstName = "Mother",
                LastName = "Talzin",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "223 Magics Circle",
                Email = "NightSisters@nowhere.com",
                Phone = "425.905.9852",
                ProfileImage = "Mother_Talzin.jpg",
                Tags = "animated, fictional, sci-fi, villian"
            };

            var person8 = new Member
            {
                PersonId = 316,
                FirstName = "Savage",
                LastName = "Oppress",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "245 Brother's Apprentice",
                Email = "BeenAroundAlot@nowhere.com",
                Phone = "425.905.0752",
                ProfileImage = "Savage_Opress.png",
                Tags = "animated, fictional, sci-fi, villian"
            };

            var person9 = new Member
            {
                PersonId = 317,
                FirstName = "King",
                LastName = "Candy",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "2356 My Way or The Hwy.",
                Email = "Turbo1@nowhere.com",
                Phone = "425.905.0172",
                ProfileImage = "King_Candy.jpeg",
                Tags = "animated, fictional, politician, racer, video-game, villian"
            };

            var person10 = new Member
            {
                PersonId = 318,
                FirstName = "The",
                LastName = "Monarch",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "2156 Hive Street",
                Email = "BowBeforeMonarch@nowhere.com",
                Phone = "425.905.0172",
                ProfileImage = "The_Monarch.png",
                Tags = "animated, fictional, villian"
            };


            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            people.Add(person5);
            people.Add(person6);
            people.Add(person7);
            people.Add(person8);
            people.Add(person9);
            people.Add(person10);

            return people;
        }

        #endregion

    }
}
