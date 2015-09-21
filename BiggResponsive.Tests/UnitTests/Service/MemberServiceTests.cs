using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using BiggResponsive.Domain.Exceptions;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;
using BiggResponsive.Service;
using Moq;


namespace BiggResponsive.Tests.UnitTests.Service
{   
    [TestClass]
    public class MemberServiceTests
    {
        private IEnumerable<Member> people;
        private Mock<IMemberRepository> mockRepository;
        private MemberService service;

        [TestInitialize]
        public void SetUp()
        {
            this.people = MemberCatalogue();
            this.mockRepository = new Mock<IMemberRepository>();
            this.service = new MemberService(mockRepository.Object);
        }

        [TestMethod]
        public void GetAll_CallsNextLayer_ExpectsVerify()
         {
            this.mockRepository.Setup(p => p.GetAll()).Returns(this.MemberCatalogue()).Verifiable();
            var result = this.service.GetAll();

            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetAll_ReturnsData_ExpectsSuccess()
        {
            this.mockRepository.Setup(p => p.GetAll()).Returns(this.MemberCatalogue());
            var result = this.service.GetAll();

            Assert.IsNotNull(result);
        }

        [TestMethod, ExpectedException(typeof(ParameterNullException))]
        public void GetByTag_TakesNull_ExpectsException()
        {
            var result = this.service.GetByTag(null);
        }

        //[TestMethod]
        //public void GetRandomCards_PassesInt_Expects_Success()
        //{
        //    // test verifies that repository is being called, checks no return data.
        //    this.mockCardRepository.Setup(c => c.GetRandomCards(It.IsAny<int>())).Returns(this.smallDeck);
        //    var result = this.service.GetRandomCards(It.IsAny<int>());

        //    Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void GetByTag_TakesValidTag_ExpectsSuccess()
        {
            const string tag = "hero";
            this.mockRepository.Setup(p => p.GetByTag(It.IsAny<string>())).Returns(this.MemberCatalogue());
            var result = this.service.GetByTag(tag).ToList();

            // service has no logic but to pass a string to the repository.
            Assert.IsNotNull(result);
        }

        #region test data to place into the mock

        private IEnumerable<Member> MemberCatalogue()
        {
            var people = new List<Member>();

            var person1= new Member
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
