using System;
using System.Linq;
using System.Collections.Generic;
using BiggResponsive.Domain.Models;
using BiggResponsive.Domain.Utilities;
using BiggResponsive.Domain.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiggResponsive.Tests.IntegrationTests
{
    [TestClass]
    public class EnumerableExtensionTests
    {
        private List<string> noRepeatedStringList;
        private List<string> repeatedStringList;
        private List<Product> repeatedProductList;
        private List<Product> noRepeatedProductList;
        private List<Member> dozenPeopleList;
        private List<Member> morePeopleList;

        [TestInitialize]
        public void SetUp()
        {
            this.noRepeatedStringList = NoRepeatedItemList();
            this.repeatedStringList = RepeatedItemList();
            this.repeatedProductList = RepeatedProductsList();
            this.noRepeatedProductList = NoRepeatedProductsList();
            this.dozenPeopleList = DozenPeople();
            this.morePeopleList = MorePeople();
        }

        /// <summary>
        /// Comparer on List<string,string> 
        /// </summary>
        [TestMethod]
        public void DistinctByLambda_ListString_Expects_Unmodified_List()
        {
            var result = this.noRepeatedStringList.Distinct((l1, l2) => l1 == l2 && l1 == l2);
            Assert.AreEqual(4, result.Count()); // started with four items, ended with four items
        }

        [TestMethod]
        public void DistinctByLambda_ListString_Expects_Shorter_List()
        {
            var result = this.repeatedStringList.Distinct((l1, l2) => l1 == l2 && l1 == l2);
            Assert.AreEqual(3, result.Count()); // started with four items, ended with three
        }

        [TestMethod]
        public void DistinctByLambda_ListObject_Expects_Shorter_List()
        {
            var result = this.repeatedProductList.Distinct((l1, l2) => l1.ProductType == l2.ProductType && l1.Name == l2.Name);
            Assert.AreEqual(3, result.Count()); // one of the houses should be booted from the list
        }

        [TestMethod]
        public void DistinctByLambda_GetPeople_NoRepeatedNames()
        {
            var result = this.dozenPeopleList.Distinct((l1, l2) => l1.FirstName == l2.FirstName);
            Assert.AreEqual(8, result.Count()); // all of the names are unique
        }

        [TestMethod]
        public void DistinctByLambda_GetPeople_NoRepeatedIds_NoRepeatedPeopleIfSameNameAndSameCity()
        {
            var result = this.dozenPeopleList.Distinct((l1, l2) => l1.PersonId == l2.PersonId || (l1.FirstName == l2.FirstName && l1.City == l2.City));
            Assert.AreEqual(10, result.Count());
        }

        [TestMethod]
        public void DistinctByLambda_OneListEmpty_ExpectTheOneListValues()
        {
            List<Member> emptyList = new List<Member>();
            var result = emptyList.Union(this.dozenPeopleList).Distinct((l1, l2) => l1.FirstName == l2.FirstName);

            Assert.IsTrue(result.Count() > 1);
        }

        [TestMethod]
        public void DistinctByLambda_OneListReversedEmpty_ExpectTheOneListValues()
        {
            List<Member> emptyList = new List<Member>();
            var result = this.dozenPeopleList.Union(emptyList).Distinct((l1, l2) => l1.FirstName == l2.FirstName);

            Assert.IsTrue(result.Count() > 1);
        }

        /// <summary>
        /// Comparer on List<string,string> 
        /// </summary>
        [TestMethod]
        public void HasMatchByLambda_ListString_Expects_NoMatch_Returns_False()
        {
            var result = this.noRepeatedStringList.HasMatch((l1, l2) => l1 == l2 && l1 == l2);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Comparer on List<string,string> 
        /// </summary>
        [TestMethod]
        public void HasMatchByLambda_ListString_Expects_Match_Returns_True()
        {
            var result = this.repeatedStringList.HasMatch((l1, l2) => l1 == l2 && l1 == l2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasMatchByLambda_ListObject_Expects_NoMatch_Returns_False()
        {
            var result = this.noRepeatedProductList.HasMatch((l1, l2) => l1.ProductType == l2.ProductType && l1.Name == l2.Name);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasMatchByLambda_ListObject_Expects_Match_Returns_True()
        {
            var result = this.repeatedProductList.HasMatch((l1, l2) => l1.ProductType == l2.ProductType && l1.Name == l2.Name);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasMatchByLambda_PeopleList_Expects_MatchOnNames_Returns_True()
        {
            var result = this.dozenPeopleList.HasMatch((l1, l2) => l1.FirstName == l2.FirstName);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasMatchByLambda_PeopleList_Expects_NoMatchOnIds_Expects_False()
        {
            var result = this.dozenPeopleList.HasMatch((l1, l2) => l1.PersonId == l2.PersonId);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasMatchByLambda_PeopleList_Exects_MatchOn_SameNameSameCity_Expects_True()
        {
            var result = this.dozenPeopleList.HasMatch((l1, l2) => l1.PersonId == l2.PersonId || (l1.FirstName == l2.FirstName && l1.City == l2.City));
            Assert.IsTrue(result); // yes there is a match same name is in the same city
        }

        [TestMethod]
        public void HasMatchByLambda_PeopleList_ThereAreTwoRikuyo_SameNameDifferentCity_Expects_False()
        {
            var result = this.dozenPeopleList.HasMatch((l1, l2) => (l1.FirstName == "Rikuyo" && l2.FirstName == "Rikuyo") && (l1.City == l2.City));
            Assert.IsFalse(result);
        }


        #region - Test Data -

        private List<string> NoRepeatedItemList()
        {
            var uniqueList = new List<string>();
            uniqueList.Add("2,3");
            uniqueList.Add("1,4");
            uniqueList.Add("1,2");
            uniqueList.Add("2,4");

            return uniqueList;
        }

        private List<string> RepeatedItemList()
        {
            var repeatedList = new List<string>();
            repeatedList.Add("2,3");
            repeatedList.Add("2,4");
            repeatedList.Add("1,2");
            repeatedList.Add("2,4");

            return repeatedList;
        }

        private List<Product> NoRepeatedProductsList()
        {
            var repeatedProducts = new List<Product>();

            var product1 = new Product { ProductId = 123, ProductType = "Computer", Name = "Microsoft Surface Pro 3" };
            var product2 = new Product { ProductId = 456, ProductType = "Clothing", Name = "Blue Sock" };
            var product3 = new Product { ProductId = 789, ProductType = "Bedding", Name = "Flannel Sheets" };
            var product4 = new Product { ProductId = 444, ProductType = "Clothing", Name = "Black Sock" }; 

            repeatedProducts.Add(product1);
            repeatedProducts.Add(product2);
            repeatedProducts.Add(product3);
            repeatedProducts.Add(product4);

            return repeatedProducts;

        }

        private List<Product> RepeatedProductsList()
        {
            var repeatedProducts = new List<Product>();

            var product1 = new Product { ProductId = 123, ProductType = "Computer", Name = "Microsoft Surface Pro 3" };
            var product2 = new Product { ProductId = 456, ProductType = "Clothing", Name = "Blue Sock" };
            var product3 = new Product { ProductId = 789, ProductType = "Bedding", Name = "Flannel Sheets" };
            var product4 = new Product { ProductId = 444, ProductType = "Clothing", Name = "Blue Sock" }; // symptomatic of bad data.

            repeatedProducts.Add(product1);
            repeatedProducts.Add(product2);
            repeatedProducts.Add(product3);
            repeatedProducts.Add(product4);

            return repeatedProducts;
        }

        private List<Member> DozenPeople()
        {
            // ID is always unique
            // 3 Yuuki's, 2 Kiwako's, 2 Rikuyo's
            // Zip is always the same.
            // 2 Yuuki  from Kyoto, 1 from Osaka
            // 2 Kiwako from Kyoto, 0 from Osaka
            // 1 Rikuyo from Kyoto, 1 from Osaka

            // 8 unique first names
            // 10 distinct people because two of the repeated names live in different towns, and two of the repeated people live in the same place

            var people = new List<Member>();

            var person1 = new Member { PersonId = 123, FirstName = "Yuuki", Zip = "55123", City = "Kyoto" };
            var person2 = new Member { PersonId = 124, FirstName = "Kiwako", Zip = "55123", City = "Kyoto" };
            var person3 = new Member { PersonId = 125, FirstName = "Murasaki", Zip = "55123", City = "Kyoto" };
            var person4 = new Member { PersonId = 126, FirstName = "Rikuyo", Zip = "55123", City = "Kyoto" };
            var person5 = new Member { PersonId = 127, FirstName = "Utako", Zip = "55123", City = "Kyoto" };
            var person6 = new Member { PersonId = 128, FirstName = "Yuuki", Zip = "77863", City = "Osaka" }; // repeated name, distinct city
            var person7 = new Member { PersonId = 129, FirstName = "Shinako", Zip = "55123", City = "Kyoto" };
            var person8 = new Member { PersonId = 130, FirstName = "Kiwako", Zip = "55123", City = "Kyoto" }; // repeated name, same city
            var person9 = new Member { PersonId = 131, FirstName = "Setsu", Zip = "55123", City = "Kyoto" };
            var person10 = new Member { PersonId = 132, FirstName = "Rikuyo", Zip = "77863", City = "Osaka" }; // repeatd name, distinct city
            var person11 = new Member { PersonId = 133, FirstName = "Koto", Zip = "55123", City = "Kyoto" };
            var person12 = new Member { PersonId = 134, FirstName = "Yuuki", Zip = "55123", City = "Kyoto" }; // repeated name, same city

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
            people.Add(person11);
            people.Add(person12);

            return people;
        }

        private List<Member> MorePeople()
        {

            var people = new List<Member>();

            var person25 = new Member
            {
                PersonId = 147,
                FirstName = "Jun",
                LastName = "Igarashi",
                Zip = "53223",
                State = "MN",
                City = "Mendota Heights",
                Address = "3345 Capital Road",
                Email = "JunsArchitecture@nowhere.com",
                Phone = "612.0227.3211"
            };

            var person26 = new Member
            {
                PersonId = 148,
                FirstName = "Makoto",
                LastName = "Yamaguchi",
                Zip = "52678",
                State = "MN",
                City = "Duluth",
                Address = "3256 Hilltop Lane",
                Email = "MakatoYamaguchi@nowhere.com",
                Phone = "952.8327.6293"
            };

            var person27 = new Member
            {
                PersonId = 149,
                FirstName = "Kouhei",
                LastName = "Ishikawa",
                Zip = "52348",
                State = "MN",
                City = "Duluth",
                Address = "3346 Hollyhock Lane",
                Email = "KouheiIshikawa@nowhere.com",
                Phone = "952.837.6293"
            };
            var person28 = new Member
            {
                PersonId = 150,
                FirstName = "Tetsuya",
                LastName = "Nakashima",
                Zip = "52632",
                State = "MN",
                City = "Duluth",
                Address = "3478 Haskell St.",
                Email = "TetsuyaNakashima@nowhere.com",
                Phone = "952.837.6295"
            };
            var person29 = new Member
            {
                PersonId = 151,
                FirstName = "Yuto",
                LastName = "Maeda",
                Zip = "54578",
                State = "MN",
                City = "Duluth",
                Address = "3456 Hoover Road",
                Email = "YutoMaeda@nowhere.com",
                Phone = "952.833.6243"
            };

            var person30 = new Member
            {
                PersonId = 152,
                FirstName = "Aoi",
                LastName = "Fujita",
                Zip = "52789",
                State = "MN",
                City = "Duluth",
                Address = "346 Hippity Hop",
                Email = "AoiFujita@nowhere.com",
                Phone = "952.832.3193"
            };

            var person31 = new Member
            {
                PersonId = 153,
                FirstName = "Miu",
                LastName = "Kimura",
                Zip = "52357",
                State = "MN",
                City = "Duluth",
                Address = "9806 Hooligan Hwy",
                Email = "MiuKimura@nowhere.com",
                Phone = "952.342.6343"
            };

            var person32 = new Member
            {
                PersonId = 154,
                FirstName = "Shizuka",
                LastName = "Yamaguchi",
                Zip = "52386",
                State = "MN",
                City = "Duluth",
                Address = "8542 Hopeful Way",
                Email = "ShizukaYamaguchi@nowhere.com",
                Phone = "952.863.8249"
            };

            var person33 = new Member
            {
                PersonId = 155,
                FirstName = "Princess",
                LastName = "Kaguya",
                Zip = "52386",
                State = "MN",
                City = "Moon",
                Address = "2345 Capital Drive",
                Email = "MoonPrincess@nowhere.com",
                Phone = "952.623.7939"
            };

            var person34 = new Member
            {
                PersonId = 156,
                FirstName = "Tomonori",
                LastName = "Kogawa",
                Zip = "52386",
                State = "MN",
                City = "St. Cloud",
                Address = "2345 Anime Road",
                Email = "Tomonori_Toons@nowhere.com",
                Phone = "952.324.7931"
            };

            var person35 = new Member
            {
                PersonId = 157,
                FirstName = "Kunio",
                LastName = "Kato",
                Zip = "52386",
                State = "MN",
                City = "Minnetonka",
                Address = "2245 West Seventh",
                Email = "KunioK@nowhere.com",
                Phone = "952.364.5741"
            };

            var person36 = new Member
            {
                PersonId = 158,
                FirstName = "Tensai",
                LastName = "Okamura",
                Zip = "52324",
                State = "MN",
                City = "Oak Park",
                Address = "2255 Main Street",
                Email = "TensaiStudios@nowhere.com",
                Phone = "952.334.5761"
            };

            var person37 = new Member
            {
                PersonId = 159,
                FirstName = "Noburo",
                LastName = "Ofuji",
                Zip = "52321",
                State = "MN",
                City = "Hugo",
                Address = "2145 Egg Lake Trail",
                Email = "NoburoOfjui22@nowhere.com",
                Phone = "952.464.5461"
            };

            var person38 = new Member
            {
                PersonId = 160,
                FirstName = "Kihachiro",
                LastName = "Kawamoto",
                Zip = "52322",
                State = "MN",
                City = "Hastings",
                Address = "8235 River Road East",
                Email = "KihachisMail@nowhere.com",
                Phone = "952.864.8468"
            };

            var person39 = new Member
            {
                PersonId = 161,
                FirstName = "Yasunari",
                LastName = "Kawabata",
                Zip = "52321",
                State = "MN",
                City = "Red Wing",
                Address = "7765 Pottery Drive",
                Email = "YasunariBooks@nowhere.com",
                Phone = "952.864.8468"
            };

            var person40 = new Member
            {
                PersonId = 162,
                FirstName = "Banana",
                LastName = "Yoshimoto",
                Zip = "52334",
                State = "MN",
                City = "Farmington",
                Address = "33876 East Lake Drive",
                Email = "BananaBooks@nowhere.com",
                Phone = "952.694.2469"
            };

            var person41 = new Member
            {
                PersonId = 163,
                FirstName = "Ihara",
                LastName = "Saikaku",
                Zip = "52324",
                State = "MN",
                City = "Lakeville",
                Address = "3224 West Valley Drive",
                Email = "FloatingEverywheres@nowhere.com",
                Phone = "952.694.2469"
            };

            var person42 = new Member
            {
                PersonId = 164,
                FirstName = "Fuyumi",
                LastName = "Ono",
                Zip = "52345",
                State = "MN",
                City = "Minneapolis",
                Address = "3224 12th Kingdom St.",
                Email = "FuyumisTwelveKingdoms@nowhere.com",
                Phone = "952.278.5489"
            };

            var person43 = new Member
            {
                PersonId = 165,
                FirstName = "Nobu",
                LastName = "Matsuhisa",
                Zip = "52337",
                State = "MN",
                City = "Minneapolis",
                Address = "Food And Fish Boulevard",
                Email = "BestFoodzEva@nowhere.com",
                Phone = "952.278.5489"
            };

            var person44 = new Member
            {
                PersonId = 166,
                FirstName = "Rumiko",
                LastName = "Takahashi",
                Zip = "53577",
                State = "MN",
                City = "Cross Lake",
                Address = "5432 Mermaid Court",
                Email = "UnmeiNoTori_Rumiko@nowhere.com",
                Phone = "952.278.5489"
            };

            var person45 = new Member
            {
                PersonId = 167,
                FirstName = "Ryoko",
                LastName = "Tani",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "8875 West Dojo Ave",
                Email = "FlipU_OnUrBack@nowhere.com",
                Phone = "952.234.5437"
            };

            var person46 = new Member
            {
                PersonId = 168,
                FirstName = "Tetsuya",
                LastName = "Yamano",
                Zip = "55368",
                State = "MN",
                City = "Bloomington",
                Address = "3565 Daytona Ave",
                Email = "TooFastForYou@nowhere.com",
                Phone = "612.572.5479"
            };

            var person47 = new Member
            {
                PersonId = 169,
                FirstName = "Nahoko",
                LastName = "Uehashi",
                Zip = "55964",
                State = "MN",
                City = "Elbow Lake",
                Address = "8758 Grant Ave",
                Email = "Nahoko_Uehashi@nowhere.com",
                Phone = "612.982.5099"
            };

            var person48 = new Member
            {
                PersonId = 171,
                FirstName = "Daisuke",
                LastName = "Takahashi",
                Zip = "55368",
                State = "MN",
                City = "St. Louis Park",
                Address = "2848 South Ave",
                Email = "DaisukeT@nowhere.com",
                Phone = "612.935.5145"
            };

            var person49 = new Member
            {
                PersonId = 172,
                FirstName = "Yoshiteru",
                LastName = "Takahashi",
                Zip = "55334",
                State = "MN",
                City = "Little Canada",
                Address = "978 Yeti Footprint Road",
                Email = "Yoshiteru_.Takahashi.com",
                Phone = "952.245.6745"
            };

            var person50 = new Member
            {
                PersonId = 173,
                FirstName = "Noriko",
                LastName = "Uemura",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "South Duck Ave",
                Email = "NorikosVoiceActing@nowhere.com",
                Phone = "952.365.6767"
            };

            var person51 = new Member
            {
                PersonId = 174,
                FirstName = "Takako",
                LastName = "Uemura",
                Zip = "55144",
                State = "MN",
                City = "Sandstone",
                Address = "East Kettle River Rd.",
                Email = "Takako_Uemura@nowhere.com",
                Phone = "612.334.7361"
            };

            var person52 = new Member
            {
                PersonId = 175,
                FirstName = "Nobuko",
                LastName = "Miyamoto",
                Zip = "55122",
                State = "MN",
                City = "Eagan",
                Address = "South Hwy 13",
                Email = "Nobuko_AtGhibli@nowhere.com",
                Phone = "952.364.7121"
            };

            var person53 = new Member
            {
                PersonId = 176,
                FirstName = "Tomoko",
                LastName = "Tabata",
                Zip = "55532",
                State = "MN",
                City = "Pipestone",
                Address = "Bedrock Drive South",
                Email = "T.Tabata@nowhere.com",
                Phone = "612.524.1137"
            };

            var person54 = new Member
            {
                PersonId = 177,
                FirstName = "Takahata",
                LastName = "Atsuko",
                Zip = "53532",
                State = "MN",
                City = "Grand Forks",
                Address = "Red River Valley Drive",
                Email = "Take2_Atsuko@nowhere.com",
                Phone = "612.524.7437"
            };

            people.Add(person25);
            people.Add(person26);
            people.Add(person27);
            people.Add(person28);
            people.Add(person29);
            people.Add(person30);
            people.Add(person31);
            people.Add(person32);
            people.Add(person33);
            people.Add(person34);
            people.Add(person35);
            people.Add(person36);
            people.Add(person37);
            people.Add(person38);
            people.Add(person39);
            people.Add(person40);
            people.Add(person41);
            people.Add(person42);
            people.Add(person43);
            people.Add(person44);
            people.Add(person45);
            people.Add(person46);
            people.Add(person47);
            people.Add(person48);
            people.Add(person49);
            people.Add(person50);
            people.Add(person51);
            people.Add(person52);
            people.Add(person53);
            people.Add(person54);

            return people;

        }

        #endregion
        
    }
}
