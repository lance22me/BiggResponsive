using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;
using BiggResponsive.Domain.Extensions;
using BiggResponsive.Domain.Utilities;


namespace BiggResponsive.Domain.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private IEnumerable<Member> members;

        public MemberRepository()
        {
            this.members = MemberCatalogue();
        }

        public IEnumerable<Member> GetAll()
        {
            var allMembers = this.members.Where(m => m.PersonId > 1).OrderBy(m => m.LastName).ToSafeList();
            return allMembers;
        }

        public IEnumerable<Member> GetByTag(string tag)
        {
            Guard.ParameterNotNullOrEmpty(tag, "tag");
            var pattern = string.Concat(@"\b(", tag, @")\b");

            return this.members.Where(p => Regex.IsMatch(p.Tags, pattern)).OrderBy(m => m.LastName).ToSafeList();
        }

        #region data

        // 10 People Per Each City - give or take a few.
        // -------------------------------------------------------

        // Birmingham, AL 35211         Area Code  205
        // Montgomery, AL 36110         Area code  334
        // Huntsville, AL 35802         Area code  256 - not started / gathering people - all Japanese

        // Tuscon, AZ 85701             Area Code  520

        // Oceanside, CA 92049          Area Code  714
        // Sacramento, CA 94209         Area Code  916
        // San Diego, CA 92113          Area code  619
        // San Jose, CA 95103           Area code  669

        // Atlanta, GA  30302           Area Code  407

        // Clearwater, FL 33756         Area code  727
        // Orlando, FL  32804           Area Code  407
        // Miami, FL 33126              Area Code  305
        // St. Augustine, FL 32080      Area Code  904
        // Wauchula, FL 33873           Area Code  863

        // Boston, MA   02109           Area Code  857
        // Chicopee, MA 01014           Area Code  413

        // Duluth, MN 55807             Area Code  425
        // Eagan, MN 55123              Area Codes 612 / 952
        // Eden Prairie, MN 55346       Area Code  651
        // Edina, MN  55424             Area code  952
        // Mahtomedi, MN 55115          Area Code  651
        // Minneapolis, MN 55401        Area Coce  612
        // White Bear Lake, MN 55110    Area Code  612 / 952

        // New York, NY 10007           Area Code  212
        // Yonkers, NY 10702            Area Code  914

        // Bellevue, WA 98007           Area code  425
        // Issaquah, WA 98027           Area Code  425
        // Mercer Island, WA 98040      Area Code  206
        // Seattle, WA  98102           Area code  206
        // Sequim, WA  98382            Area code  360

        // Bayfield, WI  54814          Area Code  715
        // Hudson, WI 54016             Area code  715
        // River Falls, WI 54022        Area Code  715
        // Stockholm, WI 54769          Area Code  715


        // Tags = "author, athlete, artist, animated, cat, chef, explorer, farmer, fictional, hero, politician, racer, sci-fi, techie, video-game, villian"

        private IEnumerable<Member> MemberCatalogue()
        {
            var people = new List<Member>();

            var person1 = new Member
            {
                PersonId = 123,
                FirstName = "Yuuki",
                LastName = "Hashidate",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "2087 South West Ave.",
                Email = "yuuki@nowhere.com",
                Phone = "952.288.8976",
                ProfileImage = string.Empty,
                Tags = string.Empty
            };
            var person2 = new Member
            {
                PersonId = 124,
                FirstName = "Kiwako",
                LastName = "Akashi",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "1655 South Side Ave.",
                Email = "Kiwako@nowhere.com",
                Phone = "952.234.9876",
                ProfileImage = "Kiwako_Akashi.jpg",
                Tags = string.Empty
            };
            var person3 = new Member
            {
                PersonId = 125,
                FirstName = "Murasaki",
                LastName = "Matsushima",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "8765 Jeffs Bridge Road",
                Email = "Murasaki@nowhere.com",
                Phone = "612.998.3409",
                ProfileImage = string.Empty,
                Tags = string.Empty
            };
            var person4 = new Member
            {
                PersonId = 126,
                FirstName = "Rikuyo",
                LastName = "Nagumo",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "2233 Bluebird Way",
                Email = "Rikuyo@nowhere.com",
                Phone = "952.987.9087",
                ProfileImage = string.Empty,
                Tags = string.Empty
            };
            var person5 = new Member
            {
                PersonId = 127,
                FirstName = "Utako",
                LastName = "Miyuki",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "9852 Hooskers Trail NW",
                Email = "Utako@nowhere.com",
                Phone = "612.987.0965",
                ProfileImage = string.Empty,
                Tags = string.Empty
            };
            var person6 = new Member
            {
                PersonId = 128,
                FirstName = "Tsuruko",
                LastName = "Usagi",
                Zip = "55123",
                State = "WI",
                City = "Eagan",
                Address = "2349 Booboo's Garden Trail",
                Email = "Tsuruko@nowhere.com",
                Phone = "952.997.8750",
                ProfileImage = "Tsuruko_Usagi.jpg",
                Tags = "author"
            };
            var person7 = new Member
            {
                PersonId = 129,
                FirstName = "Shinako",
                LastName = "Yamada",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "1 1st Ave.",
                Email = "Shinkako@nowhere.com",
                Phone = "952.988.3769",
                ProfileImage = "Shinako_Yamada.jpg",
                Tags = string.Empty
            };
            var person8 = new Member
            {
                PersonId = 130,
                FirstName = "Kiwako",
                LastName = "Nakamura",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "9802 Northern Lights St.",
                Email = "KiwakoTwo@nowhere.com",
                Phone = "612.980.7765",
                ProfileImage = string.Empty,
                Tags = string.Empty
            };
            var person9 = new Member
            {
                PersonId = 131,
                FirstName = "Setsu",
                LastName = "Matsumoto",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "8877 Flash Gordon Road",
                Email = "Setsu@nowhere.com",
                Phone = "612.090.9876",
                ProfileImage = "Setsu_Matsumoto.jpg",
                Tags = "athlete, racer"
            };
            var person10 = new Member
            {
                PersonId = 132,
                FirstName = "Rikuyo",
                LastName = "Akuma",
                Zip = "55123",
                State = "MN",
                City = "Eagan",
                Address = "97472 Jooce Street",
                Email = "RikuyoTwo@nowhere.com",
                Phone = "612.986.9815",
                ProfileImage = "Rikuyo_Akuma.jpg",
                Tags = string.Empty
            };
            var person11 = new Member
            {
                PersonId = 133,
                FirstName = "Koto",
                LastName = "Ikeda",
                Zip = "55807",
                State = "MN",
                City = "Duluth",
                Address = "178 West Stevens",
                Email = "Koto@nowhere.com",
                Phone = "425.986.5733",
                ProfileImage = "Koto_Ikeda.jpg",
                Tags = string.Empty
            };
            var person12 = new Member
            {
                PersonId = 134,
                FirstName = "Yuuki",
                LastName = "Takachiho",
                Zip = "55807",
                State = "MN",
                City = "Duluth",
                Address = "9803 Sunnydale Street",
                Email = "YuukiTwo@nowhere.com",
                Phone = "425.987.5732",
                ProfileImage = "Yuuki_Takachiho.jpg",
                Tags = string.Empty
            };

            var person13 = new Member
            {
                PersonId = 135,
                FirstName = "Cousin",
                LastName = "Bill",
                Zip = "55807",
                State = "MN",
                City = "Duluth",
                Address = "345 Village Road",
                Email = "CousinBill@nowhere.com",
                Phone = "425.934.3119",
                ProfileImage = "Cuzn_Bill.jpg",
                Tags = string.Empty
            };

            var person14 = new Member
            {
                PersonId = 136,
                FirstName = "Racoom",
                LastName = "Boom",
                Zip = "55807",
                State = "MN",
                City = "Duluth",
                Address = "2244 Lower Falls Drive",
                Email = "RhymmsWithDoom@nowhere.com",
                Phone = "425.233.7619",
                ProfileImage = "Racoome_Boom.jpg",
                Tags = "animated, fictional, villian"
            };

            var person15 = new Member
            {
                PersonId = 137,
                FirstName = "Yukon",
                LastName = "Cornelius",
                Zip = "55807",
                State = "MN",
                City = "Duluth",
                Address = "87 Wolf Circle",
                Email = "DogSledDude23@nowhere.com",
                Phone = "425.373.7739",
                ProfileImage = "Yukon_Cornelius.jpg",
                Tags = "animated, explorer, fictional"
            };

            var person16 = new Member
            {
                PersonId = 138,
                FirstName = "Yoshinari",
                LastName = "Matsushita",
                Zip = "55807",
                State = "MN",
                City = "Duluth",
                Address = "234 Bellagueyie Road",
                Email = "YoshiMatsushita@nowhere.com",
                Phone = "425.269.2699",
                ProfileImage = "Yoshinari_Matsushita.jpg",
                Tags = "athlete, racer"
            };

            var person17 = new Member
            {
                PersonId = 139,
                FirstName = "Ayumi",
                LastName = "Hatoyama",
                Zip = "55807",
                State = "MN",
                City = "Duluth",
                Address = "345 Judgement Road",
                Email = "AyumiMHatoyama@nowhere.com",
                Phone = "425.345.5678",
                ProfileImage = "Ayumi_Hatoyama.jpg",
                Tags = string.Empty
            };

            var person18 = new Member
            {
                PersonId = 140,
                FirstName = "George",
                LastName = "Washington",
                Zip = "55807",
                State = "MN",
                City = "Duluth",
                Address = "1 Liberty Trail",
                Email = "GeorgeW@nowhere.com",
                Phone = "425.642.8478",
                ProfileImage = "George_Washington.jpg",
                Tags = "hero, politician"
            };

            var person19 = new Member
            {
                PersonId = 141,
                FirstName = "Laura",
                LastName = "Wilder",
                Zip = "55807",
                State = "MN",
                City = "Duluth",
                Address = "12 Sodhouse Lane",
                Email = "LauraIngallsWilder@nowhere.com",
                Phone = string.Empty,
                ProfileImage = "Laura_Wilder.jpg",
                Tags = "author"
            };

            var person20 = new Member
            {
                PersonId = 142,
                FirstName = "Aulus",
                LastName = "Vitellius",
                Zip = "55807",
                State = "MN",
                City = "Duluth",
                Address = "LeCordon Bleu Culinary Coll.",
                Email = "ImGonnaEatEverything@nowhere.com",
                Phone = string.Empty,
                ProfileImage = "Aulus_Vitellius.jpg",
                Tags = "politician"
            };

            var person21 = new Member
            {
                PersonId = 143,
                FirstName = "Ronald",
                LastName = "McDonald",
                Zip = "55110",
                State = "MN",
                City = "White Bear Lake",
                Address = "4587 Robert Street",
                Email = "RonaldMcDonald@nowhere.com",
                Phone = "612.456.4568",
                ProfileImage = "Ronald_McDonald.jpg",
                Tags = "mascot"
            };

            var person22 = new Member
            {
                PersonId = 144,
                FirstName = "Wendy",
                LastName = "Thomas",
                Zip = "55110",
                State = "MN",
                City = "White Bear Lake",
                Address = "764 Duckwood",
                Email = "WendyFromWendysd@nowhere.com",
                Phone = "612.765.9872",
                ProfileImage = "Wendy_Wendys.jpg",
                Tags = "chef, mascot"
            };

            var person23 = new Member
            {
                PersonId = 145,
                FirstName = "Burger",
                LastName = "King",
                Zip = "55110",
                State = "MN",
                City = "White Bear Lake",
                Address = "729 Duckwood",
                Email = "DaKingd@nowhere.com",
                Phone = "612.0987.0971",
                ProfileImage = "Burger_King.jpg",
                Tags = "chef, mascot"
            };

            var person24 = new Member
            {
                PersonId = 146,
                FirstName = "Harlan",
                LastName = "Sanders",
                Zip = "55110",
                State = "MN",
                City = "White Bear Lake",
                Address = "457 Duckwood",
                Email = "TheColonel@nowhere.com",
                Phone = "612.0987.0971",
                ProfileImage = "Colonel_Sanders.jpg",
                Tags = "chef, mascot"
            };

            var person25 = new Member
            {
                PersonId = 147,
                FirstName = "Jun",
                LastName = "Igarashi",
                Zip = "55110",
                State = "MN",
                City = "White Bear Lake",
                Address = "3345 Capital Road",
                Email = "JunsArchitecture@nowhere.com",
                Phone = "612.0227.3211",
                ProfileImage = "Jun_Igarashi.jpg",
                Tags = string.Empty
            };

            var person26 = new Member
            {
                PersonId = 148,
                FirstName = "Makoto",
                LastName = "Yamaguchi",
                Zip = "55110",
                State = "MN",
                City = "White Bear Lake",
                Address = "3256 Hilltop Lane",
                Email = "MakatoYamaguchi@nowhere.com",
                Phone = "952.8327.6293",
                ProfileImage = "Makoto_Yamaguchi.jpg",
                Tags = string.Empty
            };

            var person27 = new Member
            {
                PersonId = 149,
                FirstName = "Kouhei",
                LastName = "Ishikawa",
                Zip = "55110",
                State = "MN",
                City = "White Bear Lake",
                Address = "3346 Hollyhock Lane",
                Email = "KouheiIshikawa@nowhere.com",
                Phone = "612.837.6293",
                ProfileImage = "Kouhei_Ishikawa.jpg",
                Tags = string.Empty
            };
            var person28 = new Member
            {
                PersonId = 150,
                FirstName = "Tetsuya",
                LastName = "Nakashima",
                Zip = "55110",
                State = "MN",
                City = "White Bear Lake",
                Address = "3478 Haskell St.",
                Email = "TetsuyaNakashima@nowhere.com",
                Phone = "952.837.6295",
                ProfileImage = "Tetsuya_Nakashima.jpg",
                Tags = string.Empty
            };
            var person29 = new Member
            {
                PersonId = 151,
                FirstName = "Yuto",
                LastName = "Maeda",
                Zip = "55110",
                State = "MN",
                City = "White Bear Lake",
                Address = "3456 Hoover Road",
                Email = "YutoMaeda@nowhere.com",
                Phone = "952.833.6243",
                ProfileImage = "Yuto_Maeda.jpg",
                Tags = "chef"
            };

            var person30 = new Member
            {
                PersonId = 152,
                FirstName = "Aoi",
                LastName = "Fujita",
                Zip = "55110",
                State = "MN",
                City = "White Bear Lake",
                Address = "346 Hippity Hop",
                Email = "AoiFujita@nowhere.com",
                Phone = "952.832.3193",
                ProfileImage = "Aoi_Fujita.jpg",
                Tags = string.Empty
            };

            var person31 = new Member
            {
                PersonId = 153,
                FirstName = "Miu",
                LastName = "Kimura",
                Zip = "33873",
                State = "FL",
                City = "Wauchula",
                Address = "9806 Hooligan Hwy",
                Email = "MiuKimura@nowhere.com",
                Phone = "863.342.6343",
                ProfileImage = "Miu_Kimura.jpg",
                Tags = string.Empty
            };

            var person32 = new Member
            {
                PersonId = 154,
                FirstName = "Shizuka",
                LastName = "Yamaguchi",
                Zip = "33873",
                State = "FL",
                City = "Wauchula",
                Address = "8542 Hopeful Way",
                Email = "ShizukaYamaguchi@nowhere.com",
                Phone = "863.863.8249",
                ProfileImage = "Shizuka_Yamaguchi.jpg",
                Tags = string.Empty
            };

            var person33 = new Member
            {
                PersonId = 155,
                FirstName = "Princess",
                LastName = "Kaguya",
                Zip = "33873",
                State = "FL",
                City = "Wauchula",
                Address = "2345 Capital Drive",
                Email = "MoonPrincess@nowhere.com",
                Phone = "863.623.7939",
                ProfileImage = "Princess_Kaguya.jpg",
                Tags = "animated, fictional"
            };

            var person34 = new Member
            {
                PersonId = 156,
                FirstName = "Tomonori",
                LastName = "Kogawa",
                Zip = "33873",
                State = "FL",
                City = "Wauchula",
                Address = "2345 Anime Road",
                Email = "Tomonori_Toons@nowhere.com",
                Phone = "863.324.7931",
                ProfileImage = "Tomonori_Kogawa.jpg",
                Tags = "artist"
            };

            var person35 = new Member
            {
                PersonId = 157,
                FirstName = "Kunio",
                LastName = "Kato",
                Zip = "33873",
                State = "FL",
                City = "Wauchula",
                Address = "2245 West Seventh",
                Email = "KunioK@nowhere.com",
                Phone = "863.364.5741",
                ProfileImage = "Kunio_Kato.jpg",
                Tags = string.Empty
            };

            var person36 = new Member
            {
                PersonId = 158,
                FirstName = "Tensai",
                LastName = "Okamura",
                Zip = "33873",
                State = "FL",
                City = "Wauchula",
                Address = "2255 Main Street",
                Email = "TensaiStudios@nowhere.com",
                Phone = "863.334.5761",
                ProfileImage = "Tensai_Okamura.jpg",
                Tags = "artist"
            };

            var person37 = new Member
            {
                PersonId = 159,
                FirstName = "Noburo",
                LastName = "Ofuji",
                Zip = "33873",
                State = "FL",
                City = "Wauchula",
                Address = "2145 Egg Lake Trail",
                Email = "NoburoOfjui22@nowhere.com",
                Phone = "863.464.5461",
                ProfileImage = "Noburo_Ofuji.jpg",
                Tags = "artist"
            };

            var person38 = new Member
            {
                PersonId = 160,
                FirstName = "Kihachiro",
                LastName = "Kawamoto",
                Zip = "33873",
                State = "FL",
                City = "Wauchula",
                Address = "8235 River Road East",
                Email = "KihachisMail@nowhere.com",
                Phone = "863.864.8468",
                ProfileImage = "Kihachiro_Kawamoto.jpg",
                Tags = string.Empty
            };

            var person39 = new Member
            {
                PersonId = 161,
                FirstName = "Yasunari",
                LastName = "Kawabata",
                Zip = "33873",
                State = "FL",
                City = "Wauchula",
                Address = "7765 Pottery Drive",
                Email = "YasunariBooks@nowhere.com",
                Phone = "863.864.8468",
                ProfileImage = "Yasunari_Kawabata.jpg",
                Tags = "author"
            };

            var person40 = new Member
            {
                PersonId = 162,
                FirstName = "Banana",
                LastName = "Yoshimoto",
                Zip = "33873",
                State = "FL",
                City = "Wauchula",
                Address = "33876 East Lake Drive",
                Email = "BananaBooks@nowhere.com",
                Phone = "863.694.2469",
                ProfileImage = "banana_yoshimoto.jpg",
                Tags = "author"
            };

            var person41 = new Member
            {
                PersonId = 163,
                FirstName = "Ihara",
                LastName = "Saikaku",
                Zip = "98027",
                State = "WA",
                City = "Issaquah",
                Address = "3224 West Valley Drive",
                Email = "FloatingEverywheres@nowhere.com",
                Phone = "425.694.2469",
                ProfileImage = "Ihara_Saikaku.jpg",
                Tags = "author"
            };

            var person42 = new Member
            {
                PersonId = 164,
                FirstName = "Fuyumi",
                LastName = "Ono",
                Zip = "98027",
                State = "WA",
                City = "Issaquah",
                Address = "3224 12th Kingdom St.",
                Email = "FuyumisTwelveKingdoms@nowhere.com",
                Phone = "425.278.5489",
                ProfileImage = "Fuyumi_Ono.jpg",
                Tags = "author"
            };

            var person43 = new Member
            {
                PersonId = 165,
                FirstName = "Nobu",
                LastName = "Matsuhisa",
                Zip = "98027",
                State = "WA",
                City = "Issaquah",
                Address = "Food And Fish Boulevard",
                Email = "BestFoodzEva@nowhere.com",
                Phone = "425.278.5489",
                ProfileImage = "Nobu_Matsuhisa.jpg",
                Tags = "chef"
            };

            var person44 = new Member
            {
                PersonId = 166,
                FirstName = "Rumiko",
                LastName = "Takahashi",
                Zip = "98027",
                State = "WA",
                City = "Issaquah",
                Address = "5432 Mermaid Court",
                Email = "UnmeiNoTori_Rumiko@nowhere.com",
                Phone = "425.278.5489",
                ProfileImage = "Rumiko_Takahashi.gif",
                Tags = "author"
            };

            var person45 = new Member
            {
                PersonId = 167,
                FirstName = "Ryoko",
                LastName = "Tani",
                Zip = "98027",
                State = "WA",
                City = "Issaquah",
                Address = "8875 West Dojo Ave",
                Email = "FlipU_OnUrBack@nowhere.com",
                Phone = "425.234.5437",
                ProfileImage = "Ryoko_Tani.jpg",
                Tags = "athlete"
            };

            var person46 = new Member
            {
                PersonId = 168,
                FirstName = "Tetsuya",
                LastName = "Yamano",
                Zip = "98027",
                State = "WA",
                City = "Issaquah",
                Address = "3565 Daytona Ave",
                Email = "TooFastForYou@nowhere.com",
                Phone = "425.572.5479",
                ProfileImage = "Tetsuya_Yamano.jpg",
                Tags = "racer"
            };

            var person47 = new Member
            {
                PersonId = 169,
                FirstName = "Nahoko",
                LastName = "Uehashi",
                Zip = "98027",
                State = "WA",
                City = "Issaquah",
                Address = "8758 Grant Ave",
                Email = "Nahoko_Uehashi@nowhere.com",
                Phone = "425.982.5099",
                ProfileImage = "Nahoko_Uehashi.jpg",
                Tags = string.Empty
            };

            // missing 170

            var person48 = new Member
            {
                PersonId = 171,
                FirstName = "Daisuke",
                LastName = "Takahashi",
                Zip = "98027",
                State = "WA",
                City = "Issaquah",
                Address = "2848 South Ave",
                Email = "DaisukeT@nowhere.com",
                Phone = "425.935.5145",
                ProfileImage = "Daisuke_Takahashi.jpg",
                Tags = "artist"
            };

            var person49 = new Member
            {
                PersonId = 172,
                FirstName = "Yoshiteru",
                LastName = "Takahashi",
                Zip = "98027",
                State = "WA",
                City = "Issaquah",
                Address = "978 Yeti Footprint Road",
                Email = "Yoshiteru_.Takahashi.com",
                Phone = "425.245.6745",
                ProfileImage = "Yoshiteru_Takahashi.jpg",
                Tags = "explorer"
            };

            var person50 = new Member
            {
                PersonId = 173,
                FirstName = "Noriko",
                LastName = "Uemura",
                Zip = "98027",
                State = "WA",
                City = "Issaquah",
                Address = "South Duck Ave",
                Email = "NorikosVoiceActing@nowhere.com",
                Phone = "425.365.6767",
                ProfileImage = "Noriko_Uemura.jpg",
                Tags = "artist"
            };

            var person51 = new Member
            {
                PersonId = 174,
                FirstName = "Takako",
                LastName = "Uemura",
                Zip = "54022",
                State = "WI",
                City = "River Falls",
                Address = "East Kettle River Rd.",
                Email = "Takako_Uemura@nowhere.com",
                Phone = "715.334.7361",
                ProfileImage = "Takako_Uemura.jpg",
                Tags = string.Empty
            };

            var person52 = new Member
            {
                PersonId = 175,
                FirstName = "Nobuko",
                LastName = "Miyamoto",
                Zip = "54022",
                State = "WI",
                City = "River Falls",
                Address = "South Hwy 13",
                Email = "Nobuko_AtGhibli@nowhere.com",
                Phone = "715.364.7121",
                ProfileImage = "Nobuko_Miyamoto.jpg",
                Tags = "artist"
            };

            var person53 = new Member
            {
                PersonId = 176,
                FirstName = "Tomoko",
                LastName = "Tabata",
                Zip = "54022",
                State = "WI",
                City = "River Falls",
                Address = "Bedrock Drive South",
                Email = "T.Tabata@nowhere.com",
                Phone = "715.524.1137",
                ProfileImage = "Tomoko_Tabata.jpg",
                Tags = string.Empty
            };

            var person54 = new Member
            {
                PersonId = 177,
                FirstName = "Takahata",
                LastName = "Atsuko",
                Zip = "54022",
                State = "WI",
                City = "River Falls",
                Address = "Red River Valley Drive",
                Email = "Take2_Atsuko@nowhere.com",
                Phone = "715.524.7437",
                ProfileImage = "Takahata_Atsuko.jpg",
                Tags = "artist" /* voice actors classified as artists */
            };

            var person55 = new Member
            {
                PersonId = 178,
                FirstName = "Yutaka",
                LastName = "Yuzawa",
                Zip = "54022",
                State = "WI",
                City = "River Falls",
                Address = "8876 Minnesota Valley Road",
                Email = "YutakaYuzawa@nowhere.com",
                Phone = "715.535.6537",
                ProfileImage = "Yutaka_Yuzawa.jpg",
                Tags = string.Empty
            };

            var person56 = new Member
            {
                PersonId = 179,
                FirstName = "Kei",
                LastName = "Nishikori",
                Zip = "54022",
                State = "WI",
                City = "River Falls",
                Address = "9838 West Side Boulevard",
                Email = "KeiNishikori@nowhere.com",
                Phone = "715.635.3507",
                ProfileImage = "Kei_Nishikori.jpg",
                Tags = "athlete"
            };

            var person57 = new Member
            {
                PersonId = 180,
                FirstName = "Shinobu",
                LastName = "Asagoe",
                Zip = "54022",
                State = "WI",
                City = "River Falls",
                Address = "998 Lie Shore Ave.",
                Email = "ShinobuAsagoe@nowhere.com",
                Phone = "715.235.1943",
                ProfileImage = "Shinobu_Asagoe.jpg",
                Tags = "athlete"
            };

            var person58 = new Member
            {
                PersonId = 181,
                FirstName = "Masaomi",
                LastName = "Suzuki",
                Zip = "54022",
                State = "WI",
                City = "River Falls",
                Address = "887 Snowy Haven Rd.",
                Email = "MasaomiSuzuki@nowhere.com",
                Phone = "715.665.7986",
                ProfileImage = "Masaomi_Suzuki.jpg",
                Tags = "farmer"
            };

            var person59 = new Member
            {
                PersonId = 182,
                FirstName = "Yasuhide",
                LastName = "Nakayama",
                Zip = "54022",
                State = "WI",
                City = "River Falls",
                Address = "781 Lost Trail Rd.",
                Email = "YasuhideNakayama@nowhere.com",
                Phone = "715.635.3965",
                ProfileImage = "Yasuhide_Nakayama.jpg",
                Tags = "politician"
            };

            var person60 = new Member
            {
                PersonId = 183,
                FirstName = "Iemitsu",
                LastName = "Tokugawa",
                Zip = "54022",
                State = "WI",
                City = "River Falls",
                Address = "257 Country Rd.",
                Email = "IemitsuTokugawa@nowhere.com",
                Phone = "715.634.3945",
                ProfileImage = "Iemitsu_Tokugawa.jpg",
                Tags = "farmer"
            };

            var person61 = new Member
            {
                PersonId = 184,
                FirstName = "Ai",
                LastName = "Miyazato",
                Zip = "54769",
                State = "WI",
                City = "Stockholm",
                Address = "7376 Lake Pepin Rd.",
                Email = "AiMiyazatoa@nowhere.com",
                Phone = "715.673.3515",
                ProfileImage = "Ai_Miyazato.jpg",
                Tags = "athlete"
            };

            var person62 = new Member
            {
                PersonId = 185,
                FirstName = "Takahito",
                LastName = "Hanazawa",
                Zip = "54769",
                State = "WI",
                City = "Stockholm",
                Address = "7376 Pierce Ave.",
                Email = "TakahitoHanazawa@nowhere.com",
                Phone = "715.573.6517",
                ProfileImage = "Takahito_Hanazawa.jpg",
                Tags = "farmer"
            };

            var person63 = new Member
            {
                PersonId = 186,
                FirstName = "Tetsuji",
                LastName = "Tamayama",
                Zip = "54769",
                State = "WI",
                City = "Stockholm",
                Address = "338 Maiden Rock",
                Email = "TetsujiTamayama@nowhere.com",
                Phone = "715.573.3416",
                ProfileImage = "Takahito_Hanazawa.jpg",
                Tags = string.Empty
            };

            var person64 = new Member
            {
                PersonId = 187,
                FirstName = "Yukie",
                LastName = "Nakama",
                Zip = "54769",
                State = "WI",
                City = "Stockholm",
                Address = "324 Maiden Rock",
                Email = "YukieNakama@nowhere.com",
                Phone = "715.573.8716",
                ProfileImage = "Yukie_Nakama.jpg",
                Tags = "artist"
            };

            var person65 = new Member
            {
                PersonId = 188,
                FirstName = "Rie",
                LastName = "Funakoshi",
                Zip = "54769",
                State = "WI",
                City = "Stockholm",
                Address = "324 Maiden Rock",
                Email = "RieFunakoshi@nowhere.com",
                Phone = "715.573.2712",
                ProfileImage = "Rie_Funakoshi.jpg",
                Tags = string.Empty
            };

            var person66 = new Member
            {
                PersonId = 189,
                FirstName = "Ona",
                LastName = "Okina",
                Zip = "54769",
                State = "WI",
                City = "Stockholm",
                Address = "742 Kaguya Hime Ave.",
                Email = "OnaOkina@nowhere.com",
                Phone = "715.575.9734",
                ProfileImage = "Ona _Okina.jpg",
                Tags = "animated, fictional"
            };

            var person67 = new Member
            {
                PersonId = 190,
                FirstName = "Hiroshi",
                LastName = "Kiwano",
                Zip = "54769",
                State = "WI",
                City = "Stockholm",
                Address = "797 Bigg Wave Dr.",
                Email = "HiroshiKiwano@nowhere.com",
                Phone = "715.575.3134",
                ProfileImage = "Hiroshi_Kiwano.jpg",
                Tags = "athlete"
            };

            var person68 = new Member
            {
                PersonId = 191,
                FirstName = "Hello",
                LastName = "Kitty",
                Zip = "54769",
                State = "WI",
                City = "Stockholm",
                Address = "847 Hello Kitty Ave.",
                Email = "HelloKitty@nowhere.com",
                Phone = "715.575.3134",
                ProfileImage = "Hello_Kitty.jpg",
                Tags = string.Empty
            };

            var person69 = new Member
            {
                PersonId = 192,
                FirstName = "Takeru",
                LastName = "Kobayashi",
                Zip = "54769",
                State = "WI",
                City = "Stockholm",
                Address = "5323 Food Court Road",
                Email = "TakeruKobayashi@nowhere.com",
                Phone = "715.575.9896",
                ProfileImage = "Takeru_Kobayashi.jpg",
                Tags = "athlete" /* pro food eater as athlete */
            };

            var person70 = new Member
            {
                PersonId = 193,
                FirstName = "Mitsu",
                LastName = "Yashima",
                Zip = "54769",
                State = "WI",
                City = "Stockholm",
                Address = "351 Little House Road",
                Email = "MitsuYashimai@nowhere.com",
                Phone = "715.575.4326",
                ProfileImage = "Mitsu_Yashima.jpg",
                Tags = string.Empty
            };

            var person71 = new Member
            {
                PersonId = 194,
                FirstName = "Harue",
                LastName = "Okitsu",
                Zip = "98040",
                State = "WA",
                City = "Mercer Island",
                Address = "6534 Puget Ave.",
                Email = "MitsuYashimai@nowhere.com",
                Phone = "206.375.4436",
                ProfileImage = "Harue_Okitsu.jpg",
                Tags = string.Empty
            };

            var person72 = new Member
            {
                PersonId = 195,
                FirstName = "Naomichi",
                LastName = "Yasuda",
                Zip = "98040",
                State = "WA",
                City = "Mercer Island",
                Address = "3834 Olympic Drive.",
                Email = "NaomichiYasuda@nowhere.com",
                Phone = "206.375.4831",
                ProfileImage = "Naomichi_Yasuda.jpg",
                Tags = "chef"
            };

            var person73 = new Member
            {
                PersonId = 196,
                FirstName = "Miki",
                LastName = "Ayona",
                Zip = "98040",
                State = "WA",
                City = "Mercer Island",
                Address = "3652 Olympic Drive.",
                Email = "MikiAyona@nowhere.com",
                Phone = "206.375.9754",
                ProfileImage = "Miki_Ayona.jpg",
                Tags = "cat"
            };

            var person74 = new Member
            {
                PersonId = 197,
                FirstName = "Tadashi",
                LastName = "Hirose",
                Zip = "98040",
                State = "WA",
                City = "Mercer Island",
                Address = "373 Whidbey Blvd.",
                Email = "TadashiHirose@nowhere.com",
                Phone = "206.372.3531",
                ProfileImage = "Tadashi_Hirose.jpg",
                Tags = "farmer"
            };

            var person75 = new Member
            {
                PersonId = 198,
                FirstName = "Shuichi",
                LastName = "Yokota",
                Zip = "98040",
                State = "WA",
                City = "Mercer Island",
                Address = "3852 Orca St.",
                Email = "ShuichiYokota@nowhere.com",
                Phone = "206.375.9799",
                ProfileImage = "Shuichi_Yokota.jpg",
                Tags = "farmer"
            };

            var person76 = new Member
            {
                PersonId = 199,
                FirstName = "Kazuo",
                LastName = "Oga",
                Zip = "98040",
                State = "WA",
                City = "Mercer Island",
                Address = "3852 Whidbey Lane",
                Email = "KazuoOga@nowhere.com",
                Phone = "206.375.3942",
                ProfileImage = "Kazuo_Oga.jpg",
                Tags = "artist"
            };

            var person77 = new Member
            {
                PersonId = 200,
                FirstName = "Yasuo",
                LastName = "Otsuka",
                Zip = "98040",
                State = "WA",
                City = "Mercer Island",
                Address = "528 Olympic Circle",
                Email = "YasuoOtsuka@nowhere.com",
                Phone = "206.375.6759",
                ProfileImage = "Yasuo_Otsuka.jpg",
                Tags = "author"
            };

            var person78 = new Member
            {
                PersonId = 201,
                FirstName = "Chuken",
                LastName = "Hachiko",
                Zip = "98040",
                State = "WA",
                City = "Mercer Island",
                Address = "8765 Shibuya Station",
                Email = "Hachiko@nowhere.com",
                Phone = "206.375.8888",
                ProfileImage = "Chuken_Hachiko.jpg",
                Tags = "hero"
            };

            var person79 = new Member
            {
                PersonId = 202,
                FirstName = "Maru",
                LastName = "Yonebayashi",
                Zip = "98040",
                State = "WA",
                City = "Mercer Island",
                Address = "898 Olympic Circle",
                Email = "MaruYonebayashi@nowhere.com",
                Phone = "206.375.8888",
                ProfileImage = "Maru_Yonebayashi.jpg",
                Tags = "cat"
            };

            var person80 = new Member
            {
                PersonId = 203,
                FirstName = "DJ",
                LastName = "Koya",
                Zip = "98040",
                State = "WA",
                City = "Mercer Island",
                Address = "3568 Groove Court",
                Email = "DJKoya@nowhere.com",
                Phone = "206.335.4588",
                ProfileImage = "Dj_Koya.jpg",
                Tags = "artist"
            };

            var person81 = new Member
            {
                PersonId = 204,
                FirstName = "Toph",
                LastName = "Beifong",
                Zip = "54814",
                State = "WI",
                City = "Bayfield",
                Address = "5718 Braille Street",
                Email = "TophBeifong@nowhere.com",
                Phone = "715.435.1528",
                ProfileImage = "Toph_Beifong.jpg",
                Tags = "animated, explorer, fictional, hero"
            };

            var person82 = new Member
            {
                PersonId = 205,
                FirstName = "Twighlight",
                LastName = "Princess",
                Zip = "54814",
                State = "WI",
                City = "Bayfield",
                Address = "248 Shadowland Drive",
                Email = "TwighlightDawn@nowhere.com",
                Phone = "715.415.9871",
                ProfileImage = "Twighlight_Princess.jpg",
                Tags = "animated, fictional, hero, video-game"
            };

            var person83 = new Member
            {
                PersonId = 206,
                FirstName = "Misko",
                LastName = "Hevery",
                Zip = "54814",
                State = "WI",
                City = "Bayfield",
                Address = "8876 Directive Court",
                Email = "AngularFtw@nowhere.com",
                Phone = "715.312.3241",
                ProfileImage = "Misko_Hevery.jpg",
                Tags = "techie"
            };

            var person84 = new Member
            {
                PersonId = 207,
                FirstName = "John",
                LastName = "Resig",
                Zip = "54814",
                State = "WI",
                City = "Bayfield",
                Address = "8276 Selector Ave.",
                Email = "JQueryFtw@nowhere.com",
                Phone = "715.332.3231",
                ProfileImage = "John_Resig.jpeg",
                Tags = "techie"
            };

            var person85 = new Member
            {
                PersonId = 208,
                FirstName = "Geoff",
                LastName = "Schmidt",
                Zip = "54814",
                State = "WI",
                City = "Bayfield",
                Address = "8272 Already Built It St.",
                Email = "MeteorFtw@nowhere.com",
                Phone = "715.342.5244",
                ProfileImage = "Geoff_Schmidt.jpg",
                Tags = "techie"
            };

            var person86 = new Member
            {
                PersonId = 209,
                FirstName = "Yehuda",
                LastName = "Katz",
                Zip = "54814",
                State = "WI",
                City = "Bayfield",
                Address = "8272 Pretty Cool Logo Road",
                Email = "EmberFtw@nowhere.com",
                Phone = "715.347.9274",
                ProfileImage = "Yehuda_Katz.jpg",
                Tags = "techie"
            };

            var person87 = new Member
            {
                PersonId = 210,
                FirstName = "Master",
                LastName = "Roshi",
                Zip = "54814",
                State = "WI",
                City = "Bayfield",
                Address = "1 Tropical Island Way",
                Email = "DragonBall@nowhere.com",
                Phone = "715.342.9274",
                ProfileImage = "Master_Roshi.jpg",
                Tags = "animated, fictional, hero"
            };

            var person88 = new Member
            {
                PersonId = 211,
                FirstName = "General",
                LastName = "Zod",
                Zip = "54814",
                State = "WI",
                City = "Bayfield",
                Address = "2873 Krypton Blvd",
                Email = "BowBeforeZod@nowhere.com",
                Phone = "715.442.4275",
                ProfileImage = "General_Zod.jpg",
                Tags = "explorer, fictional, sci-fi, villian"
            };

            var person89 = new Member
            {
                PersonId = 212,
                FirstName = "Susamu",
                LastName = "Tachi",
                Zip = "54814",
                State = "WI",
                City = "Bayfield",
                Address = "223 Active Camo Street",
                Email = "InvisibilityCloak@nowhere.com",
                Phone = "715.441.6574",
                ProfileImage = "Susamu_Tachi.jpg",
                Tags = "techie"
            };

            var person90 = new Member
            {
                PersonId = 213,
                FirstName = "Archibald",
                LastName = "Snatcher",
                Zip = "54814",
                State = "WI",
                City = "Bayfield",
                Address = "2156 Tasting Room Blvd.",
                Email = "BoxTrollHunter@nowhere.com",
                Phone = "715.442.0094",
                ProfileImage = "Archibald_Snatcher.jpg",
                Tags = "animated, fictional, villian"
            };

            var person91 = new Member
            {
                PersonId = 214,
                FirstName = "Luminara",
                LastName = "Unduli",
                Zip = "94209",
                State = "CA",
                City = "Sacramento",
                Address = "2345 Mirial Ave",
                Email = string.Empty,
                Phone = "916.354.0094",
                ProfileImage = "Luminara_Unduli.jpg",
                Tags = "animated, fictional, hero, sci-fi"
            };

            var person92 = new Member
            {
                PersonId = 215,
                FirstName = "Mister",
                LastName = "Toad",
                Zip = "94209",
                State = "CA",
                City = "Sacramento",
                Address = "9176 Toad Hall Blvd",
                Email = "MisterToad@nowhere.com",
                Phone = "916.354.8754",
                ProfileImage = "Mister_Toad.jpg",
                Tags = string.Empty
            };

            var person93 = new Member
            {
                PersonId = 216,
                FirstName = "Miori",
                LastName = "Takimoto",
                Zip = "94209",
                State = "CA",
                City = "Sacramento",
                Address = "234 Rising Wind Drive",
                Email = "MioriTakimoto@nowhere.com",
                Phone = "916.353.7448",
                ProfileImage = "Miori_Takimoto.jpeg",
                Tags = "fictional, hero"
            };

            var person94 = new Member
            {
                PersonId = 217,
                FirstName = "Mirai",
                LastName = "Shida",
                Zip = "94209",
                State = "CA",
                City = "Sacramento",
                Address = "2454 Red Carpet Ave.",
                Email = "MiraiShida@nowhere.com",
                Phone = "916.353.1408",
                ProfileImage = "Shida_Mirai.jpg",
                Tags = "artist" /* actress as artist */
            };

            var person95 = new Member
            {
                PersonId = 218,
                FirstName = "Count",
                LastName = "Von Count",
                Zip = "94209",
                State = "CA",
                City = "Sacramento",
                Address = "123 Seseme Street",
                Email = "ILoveToCount@nowhere.com",
                Phone = "916.354.5608",
                ProfileImage = "Count_Voncount.jpg",
                Tags = "fictional, villian"
            };

            var person96 = new Member
            {
                PersonId = 219,
                FirstName = "Sauroman",
                LastName = "The White",
                Zip = "94209",
                State = "CA",
                City = "Sacramento",
                Address = "1 Sauroman Tower",
                Email = "TehSupremeWizard@nowhere.com",
                Phone = "916.354.2100",
                ProfileImage = "Sauroman_TheWhite.jpg",
                Tags = "fictional, villian" /* LOTR is not sci-fi */
            };

            var person97 = new Member
            {
                PersonId = 220,
                FirstName = "El",
                LastName = "Macho",
                Zip = "94209",
                State = "CA",
                City = "Sacramento",
                Address = "2334 Macho Lane",
                Email = "TacoParadiseLlc@nowhere.com",
                Phone = "916.354.2320",
                ProfileImage = "El_Macho.jpg",
                Tags = "animated, fictional, villian"
            };

            var person98 = new Member
            {
                PersonId = 221,
                FirstName = "Yayoi",
                LastName = "Kusama",
                Zip = "94209",
                State = "CA",
                City = "Sacramento",
                Address = "9982 Weird Pattern St.",
                Email = "SelfieArt@nowhere.com",
                Phone = "916.354.0908",
                ProfileImage = "Yayoi_Kusama.jpg",
                Tags = "artist"
            };

            var person99 = new Member
            {
                PersonId = 222,
                FirstName = "Rage",
                LastName = "Face",
                Zip = "94209",
                State = "CA",
                City = "Sacramento",
                Address = "666 Raging Mad Blvd",
                Email = "Rage@nowhere.com",
                Phone = "916.354.2666",
                ProfileImage = "Rage_Face.jpg",
                Tags = string.Empty
            };

            var person100 = new Member
            {
                PersonId = 223,
                FirstName = "Hideki",
                LastName = "Matsui",
                Zip = "94209",
                State = "CA",
                City = "Sacramento",
                Address = "649 Big League Drive",
                Email = "HidekiMatsui@nowhere.com",
                Phone = "916.354.2316",
                ProfileImage = "Hideki_Matsui.jpg",
                Tags = "athlete"
            };

             var person101 = new Member
            {
                PersonId = 224,
                FirstName = "Jen",
                LastName = "Yu",
                Zip = "92040",
                State = "CA",
                City = "Oceanside",
                Address = "2345 Hidden Master St.",
                Email = "JenYu@nowhere.com",
                Phone = "714.354.2316",
                ProfileImage = "Jen_Yu.jpg",
                Tags = "fictional, villian"
            };

            var person103 = new Member
            {
                PersonId = 225,
                FirstName = "Master",
                LastName = "Pain",
                Zip = "92040",
                State = "CA",
                City = "Oceanside",
                Address = "2345 Hidden Master St.",
                Email = "CallMeBetty@nowhere.com",
                Phone = "714.354.2346",
                ProfileImage = "Master_Pain.jpg",
                Tags = "fictional, villian"
            };

            var person104 = new Member
            {
                PersonId = 226,
                FirstName = "Chupong",
                LastName = "Changprung",
                Zip = "92040",
                State = "CA",
                City = "Oceanside",
                Address = "2345 Ong Bok Drive",
                Email = "BodyGuard@nowhere.com",
                Phone = "714.354.2346",
                ProfileImage = "Chupong_Changprung.jpg",
                Tags = "fictional, villian"
            };

            var person105 = new Member
            {
                PersonId = 227,
                FirstName = "Shadow",
                LastName = "Jago",
                Zip = "92040",
                State = "CA",
                City = "Oceanside",
                Address = "2345 Blue Thing Street",
                Email = "KillerInstinct@nowhere.com",
                Phone = "714.354.0573",
                ProfileImage = "Shadow_Jago.jpg",
                Tags = "fictional, video-game, villian"
            };


            var person106 = new Member
            {
                PersonId = 228,
                FirstName = "Charles",
                LastName = "Babbage",
                Zip = "92040",
                State = "CA",
                City = "Oceanside",
                Address = "1111 First Computer Road",
                Email = "InventedComputer@nowhere.com",
                Phone = "714.354.8742",
                ProfileImage = "Charles_Babbage.jpg",
                Tags = "techie"
            };

            var person107 = new Member
            {
                PersonId = 229,
                FirstName = "El Gato",
                LastName = "Cosmetico",
                Zip = "92040",
                State = "CA",
                City = "Oceanside",
                Address = "2020 Olympic Games Drive",
                Email = "JapanOlympicMascot@nowhere.com",
                Phone = "714.354.9842",
                ProfileImage = "El_Gato_Cosmico.jpg",
                Tags = "mascot"
            };

            var person108 = new Member
            {
                PersonId = 230,
                FirstName = "Bubba",
                LastName = "Gump",
                Zip = "92040",
                State = "CA",
                City = "Oceanside",
                Address = "234 Tastey Shrimp Road",
                Email = "BubbaGumpMOA@nowhere.com",
                Phone = "714.354.0376",
                ProfileImage = "Bubba_Gump.jpg",
                Tags = "mascot"
            };

            var person109 = new Member
            {
                PersonId = 231,
                FirstName = "Chuck",
                LastName = "Cheeze",
                Zip = "92040",
                State = "CA",
                City = "Oceanside",
                Address = "123 Chuck E Cheeze Plz",
                Email = "Chuck-e-Cheeze@nowhere.com",
                Phone = "714.354.9802",
                ProfileImage = "Chuck_E_Cheeze.jpg",
                Tags = "mascot"
            };

            var person110 = new Member
            {
                PersonId = 232,
                FirstName = "Ceiling",
                LastName = "Cat",
                Zip = "92040",
                State = "CA",
                City = "Oceanside",
                Address = "456 In Ur Roofs",
                Email = "CeilingCat@nowhere.com",
                Phone = "714.352.9823",
                ProfileImage = "Ceiling_Cat.jpg",
                Tags = "cat, hero"
            };

            var person111 = new Member
            {
                PersonId = 233,
                FirstName = "Basement",
                LastName = "Cat",
                Zip = "10007",
                State = "NY",
                City = "New York",
                Address = "0000 Underground Ave",
                Email = "BasementCat@nowhere.com",
                Phone = "212.269.9823",
                ProfileImage = "Basement_Cat.jpg",
                Tags = "cat, villian"
            };

            var person112 = new Member
            {
                PersonId = 234,
                FirstName = "Senior",
                LastName = "Debonaire",
                Zip = "10007",
                State = "NY",
                City = "New York",
                Address = "9876 I don't Always st.",
                Email = "ButWhenIDo@nowhere.com",
                Phone = "212.269.2313",
                ProfileImage = "I_Dont_Always.jpg",
                Tags = "mascot"
            };

            var person113 = new Member
            {
                PersonId = 235,
                FirstName = "Takasugi",
                LastName = "Shinsakuo",
                Zip = "10007",
                State = "NY",
                City = "New York",
                Address = "1001 Kendo Road",
                Email = "NeverSmileBro@nowhere.com",
                Phone = "212.268.0909",
                ProfileImage = "Takasugi_Shinsakuo.jpg",
                Tags = "athlete"
            };

            var person114 = new Member
            {
                PersonId = 236,
                FirstName = "Kenichi",
                LastName = "Ebina",
                Zip = "10007",
                State = "NY",
                City = "New York",
                Address = "2341 Spinning Around Ct.",
                Email = "YouShouldBeDancin@nowhere.com",
                Phone = "212.268.2319",
                ProfileImage = "Kenichi_Ebina.jpg",
                Tags = "athlete"
            };

            var person115 = new Member
            {
                PersonId = 237,
                FirstName = "Yasuharu",
                LastName = "Igarashi",
                Zip = "10007",
                State = "NY",
                City = "New York",
                Address = "2341 Glow In The Dark Ave.",
                Email = "YasuharuIgarashi@nowhere.com",
                Phone = "212.269.0989",
                ProfileImage = "Yasuharu_Igarashi.jpg",
                Tags = "artist"
            };

            var person116 = new Member
            {
                PersonId = 238,
                FirstName = "Butch",
                LastName = "Taylor",
                Zip = "10007",
                State = "NY",
                City = "New York",
                Address = "23 Trinidad Scorpion Road",
                Email = "GrowThemHot@nowhere.com",
                Phone = "212.219.0933",
                ProfileImage = "Butch_Taylor.jpg",
                Tags = "farmer"
            };

            var person117 = new Member
            {
                PersonId = 239,
                FirstName = "Neil",
                LastName = "Smith",
                Zip = "10007",
                State = "NY",
                City = "New York",
                Address = "23 Trinidad Scorpion Road",
                Email = "HippySeedCo@nowhere.com",
                Phone = "212.212.2331",
                ProfileImage = "Neil_Smith.jpg",
                Tags = "farmer"
            };

            var person118 = new Member
            {
                PersonId = 240,
                FirstName = "Takeo",
                LastName = "Gouda",
                Zip = "10007",
                State = "NY",
                City = "New York",
                Address = "232 Giants Ridge",
                Email = "MyLoveStory@nowhere.com",
                Phone = string.Empty,
                ProfileImage = "Takeo_Gouda.jpg",
                Tags = "animated, fictional, hero"
            };

            var person121 = new Member
            {
                PersonId = 242,
                FirstName = "Miranda",
                LastName = "Keyes",
                Zip = "10007",
                State = "NY",
                City = "New York",
                Address = "2345 Halo Circle",
                Email = "GreatestGameEver@nowhere.com",
                Phone = "212.213.5630",
                ProfileImage = "Miranda_Keys.jpg",
                Tags = "fictional, hero, sci-fi, video-game"
            };

            var person123 = new Member
            {
                PersonId = 243,
                FirstName = "Toru",
                LastName = "Hashimoto",
                Zip = "10007",
                State = "NY",
                City = "New York",
                Address = "2345 Bigg Rhetoric Ave.",
                Email = "MayorTokyo@nowhere.com",
                Phone = "212.213.9030",
                ProfileImage = "Toru_Hashimoto.jpg",
                Tags = "politician"
            };

            var person124 = new Member
            {
                PersonId = 244,
                FirstName = "Roy",
                LastName = "Batty",
                Zip = "32080",
                State = "FL",
                City = "St. Augustine",
                Address = "1010 Blade Runner Drive",
                Email = string.Empty,
                Phone = "904.213.2330",
                ProfileImage = "Roy_Batty.jpg",
                Tags = "fictional, sci-fi, villian"
            };

            var person125 = new Member
            {
                PersonId = 245,
                FirstName = "John",
                LastName = "Silver",
                Zip = "32080",
                State = "FL",
                City = "St. Augustine",
                Address = "9807 Treasure Island Way",
                Email = "DontMessWitMe@nowhere.com",
                Phone = "904.212.2250",
                ProfileImage = "John_Silver.jpg",
                Tags = "fictional, villian"
            };

            var person126 = new Member
            {
                PersonId = 246,
                FirstName = "James",
                LastName = "Hook",
                Zip = "32080",
                State = "FL",
                City = "St. Augustine",
                Address = "9807 Neverland Island",
                Email = "JoinTodayFreeTat@nowhere.com",
                Phone = "904.212.1253",
                ProfileImage = "James_Hook.jpg",
                Tags = "fictional, villian"
            };

            var person127 = new Member
            {
                PersonId = 247,
                FirstName = "Shintaro",
                LastName = "Ishihara",
                Zip = "32080",
                State = "FL",
                City = "St. Augustine",
                Address = "1234 Mayor McCheeze St",
                Email = "FormerMayorOfTokyo@nowhere.com",
                Phone = "904.222.1222",
                ProfileImage = "Shintaro_Ishihara.jpg",
                Tags = "politician"
            };

            var person128 = new Member
            {
                PersonId = 248,
                FirstName = "George",
                LastName = "Cockburn",
                Zip = "32080",
                State = "FL",
                City = "St. Augustine",
                Address = "1814 Capital Hill Square",
                Email = "AdmiralCockburn@nowhere.com",
                Phone = "904.223.8764",
                ProfileImage = "Admiral_George_Cockburn.jpg",
                Tags = "hero, politician, villian" /* depending on how you view what he did */
            };

            var person130 = new Member
            {
                PersonId = 249,
                FirstName = "James",
                LastName = "Garfield",
                Zip = "32080",
                State = "FL",
                City = "St. Augustine",
                Address = "1 Pennyslvania Avenue",
                Email = "TwentiethPresident@nowhere.com",
                Phone = "904.213.0364",
                ProfileImage = "James_Garfield.jpg",
                Tags = "politician"
            };

            var person132 = new Member
            {
                PersonId = 251,
                FirstName = "Chef",
                LastName = "Boyardee",
                Zip = "32080",
                State = "FL",
                City = "St. Augustine",
                Address = "1275 Canned Pasta Rd",
                Email = "GoodEatsBrutha@nowhere.com",
                Phone = "904.273.6634",
                ProfileImage = "Chef_Boyardee.jpg",
                Tags = "chef, hero"
            };

            var person133 = new Member
            {
                PersonId = 252,
                FirstName = "Peppermint",
                LastName = "Patty",
                Zip = "32080",
                State = "FL",
                City = "St. Augustine",
                Address = "2375 Peanuts Street",
                Email = "HelloMarcie@nowhere.com",
                Phone = "904.277.6604",
                ProfileImage = "Peppermint_Patty.jpg",
                Tags = "animated, fictional"
            };

            var person134 = new Member
            {
                PersonId = 253,
                FirstName = "Agent",
                LastName = "Smith",
                Zip = "32080",
                State = "FL",
                City = "St. Augustine",
                Address = "2375 Matrix Glitch St.",
                Email = "IFixedUpThePlace@nowhere.com",
                Phone = "904.277.2504",
                ProfileImage = "Agent_Smith.gif",
                Tags = "fictional, sci-fi, villian"
            };

            var person135 = new Member
            {
                PersonId = 254,
                FirstName = "Sam",
                LastName = "Quint",
                Zip = "32080",
                State = "FL",
                City = "St. Augustine",
                Address = "212 Out Sharkin Canal",
                Email = "Orka_One@nowhere.com",
                Phone = "904.277.2504",
                ProfileImage = "Sam_Quint.jpg",
                Tags = "fictional, villian"
            };

            var person136 = new Member
            {
                PersonId = 255,
                FirstName = "Ryutaro",
                LastName = "Hashimoto",
                Zip = "85701",
                State = "AZ",
                City = "Tuscon",
                Address = "212 Prime Minister Drive",
                Email = "HashimotoRyutaro@nowhere.com",
                Phone = "520.907.2504",
                ProfileImage = "Hashimoto_Ryutaro.jpg",
                Tags = "politician"
            };

            var person137 = new Member
            {
                PersonId = 256,
                FirstName = "Junichiro",
                LastName = "Koizumi",
                Zip = "85701",
                State = "AZ",
                City = "Tuscon",
                Address = "213 Prime Minister Drive",
                Email = "JunichiroKoizumi@nowhere.com",
                Phone = "520.907.2204",
                ProfileImage = "Junichiro_Koizumi.jpg",
                Tags = "politician"
            };

            var person138 = new Member
            {
                PersonId = 257,
                FirstName = "Yukio",
                LastName = "Hatoyama",
                Zip = "85701",
                State = "AZ",
                City = "Tuscon",
                Address = "217 Prime Minister Drive",
                Email = "JunichiroKoizumi@nowhere.com",
                Phone = "520.907.2554",
                ProfileImage = "Yukio_Hatoyama.jpg",
                Tags = "politician"
            };

            var person139 = new Member
            {
                PersonId = 258,
                FirstName = "Yoshiro",
                LastName = "Mori",
                Zip = "85701",
                State = "AZ",
                City = "Tuscon",
                Address = "219 Prime Minister Drive",
                Email = "YoshiroMori@nowhere.com",
                Phone = "520.907.2554",
                ProfileImage = "Yoshiro_Mori.jpg",
                Tags = "politician"
            };

            var person140 = new Member
            {
                PersonId = 259,
                FirstName = "Tsutomu",
                LastName = "Hata",
                Zip = "85701",
                State = "AZ",
                City = "Tuscon",
                Address = "221 Prime Minister Drive",
                Email = "TsutomuHata@nowhere.com",
                Phone = "520.907.2554",
                ProfileImage = "Tsutomu_Hata.jpg",
                Tags = "politician"
            };

            var person141 = new Member
            {
                PersonId = 260,
                FirstName = "Polly",
                LastName = "Purebred",
                Zip = "32804",
                State = "FL",
                City = "Orlando",
                Address = "8792 Underdog Road",
                Email = "SweetPollyPurebred@nowhere.com",
                Phone = "407.683.2004",
                ProfileImage = "Polly_Purebred.jpg",
                Tags = "animated, fictional, hero"
            };

            var person142 = new Member
            {
                PersonId = 261,
                FirstName = "Shere",
                LastName = "Khan",
                Zip = "32804",
                State = "FL",
                City = "Orlando",
                Address = "8767 Mumbia Forest",
                Email = "EyeOfTheTigerd@nowhere.com",
                Phone = "407.623.2304",
                ProfileImage = "Shere_Khan.jpg",
                Tags = "animated, cat, fictional, villian"
            };

            var person143 = new Member
            {
                PersonId = 262,
                FirstName = "Jonas",
                LastName = "Grumby",
                Zip = "32804",
                State = "FL",
                City = "Orlando",
                Address = "Slip 72, South Shore Marina",
                Email = "TheSkipper@nowhere.com",
                Phone = "407.623.1104",
                ProfileImage = "Jonas_Grumby.jpg",
                Tags = "fictional"
            };

            var person144 = new Member
            {
                PersonId = 263,
                FirstName = "Marceline",
                LastName = "Queen Vamp",
                Zip = "32804",
                State = "FL",
                City = "Orlando",
                Address = "345 Adventure Time Lane",
                Email = "Marceline@nowhere.com",
                Phone = "407.623.1104",
                ProfileImage = "Marceline_TheQueenOfTheVampires.jpg",
                Tags = "animated, fictional"
            };

            var person145 = new Member
            {
                PersonId = 264,
                FirstName = "Puppy",
                LastName = "Cat",
                Zip = "32804",
                State = "FL",
                City = "Orlando",
                Address = "9987 My Street",
                Email = "Marceline@nowhere.com",
                Phone = "407.623.1507",
                ProfileImage = "Puppy_Cat.jpg",
                Tags = "animated, cat, fictional, villian" /* cuz the cat keeps her from living a normal life */
            };

            var person146 = new Member
            {
                PersonId = 265,
                FirstName = "Linda",
                LastName = "Belcher",
                Zip = "32804",
                State = "FL",
                City = "Orlando",
                Address = "9987 Cheezeburger Ave.",
                Email = "LindaB@nowhere.com",
                Phone = "407.623.1433",
                ProfileImage = "Linda_Belcher.jpg",
                Tags = "animated, chef, fictional"
            };

            var person147 = new Member
            {
                PersonId = 266,
                FirstName = "Brock",
                LastName = "Samson",
                Zip = "32804",
                State = "FL",
                City = "Orlando",
                Address = "9987 Monarch Way",
                Email = "BrockSamson@nowhere.com",
                Phone = "407.623.1893",
                ProfileImage = "Brock_Samson.jpeg",
                Tags = "animated, fictional, hero"
            };

            var person148 = new Member
            {
                PersonId = 267,
                FirstName = "Bat",
                LastName = "Commander",
                Zip = "32804",
                State = "FL",
                City = "Orlando",
                Address = "9987 Monarch Way",
                Email = "BatCommander@nowhere.com",
                Phone = "407.627.1896",
                ProfileImage = "Bat_Commander.jpg",
                Tags = "fictional, hero"
            };

            var person149 = new Member
            {
                PersonId = 268,
                FirstName = "Space",
                LastName = "Ghost",
                Zip = "32804",
                State = "FL",
                City = "Orlando",
                Address = "377 Unknown Planet Ave.",
                Email = "CoastToCoast@nowhere.com",
                Phone = "407.627.1896",
                ProfileImage = "Space_Ghost.jpg",
                Tags = "animated, fictional"
            };

            var person150 = new Member
            {
                PersonId = 269,
                FirstName = "Nutty",
                LastName = "Happy Tree",
                Zip = "32804",
                State = "FL",
                City = "Orlando",
                Address = "377 Happy Tree Friends Path",
                Email = "NuttyNutty@nowhere.com",
                Phone = "407.627.8796",
                ProfileImage = "Nutty_HappyTree.jpg",
                Tags = "animated, fictional"
            };

            var person151 = new Member
            {
                PersonId = 270,
                FirstName = "Henri",
                LastName = "Matisse",
                Zip = "02109",
                State = "MA",
                City = "Boston",
                Address = "1234 Cool Painting Ave.",
                Email = "HenriMatisse@nowhere.com",
                Phone = "857.627.8296",
                ProfileImage = "Henri_Matisse.jpg",
                Tags = "artist"
            };

            var person152 = new Member
            {
                PersonId = 271,
                FirstName = "Vincent",
                LastName = "Van Gogh",
                Zip = "02109",
                State = "MA",
                City = "Boston",
                Address = "1234 I Love Yellow St..",
                Email = "BuyMuhPaintinPlz@nowhere.com",
                Phone = "857.617.8296",
                ProfileImage = "Vincent_VanGogh.jpg",
                Tags = "artist"
            };

            var person153 = new Member
            {
                PersonId = 272,
                FirstName = "Paul",
                LastName = "Gauguin",
                Zip = "02109",
                State = "MA",
                City = "Boston",
                Address = "176 Left Right Court",
                Email = "PaulGauguinz@nowhere.com",
                Phone = "857.617.8296",
                ProfileImage = "Paul_Gauguin.jpg",
                Tags = "artist"
            };

            var person154 = new Member
            {
                PersonId = 273,
                FirstName = "Salvador",
                LastName = "Dali",
                Zip = "02109",
                State = "MA",
                City = "Boston",
                Address = "321 Havanah Road",
                Email = "Salvador1@nowhere.com",
                Phone = "857.617.8226",
                ProfileImage = "Salvador_Dali.jpg",
                Tags = "artist"
            };

            var person155 = new Member
            {
                PersonId = 274,
                FirstName = "Raffaello",
                LastName = "Sanzio",
                Zip = "02109",
                State = "MA",
                City = "Boston",
                Address = "3264 Big Fish Circle",
                Email = "Raffaello_Sanzio@nowhere.com",
                Phone = "857.617.8206",
                ProfileImage = "Raffaello_Sanzio.jpeg",
                Tags = "artist"
            };

            var person156 = new Member
            {
                PersonId = 275,
                FirstName = "Leonardo",
                LastName = "Da Vinci",
                Zip = "02109",
                State = "MA",
                City = "Boston",
                Address = "325 My Wayorthehighway Hwy.",
                Email = "DaVineFtwo@nowhere.com",
                Phone = "857.617.8206",
                ProfileImage = "Leonardo_Da_Vinci.jpg",
                Tags = "author, artist"
            };

            var person157 = new Member
            {
                PersonId = 276,
                FirstName = "Claude",
                LastName = "Monet",
                Zip = "02109",
                State = "MA",
                City = "Boston",
                Address = "3231 Soft Background St.",
                Email = "ClaudesGarden@nowhere.com",
                Phone = "857.617.8006",
                ProfileImage = "Claude_Monet.jpg",
                Tags = "artist, chef"
            };

            var person158 = new Member
            {
                PersonId = 277,
                FirstName = "Edvard",
                LastName = "Munch",
                Zip = "02109",
                State = "MA",
                City = "Boston",
                Address = "3235 Scream Bridge",
                Email = "IScreamUScream@nowhere.com",
                Phone = "857.697.8906",
                ProfileImage = "Edvard_Munch.jpg",
                Tags = "artist"
            };

            var person160 = new Member
            {
                PersonId = 279,
                FirstName = "Rene",
                LastName = "Magritte",
                Zip = "02109",
                State = "MA",
                City = "Boston",
                Address = "389 Art Fair Drive",
                Email = "ReneM@nowhere.com",
                Phone = "857.697.8906",
                ProfileImage = "Rene_Magritte.jpg",
                Tags = "artist"
            };

            var person161 = new Member
            {
                PersonId = 270,
                FirstName = "John",
                LastName = "McGuinness",
                Zip = "30302",
                State = "GA",
                City = "Atlanta",
                Address = "345 Iom Way",
                Email = "ReneM@nowhere.com",
                Phone = "407.197.8926",
                ProfileImage = "John_McGuinness.jpg",
                Tags = "athlete, racer"
            };

            var person162 = new Member
            {
                PersonId = 271,
                FirstName = "James",
                LastName = "Hillier",
                Zip = "30302",
                State = "GA",
                City = "Atlanta",
                Address = "3876 Podium Ave.",
                Email = "ImFastToo@nowhere.com",
                Phone = "407.197.9026",
                ProfileImage = "James_Hillier.jpg",
                Tags = "athlete, racer"
            };

            var person163 = new Member
            {
                PersonId = 272,
                FirstName = "Ian",
                LastName = "Hutchinson",
                Zip = "30302",
                State = "GA",
                City = "Atlanta",
                Address = "183 Bellaguire Road",
                Email = "OoohhhMyLegs@nowhere.com",
                Phone = "407.197.5026",
                ProfileImage = "Ian_Hutchinson.jpg",
                Tags = "athlete, racer"
            };

            var person164 = new Member
            {
                PersonId = 273,
                FirstName = "Guy",
                LastName = "Martin",
                Zip = "30302",
                State = "GA",
                City = "Atlanta",
                Address = "1313 Lorry Mech Road",
                Email = "RodeTheDragon@nowhere.com",
                Phone = "407.197.5124",
                ProfileImage = "Guy_Martin.jpg",
                Tags = "athlete, racer"
            };

            var person165 = new Member
            {
                PersonId = 274,
                FirstName = "Michael",
                LastName = "Dunlop",
                Zip = "30302",
                State = "GA",
                City = "Atlanta",
                Address = "1313 Kirkland Way",
                Email = "NoBmwForMe@nowhere.com",
                Phone = "407.197.5132",
                ProfileImage = "Michael_Dunlop.jpg",
                Tags = "athlete, racer"
            };

            var person166 = new Member
            {
                PersonId = 275,
                FirstName = "Connor",
                LastName = "Cummins",
                Zip = "30302",
                State = "GA",
                City = "Atlanta",
                Address = "9087 Bad Corner Ave.",
                Email = "LowSideTumble@nowhere.com",
                Phone = "407.192.5134",
                ProfileImage = "Connor_Cummins.jpg",
                Tags = "athlete, racer"
            };


            var person167 = new Member
            {
                PersonId = 276,
                FirstName = "Peter",
                LastName = "Hickman",
                Zip = "30302",
                State = "GA",
                City = "Atlanta",
                Address = "9287 Windy Corner",
                Email = "FasterFasterFaster@nowhere.com",
                Phone = "407.195.5154",
                ProfileImage = "Peter_Hickman.jpg",
                Tags = "athlete, racer"
            };

            var person168 = new Member
            {
                PersonId = 277,
                FirstName = "Bruce",
                LastName = "Anstey",
                Zip = "30302",
                State = "GA",
                City = "Atlanta",
                Address = "287 Classic Drive",
                Email = "FasterFasterFaster@nowhere.com",
                Phone = "407.195.5944",
                ProfileImage = "Bruce_Anstey.jpg",
                Tags = "athlete, racer"
            };

            var person169 = new Member
            {
                PersonId = 278,
                FirstName = "David",
                LastName = "Johnson",
                Zip = "30302",
                State = "GA",
                City = "Atlanta",
                Address = "2872 Wesphal Road",
                Email = "2Fast4U@nowhere.com",
                Phone = "407.195.0904",
                ProfileImage = "David_Johnson.jpg",
                Tags = "athlete, racer"
            };

            var person170 = new Member
            {
                PersonId = 279,
                FirstName = "Michael",
                LastName = "Rutter",
                Zip = "30302",
                State = "GA",
                City = "Atlanta",
                Address = "9843 Flying Cloud Drive",
                Email = "YamahahForMe@nowhere.com",
                Phone = "407.765.0564",
                ProfileImage = "Michael_Rutter.jpg",
                Tags = "athlete, racer"
            };

            var person171 = new Member
            {
                PersonId = 280,
                FirstName = "Sheev",
                LastName = "Palpatine",
                Zip = "55401",
                State = "MN",
                City = "Minneapolis",
                Address = "1 Coruscant Tower",
                Email = "DarthSidious@nowhere.com",
                Phone = "612.765.0564",
                ProfileImage = "Darth_Sidious.jpg",
                Tags = "animated, fictional, politician, sci-fi, villian"
            };

            var person172 = new Member
            {
                PersonId = 281,
                FirstName = "The",
                LastName = "Joker",
                Zip = "55401",
                State = "MN",
                City = "Minneapolis",
                Address = "23 Gotham St",
                Email = "HeyBatsy!@nowhere.com",
                Phone = "612.765.0514",
                ProfileImage = "The_Joker.jpg",
                Tags = "animated, fictional, video-game, villian"
            };

            var person173 = new Member
            {
                PersonId = 282,
                FirstName = "Ice",
                LastName = "King",
                Zip = "55401",
                State = "MN",
                City = "Minneapolis",
                Address = "234 Cold Castle Dr.",
                Email = "DateMePlz@nowhere.com",
                Phone = "612.765.0582",
                ProfileImage = "The_Ice_King.jpg",
                Tags = "animated, fictional, villian"
            };

            var person174 = new Member
            {
                PersonId = 283,
                FirstName = "Montgomery",
                LastName = "Burns",
                Zip = "55401",
                State = "MN",
                City = "Minneapolis",
                Address = "287 Power Plant Court",
                Email = "Excellent@nowhere.com",
                Phone = "612.765.0232",
                ProfileImage = "Montgomery_Burns.png",
                Tags = "animated, fictional, villian"
            };

            var person175 = new Member
            {
                PersonId = 284,
                FirstName = "Lord",
                LastName = "Voldemort",
                Zip = "55401",
                State = "MN",
                City = "Minneapolis",
                Address = "980 Dark Street",
                Email = "IHaveAnAwesomeSuit@nowhere.com",
                Phone = "612.765.1932",
                ProfileImage = "Lord_Voldemort.jpg",
                Tags = "fictional, villian"
            };

            var person176 = new Member
            {
                PersonId = 285,
                FirstName = "Snidely",
                LastName = "Whiplash",
                Zip = "55401",
                State = "MN",
                City = "Minneapolis",
                Address = "934 NellOnRailway Road",
                Email = "RockinTheStash@nowhere.com",
                Phone = "612.715.1122",
                ProfileImage = "Snidely_Whiplash.jpg",
                Tags = "animated, fictional, villian"
            };

            var person177 = new Member
            {
                PersonId = 286,
                FirstName = "Green",
                LastName = "Goblin",
                Zip = "55401",
                State = "MN",
                City = "Minneapolis",
                Address = "934 Can't Stop Me Hwy.",
                Email = "WashedTheSpiderOut@nowhere.com",
                Phone = "612.715.9122",
                ProfileImage = "Green_Goblin.jpg",
                Tags = "fictional, villian"
            };

            var person178 = new Member
            {
                PersonId = 287,
                FirstName = "Mojo",
                LastName = "Jojo",
                Zip = "55401",
                State = "MN",
                City = "Minneapolis",
                Address = "876 AndNothingNice St.",
                Email = "DoWhatISay@nowhere.com",
                Phone = "612.715.7122",
                ProfileImage = "Mojo_Jojo.jpg",
                Tags = "animated, fictional, villian"
            };

            var person179 = new Member
            {
                PersonId = 288,
                FirstName = "Rita",
                LastName = "Repulsa",
                Zip = "55401",
                State = "MN",
                City = "Minneapolis",
                Address = "234 Putty Patrol Ave.",
                Email = "MakeMyMonsterGrow@nowhere.com",
                Phone = "612.723.7492",
                ProfileImage = "Rita_Repulsa.jpg",
                Tags = "fictional, villian"
            };

            var person180 = new Member
            {
                PersonId = 289,
                FirstName = "Majin",
                LastName = "Buu",
                Zip = "55401",
                State = "MN",
                City = "Minneapolis",
                Address = "765 Candy Lane",
                Email = "IWantCandy@nowhere.com",
                Phone = "612.722.7412",
                ProfileImage = "Magin_Buu.jpg",
                Tags = "animated, fictional, villian" /* villian until rehabilitated by 'The Champ' */
            };

            var person181 = new Member
            {
                PersonId = 290,
                FirstName = "Jean",
                LastName = "Valjean",
                Zip = "55424",
                State = "MN",
                City = "Ednia",
                Address = "1232 Rue Jacques Eyves",
                Email = "ClothFactory1@nowhere.com",
                Phone = "952.329.0578",
                ProfileImage = "Jean_Valjean.jpg",
                Tags = "fictional, hero"
            };

            var person182 = new Member
            {
                PersonId = 291,
                FirstName = "Frodo",
                LastName = "Baggins",
                Zip = "55424",
                State = "MN",
                City = "Ednia",
                Address = "12 Bag End",
                Email = "NothingExcitingEver@nowhere.com",
                Phone = "952.329.0378",
                ProfileImage = "Frodo_Baggins.jpg",
                Tags = "fictional, hero"
            };

            var person183 = new Member
            {
                PersonId = 292,
                FirstName = "King",
                LastName = "Leonidas",
                Zip = "55424",
                State = "MN",
                City = "Ednia",
                Address = "236 Hot Gates Road",
                Email = "Spartans!@nowhere.com",
                Phone = "952.322.0313",
                ProfileImage = "King_Leonidas.jpg",
                Tags = "hero, politician"
            };

            var person184 = new Member
            {
                PersonId = 293,
                FirstName = "Captain",
                LastName = "Falcon",
                Zip = "55424",
                State = "MN",
                City = "Ednia",
                Address = "1252 F-Zero Race Track",
                Email = "Capt-SmashBros@nowhere.com",
                Phone = "952.322.0293",
                ProfileImage = "Captain_Falcon.jpg",
                Tags = "fictional, hero, racer, video-game"
            };

            var person185 = new Member
            {
                PersonId = 294,
                FirstName = "The",
                LastName = "Champ",
                Zip = "55424",
                State = "MN",
                City = "Ednia",
                Address = "1267 Tamatsukuri 26",
                Email = "TheFansKnowTheChamp@nowhere.com",
                Phone = "952.322.8793",
                ProfileImage = "The_Champ.jpg",
                Tags = "animated, fictional, hero"
            };

            var person186 = new Member
            {
                PersonId = 295,
                FirstName = "Dwight",
                LastName = "McCarthy",
                Zip = "55424",
                State = "MN",
                City = "Ednia",
                Address = "1267 Tamatsukuri 26",
                Email = "JustAnAvgGuy@nowhere.com",
                Phone = "952.322.8793",
                ProfileImage = "Dwight_McCarthy.jpg",
                Tags = "fictional" /* neither hero nor villian */
            };

            var person187 = new Member
            {
                PersonId = 296,
                FirstName = "Roy",
                LastName = "Lichtenstein",
                Zip = "55424",
                State = "MN",
                City = "Ednia",
                Address = "1267 Denmark Blvd.",
                Email = "ImmuArtistYo@nowhere.com",
                Phone = "952.322.8003",
                ProfileImage = "Roy_Lichtenstein.jpg",
                Tags = "artist"
            };

            var person188 = new Member
            {
                PersonId = 297,
                FirstName = "Under",
                LastName = "Dog",
                Zip = "55424",
                State = "MN",
                City = "Ednia",
                Address = "1234 Humble Lane",
                Email = "ShoeShineBoy@nowhere.com",
                Phone = "952.322.8003",
                ProfileImage = "Under_Dog.jpg",
                Tags = "animated, fictional, hero"
            };

            var person189 = new Member
            {
                PersonId = 298,
                FirstName = "Master",
                LastName = "Chief",
                Zip = "55424",
                State = "MN",
                City = "Ednia",
                Address = "Classified",
                Email = "John-117@nowhere.com",
                Phone = string.Empty,
                ProfileImage = "Master_Chief.jpg",
                Tags = "fictional, hero, sci-fi, video-game"
            };

            var person190 = new Member
            {
                PersonId = 299,
                FirstName = "Gordon",
                LastName = "Freeman",
                Zip = "55424",
                State = "MN",
                City = "Ednia",
                Address = "1234 Black Mesa Research Lab",
                Email = "QuantamPhysFTW@nowhere.com",
                Phone = "952.324.2303",
                ProfileImage = "Gordon_Freeman.png",
                Tags = "fictional, hero, sci-fi, video-game"
            };

            var person191 = new Member
            {
                PersonId = 300,
                FirstName = "Naomi",
                LastName = "Uemura",
                Zip = "92113",
                State = "CA",
                City = "San Diego",
                Address = "9876 Mt. McKinley Drive",
                Email = "ColdClimber@nowhere.com",
                Phone = "619.324.2303",
                ProfileImage = "Naomi_Uemura.jpg",
                Tags = "athlete, explorer"
            };

            var person192 = new Member
            {
                PersonId = 301,
                FirstName = "Hyoichi",
                LastName = "Kono",
                Zip = "92113",
                State = "CA",
                City = "San Diego",
                Address = "926 Peddle Around Circle",
                Email = "BikeAroundJapan@nowhere.com",
                Phone = "619.324.1303",
                ProfileImage = "Hyoichi_Kono.jpg",
                Tags = "athlete, explorer"
            };

            var person193 = new Member
            {
                PersonId = 302,
                FirstName = "Mamiya",
                LastName = "Rinzo",
                Zip = "92113",
                State = "CA",
                City = "San Diego",
                Address = "9245 Info For Sale St.",
                Email = "IslandHopper@nowhere.com",
                Phone = "619.324.1398",
                ProfileImage = "Mamiya_Rinzo.jpg",
                Tags = "explorer"
            };

            var person194 = new Member
            {
                PersonId = 303,
                FirstName = "Mori",
                LastName = "Koben",
                Zip = "92113",
                State = "CA",
                City = "San Diego",
                Address = "9236 Micronesia Way",
                Email = "TrukChuukWow!@nowhere.com",
                Phone = "619.324.1092",
                ProfileImage = "Mori_Koben.jpg",
                Tags = "explorer"
            };

            var person195 = new Member
            {
                PersonId = 304,
                FirstName = "Shirase",
                LastName = "Nobu",
                Zip = "92113",
                State = "CA",
                City = "San Diego",
                Address = "9223 Freezing Cold Lane",
                Email = "AntarticExplorer@nowhere.com",
                Phone = "619.323.1792",
                ProfileImage = "Shirase_Nobu.jpg",
                Tags = "athlete, explorer"
            };

            var person196 = new Member
            {
                PersonId = 305,
                FirstName = "Zuicho",
                LastName = "Tachibana",
                Zip = "92113",
                State = "CA",
                City = "San Diego",
                Address = "126 South Asia Circle",
                Email = "ZuchioTravels@nowhere.com",
                Phone = "619.323.9092",
                ProfileImage = "Zuicho_Tachibana.jpg",
                Tags = "explorer"
            };

            var person197 = new Member
            {
                PersonId = 306,
                FirstName = "Tanaka",
                LastName = "Shosuke",
                Zip = "92113",
                State = "CA",
                City = "San Diego",
                Address = "789 Rome Visitation Hwy",
                Email = "FullOfGrace@nowhere.com",
                Phone = "619.323.9292",
                ProfileImage = "Tanaka_Shosuke.jpg",
                Tags = "explorer, hero"
            };

            var person198 = new Member
            {
                PersonId = 307,
                FirstName = "Tenjiku",
                LastName = "Tokubei",
                Zip = "92113",
                State = "CA",
                City = "San Diego",
                Address = "9834 Sino Street",
                Email = "WillTravel1600s@nowhere.com",
                Phone = "619.324.3092",
                ProfileImage = "Tenjiku_Tokubei.jpg",
                Tags = "explorer"
            };

            var person199 = new Member
            {
                PersonId = 308,
                FirstName = "Yamada",
                LastName = "Nagamasa",
                Zip = "92113",
                State = "CA",
                City = "San Diego",
                Address = "924 Mountain Circle",
                Email = "WillTravel1600s@nowhere.com",
                Phone = "619.324.3092",
                ProfileImage = "Yamada_Nagamasa.jpg",
                Tags = "explorer"
            };

            var person200 = new Member
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

            var person201 = new Member
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

            var person202 = new Member
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

            var person203 = new Member
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

            var person204 = new Member
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
                ProfileImage = "Hondo_Ohnaka.jpg",
                Tags = "animated, fictional, sci-fi, villian" /* though a useful villian */
            };

            var person205 = new Member
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

            var person206 = new Member
            {
                PersonId = 315,
                FirstName = "Mother",
                LastName = "Talzin",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "223 Magics Circle",
                Email = "MotherTalzin@nowhere.com",
                Phone = "425.905.9852",
                ProfileImage = "Mother_Talzin.jpg",
                Tags = "animated, fictional, sci-fi, villian"
            };

            var person207 = new Member
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
                ProfileImage = "Savage_Opress.jpg",
                Tags = "animated, fictional, sci-fi, villian"
            };

            var person208 = new Member
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

            var person209 = new Member
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

            var person210 = new Member
            {
                PersonId = 319,
                FirstName = "Don",
                LastName = "Diego de la Vega",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "2234 Zapata Drive",
                Email = "TheBladeSpeaks@nowhere.com",
                Phone = "425.905.6176",
                ProfileImage = "Don_Diego.jpg",
                Tags = "fictional, hero"
            };

            var person211 = new Member
            {
                PersonId = 320,
                FirstName = "Vanellope",
                LastName = "Von Schweetz",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "7659 Sugar Rush Mountain Rd.",
                Email = "Glitchin@nowhere.com",
                Phone = "425.905.9196",
                ProfileImage = "Vanellapoe_VonSchweets.jpg",
                Tags = "animated, fictional, racer, video-game"
            };

            var person212 = new Member
            {
                PersonId = 321,
                FirstName = "Iroh",
                LastName = "Ozai",
                Zip = "98007",
                State = "WA",
                City = "Bellevue",
                Address = "9876 Fire Lord Ave.",
                Email = "HaveSomeTea@nowhere.com",
                Phone = "425.905.9196",
                ProfileImage = "Iroh_Ozai.jpg",
                Tags = "animated, fictional, hero"
            };

            var person213 = new Member
            {
                PersonId = 322,
                FirstName = "Taku",
                LastName = "Morisaki",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "Ipponmatsu Nishioya 76542",
                Email = "TakuM@nowhere.com",
                Phone = "305.295.9196",
                ProfileImage = "Taku_Morisaki.jpg",
                Tags = string.Empty
            };

            var person214 = new Member
            {
                PersonId = 323,
                FirstName = "Rikako",
                LastName = "Muto",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "Nishikawagoe 16 9872",
                Email = "RikakoMuto@nowhere.com",
                Phone = "305.295.9172",
                ProfileImage = "Rikako_Muto.jpg",
                Tags = string.Empty
            };


            var person215 = new Member
            {
                PersonId = 324,
                FirstName = "Ai",
                LastName = "Sato",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "Bushu Karasawa 298 1238",
                Email = "AiSatoTravlinGurl@nowhere.com",
                Phone = "305.295.9242",
                ProfileImage = "Ai_Sato.jpg",
                Tags = string.Empty
            };

            var person216 = new Member
            {
                PersonId = 325,
                FirstName = "Green",
                LastName = "Jeans",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "3455 Green Plants Dr.",
                Email = "MrGreenJeans@nowhere.com",
                Phone = "305.295.9112",
                ProfileImage = "Green_Jeans.gif",
                Tags = "farmer, fictional"
            };

            var person217 = new Member
            {
                PersonId = 326,
                FirstName = "Captain",
                LastName = "Kangaroo",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "445 Childrens Network Dr.",
                Email = "DutchHaircutsFTW@nowhere.com",
                Phone = "305.295.9112",
                ProfileImage = "Captain_Kangaroo.jpg",
                Tags = "fictional"
            };

            var person218 = new Member
            {
                PersonId = 327,
                FirstName = "Jaques",
                LastName = "Mayol",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "345 Inner Dolphin Canal",
                Email = "BigBlueW@nowhere.com",
                Phone = "305.295.9112",
                ProfileImage = "Jacques_Mayol.jpg",
                Tags = "athlete"
            };

            var person219 = new Member
            {
                PersonId = 328,
                FirstName = "Dig",
                LastName = "Dug",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "323 Underground Tunnel",
                Email = "DiggingMore@nowhere.com",
                Phone = "305.295.8792",
                ProfileImage = "Dig_Dug.png",
                Tags = "fictional, video-game"
            };

            var person220 = new Member
            {
                PersonId = 329,
                FirstName = "Strong",
                LastName = "Bad",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "313 Homestar Runner Ave.",
                Email = "AnsweringMail@nowhere.com",
                Phone = "305.225.8792",
                ProfileImage = "Strong_Bad.png",
                Tags = "animated, fictional"
            };

            var person221 = new Member
            {
                PersonId = 330,
                FirstName = "Chi",
                LastName = "Chi",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "3872 Dragonball Lane",
                Email = "USeenGohan@nowhere.com",
                Phone = "305.225.8792",
                ProfileImage = "Chi_Chi.jpg",
                Tags = "animated, fictional"
            };

            var person222 = new Member
            {
                PersonId = 331,
                FirstName = "Boris",
                LastName = "Almazov",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "987 Doctor Drive",
                Email = "TheHeavy@nowhere.com",
                Phone = "305.225.8442",
                ProfileImage = "Boris_Almazov.jpg",
                Tags = "fictional, video-game"
            };

            var person223 = new Member
            {
                PersonId = 332,
                FirstName = "Joey",
                LastName = "Buildison",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "7765 Sentry Road",
                Email = "TheEngineer@nowhere.com",
                Phone = "305.225.8442",
                ProfileImage = "The_Engineerl.jpg",
                Tags = "fictional, video-game"
            };

            var person224 = new Member
            {
                PersonId = 333,
                FirstName = "Team",
                LastName = "Rocket",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "123 Prepare For Trouble Arena",
                Email = "MakeItDouble@nowhere.com",
                Phone = "305.225.8442",
                ProfileImage = "Team_Rocket.jpg",
                Tags = "animated, fictional, villian"
            };

            var person225 = new Member
            {
                PersonId = 334,
                FirstName = "Bing",
                LastName = "Bong",
                Zip = "33126",
                State = "FL",
                City = "Miami",
                Address = "876 Long Term Memory Lane",
                Email = "BingBongBingBong@nowhere.com",
                Phone = "305.225.8442",
                ProfileImage = "Bing_Bong.jpg",
                Tags = "animated, fictional, hero"
            };

            var person226 = new Member
            {
                PersonId = 335,
                FirstName = "Douglas",
                LastName = "Crockford",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "122 Javascript Founder Rd.",
                Email = "InventedJSON@nowhere.com",
                Phone = "205.845.3432",
                ProfileImage = "Douglas_Crockford.jpg",
                Tags = "techie"
            };

            var person227 = new Member
            {
                PersonId = 336,
                FirstName = "Doctor",
                LastName = "Facilier",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "1212 Bayou Blvd.",
                Email = "ShadowMan@nowhere.com",
                Phone = "205.845.3498",
                ProfileImage = "Doctor_Facilier.jpg",
                Tags = "animated, fictional, villian"
            };

            var person228 = new Member
            {
                PersonId = 337,
                FirstName = "Brendan",
                LastName = "Eich",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "111 Invented JS St.",
                Email = "BrendanEich@nowhere.com",
                Phone = "205.845.5698",
                ProfileImage = "Brendan_Eich.jpg",
                Tags = "techie"
            };

            var person229 = new Member
            {
                PersonId = 338,
                FirstName = "Meat",
                LastName = "Boy",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "1232 Obstacle Ave.",
                Email = "SuperMeatBoy@nowhere.com",
                Phone = "205.845.1108",
                ProfileImage = "Meat_Boy.jpg",
                Tags = "animated, fictional, hero, video-game"
            };

            var person230 = new Member
            {
                PersonId = 339,
                FirstName = "Leonhard",
                LastName = "Euler",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "1234 Da Math Rd.",
                Email = "QuoteEulerSoundSmart@nowhere.com",
                Phone = "205.845.1608",
                ProfileImage = "Leonhard_Euler.jpeg",
                Tags = "techie" /* because math is techie */
            };

            var person231 = new Member
            {
                PersonId = 340,
                FirstName = "Theodor",
                LastName = "Geisel",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "1234 Hop On Pop Road.",
                Email = "DrSuess@nowhere.com",
                Phone = "205.845.1633",
                ProfileImage = "Theodor_Geisel.jpg",
                Tags = "author, artist, animated"
            };

            var person232 = new Member
            {
                PersonId = 341,
                FirstName = "Cheshire",
                LastName = "Cat",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "234 This Way.",
                Email = "OrThatWay@nowhere.com",
                Phone = "205.845.1272",
                ProfileImage = "Cheshire_Cat.jpg",
                Tags = "animated, cat"
            };

            var person233 = new Member
            {
                PersonId = 342,
                FirstName = "Monorail",
                LastName = "Cat",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "224 Speedy Service",
                Email = "MonorailCat@nowhere.com",
                Phone = "205.825.1274",
                ProfileImage = "Monorail_Cat.jpg",
                Tags = "cat"
            };

            var person234 = new Member
            {
                PersonId = 343,
                FirstName = "Chesty",
                LastName = "Puller",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "223 Valor Dr.",
                Email = "ProblemSimplified@nowhere.com",
                Phone = "205.835.1274",
                ProfileImage = "Chesty_Puller.jpg",
                Tags = "hero"
            };

            var person235 = new Member
            {
                PersonId = 344,
                FirstName = "Fail",
                LastName = "Boat",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "223 All Aboard Plank",
                Email = "FailBoat@nowhere.com",
                Phone = "205.825.1904",
                ProfileImage = "Fail_Boat.jpg",
                Tags = string.Empty
            };

            var person236 = new Member
            {
                PersonId = 345,
                FirstName = "Olive",
                LastName = "Oyl",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "2183 Two Time Ave.",
                Email = "MissOyl@nowhere.com",
                Phone = "205.878.1904",
                ProfileImage = "Olive_Oyl.jpg",
                Tags = "animated, fictional"
            };

            var person237 = new Member
            {
                PersonId = 346,
                FirstName = "Count",
                LastName = "Chocula",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "2233 Monster Cereal Ave.",
                Email = "CountChocula@nowhere.com",
                Phone = "205.878.1904",
                ProfileImage = "Count_Chocula.jpg",
                Tags = string.Empty
            };

            var person238 = new Member
            {
                PersonId = 347,
                FirstName = "Foghorn",
                LastName = "Leghorn",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "236 I Say I Say",
                Email = "HenHouseMan@nowhere.com",
                Phone = "205.818.1904",
                ProfileImage = "Foghorn_Leghorn.jpg",
                Tags = "animated, fictional"
            };

            var person239 = new Member
            {
                PersonId = 348,
                FirstName = "Lyudmila",
                LastName = "Pavlichenko",
                Zip = "35211",
                State = "AL",
                City = "Birmingham",
                Address = "238 Motherland Rd.",
                Email = "Lyudmila_P@nowhere.com",
                Phone = "205.818.0904",
                ProfileImage = "Lyudmila_Pavlichenko.jpg",
                Tags = "hero"
            };

            var person240 = new Member
            {
                PersonId = 349,
                FirstName = "Betty",
                LastName = "Rubble",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "238 Bedrock Hwy",
                Email = "Lyudmila_P@nowhere.com",
                Phone = "206.313.0904",
                ProfileImage = "Betty_Rubble.jpg",
                Tags = "animated, fictional"
            };

            var person241 = new Member
            {
                PersonId = 350,
                FirstName = "Simo",
                LastName = "Hayha",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "223 Boreal Forest Road",
                Email = "WhiteDeath@nowhere.com",
                Phone = "206.313.0904",
                ProfileImage = "Simo_Hayha.jpg",
                Tags = "hero"
            };

            var person242 = new Member
            {
                PersonId = 351,
                FirstName = "Harmon",
                LastName = "Killebrew",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "9876 Home Run Court",
                Email = "HarmonKillebrew@nowhere.com",
                Phone = "206.313.0114",
                ProfileImage = "Harmon_killebrew.jpg",
                Tags = "athlete"
            };

            var person243 = new Member
            {
                PersonId = 352,
                FirstName = "Rod",
                LastName = "Carew",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "9236 Home Run Court",
                Email = "RodCarew@nowhere.com",
                Phone = "206.313.0754",
                ProfileImage = "Rod_Carew.jpg",
                Tags = "athlete"
            };

            var person244 = new Member
            {
                PersonId = 353,
                FirstName = "Emily",
                LastName = "Dickinson",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "928 Bitter Spinster Dr",
                Email = "ComplainDontAct@nowhere.com",
                Phone = "206.613.0334",
                ProfileImage = "Emily_Dickinson.jpg",
                Tags = "author"
            };

            var person245 = new Member
            {
                PersonId = 354,
                FirstName = "Robert",
                LastName = "Frost",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "345 Write Way",
                Email = "RobertFrost@nowhere.com",
                Phone = "206.613.0334",
                ProfileImage = "Robert_Frost.jpg",
                Tags = "author"
            };

            var person246 = new Member
            {
                PersonId = 355,
                FirstName = "William",
                LastName = "Wordsworth",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "3865 Ancient Mariner Circle",
                Email = "NineFathoms@nowhere.com",
                Phone = "206.653.0334",
                ProfileImage = "William_Wordsworth.jpg",
                Tags = "author"
            };

            var person247 = new Member
            {
                PersonId = 356,
                FirstName = "Fanny",
                LastName = "Crosby",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "3398 Songbird Dr.",
                Email = "SongAndHymms@nowhere.com",
                Phone = "206.653.0834",
                ProfileImage = "Fanny_Crosby.png",
                Tags = "author"
            };

            var person248 = new Member
            {
                PersonId = 357,
                FirstName = "Oscar",
                LastName = "Hammerstien",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "376 SHowtunes Ave.",
                Email = "SnappyTunes@nowhere.com",
                Phone = "206.613.0834",
                ProfileImage = "Oscar_Hammerstien.jpg",
                Tags = "author"
            };

            var person249 = new Member
            {
                PersonId = 358,
                FirstName = "Nikola",
                LastName = "Tesla",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "3236 Electric Drive",
                Email = "ReThinkEverything@nowhere.com",
                Phone = "206.613.7734",
                ProfileImage = "Nikola_Tesla.jpg",
                Tags = "techie"
            };

            var person250 = new Member
            {
                PersonId = 359,
                FirstName = "Harry",
                LastName = "Houdini",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "326 Get Out Of This St.",
                Email = "HeyWatchThis@nowhere.com",
                Phone = "206.613.7714",
                ProfileImage = "Harry_Houdini.jpg",
                Tags = string.Empty
            };

            var person251 = new Member
            {
                PersonId = 360,
                FirstName = "Samuel",
                LastName = "Clemens",
                Zip = "98102",
                State = "WA",
                City = "Seattle",
                Address = "323 Mark Twain Blvd",
                Email = "AdvOfHuckFinn@nowhere.com",
                Phone = "206.663.7714",
                ProfileImage = "Samuel_Clemens.jpg",
                Tags = "author"
            };

            var person252 = new Member
            {
                PersonId = 361,
                FirstName = "Tide",
                LastName = "Hunter",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "324 The Shallows Blvd",
                Email = "TideHunter@nowhere.com",
                Phone = "334.863.7334",
                ProfileImage = "Tide_Hunter.jpg",
                Tags = "fictional, video-game"
            };

            var person253 = new Member
            {
                PersonId = 362,
                FirstName = "Ai",
                LastName = "Fukuhara",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "3223 Plantation Road",
                Email = "Ai_Fukuhara@nowhere.com",
                Phone = "334.863.7335",
                ProfileImage = "Ai_Fukuhara.jpg",
                Tags = "athlete"
            };

            var person254 = new Member
            {
                PersonId = 363,
                FirstName = "Sayuri",
                LastName = "Shimada",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "3223 Tobacco Road",
                Email = "Ai_Fukuhara@nowhere.com",
                Phone = "334.863.7355",
                ProfileImage = "Sayuri_Shimada.jpg",
                Tags = "athlete"
            };

            var person255 = new Member
            {
                PersonId = 364,
                FirstName = "Sayuri",
                LastName = "Kimura",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "3224 Tobacco Road",
                Email = "SayuriKimura@nowhere.com",
                Phone = "334.863.7355",
                ProfileImage = "Sayuri_Kimura.jpg",
                Tags = "athlete"
            };

            var person256 = new Member
            {
                PersonId = 365,
                FirstName = "Sakoda",
                LastName = "Saori",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "3229 Tobacco Road",
                Email = "SayuriKimura@nowhere.com",
                Phone = "334.863.7055",
                ProfileImage = "Sakoda_Saori.jpg",
                Tags = "athlete"
            };

            var person257 = new Member
            {
                PersonId = 366,
                FirstName = "Captain",
                LastName = "Keyes",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "3234 Halcyon-class Ave.",
                Email = "PillarOfAutumn@nowhere.com",
                Phone = "334.863.7055",
                ProfileImage = "Captain_Keyes.jpg",
                Tags = "athlete"
            };

            var person258 = new Member
            {
                PersonId = 367,
                FirstName = "Gaston",
                LastName = "LeGume",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "3234 Provincial St.",
                Email = "GladToMeetMe@nowhere.com",
                Phone = "334.863.1055",
                ProfileImage = "Gaston_LeGume.jpg",
                Tags = "animated, fictional, hero, villian"
            };

            var person259 = new Member
            {
                PersonId = 368,
                FirstName = "Natasha",
                LastName = "Badenov",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "3234 Potsylvania Blvd.",
                Email = "IsMooseAndSquirrel@nowhere.com",
                Phone = "334.863.1959",
                ProfileImage = "Natasha_Badenov.jpg",
                Tags = "animated, fictional, villian"
            };

            var person260 = new Member
            {
                PersonId = 369,
                FirstName = "Sigmund",
                LastName = "Ooze",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "1434 Beach Court",
                Email = "OozeForMayor@nowhere.com",
                Phone = "334.863.1959",
                ProfileImage = "Sigmund_Ooze.jpg",
                Tags = "animated, fictional"
            };

            var person261 = new Member
            {
                PersonId = 370,
                FirstName = "Ryoko",
                LastName = "Kobayashi",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "1423 For The Win St.",
                Email = "Ryoko_Kobayashi@nowhere.com",
                Phone = "334.863.1959",
                ProfileImage = "Ryoko_Kobayashi.jpg",
                Tags = "athlete"
            };

            var person262 = new Member
            {
                PersonId = 371,
                FirstName = "Sachi",
                LastName = "Mochida",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "199 Old Plantation Dr.",
                Email = "Ryoko_Kobayashi@nowhere.com",
                Phone = "334.863.1959",
                ProfileImage = "Sachi_Mochida.jpg",
                Tags = "athlete"
            };

            var person263 = new Member
            {
                PersonId = 372,
                FirstName = "Tomomi",
                LastName = "Nishimura",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "231 Cypress Knee Road",
                Email = "Tomomi_Nishimura@nowhere.com",
                Phone = "334.863.8859",
                ProfileImage = "Tomomi_Nishimura.jpg",
                Tags = string.Empty
            };

            var person264 = new Member
            {
                PersonId = 373,
                FirstName = "Sayane",
                LastName = "Ueno",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "256 Cypress Knee Road",
                Email = "SayaneUeno@nowhere.com",
                Phone = "334.863.8099",
                ProfileImage = "Sayane_Ueno.jpg",
                Tags = string.Empty
            };

            var person265 = new Member
            {
                PersonId = 374,
                FirstName = "Yui",
                LastName = "Yamane",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "1356 Lemonade Ice Road",
                Email = "Yui_Yamane@nowhere.com",
                Phone = "334.863.8099",
                ProfileImage = "Yui_Yamane.jpg",
                Tags = string.Empty
            };


            var person266 = new Member
            {
                PersonId = 375,
                FirstName = "Ayane",
                LastName = "Matsunaga",
                Zip = "36110",
                State = "AL",
                City = "Montgomery",
                Address = "1356 Lemonade Ice Road",
                Email = "Ayane_Matsunaga@nowhere.com",
                Phone = "334.863.8099",
                ProfileImage = "Ayane_Matsunaga.jpg",
                Tags = "animated, fictional"
            };

            var person267 = new Member
            {
                PersonId = 376,
                FirstName = "Ayane",
                LastName = "Kozasa",
                Zip = "01014",
                State = "MA",
                City = "Chicopee",
                Address = "2456 Kennedy Dr.",
                Email = "Ayane_Matsunaga@nowhere.com",
                Phone = "413.263.8099",
                ProfileImage = "Ayane_Kozasa.jpg",
                Tags = "artist"
            };

            var person268 = new Member
            {
                PersonId = 377,
                FirstName = "Aki",
                LastName = "Syoko",
                Zip = "01014",
                State = "MA",
                City = "Chicopee",
                Address = "2456 Kennedy Dr.",
                Email = "Aki_Music@nowhere.com",
                Phone = "413.263.8199",
                ProfileImage = "Aki_Syoko.jpg",
                Tags = "artist"
            };

            var person269 = new Member
            {
                PersonId = 378,
                FirstName = "Noriko",
                LastName = "Sumiyoshi",
                Zip = "01014",
                State = "MA",
                City = "Chicopee",
                Address = "1396 Atlantic Ave",
                Email = "Noriko_Jams4U@nowhere.com",
                Phone = "413.263.1190",
                ProfileImage = "Noriko_Sumiyoshi.jpg",
                Tags = "artist"
            };

            var person270 = new Member
            {
                PersonId = 379,
                FirstName = "Ivan",
                LastName = "Ooze",
                Zip = "01014",
                State = "MA",
                City = "Chicopee",
                Address = "1391 Ooze Avenue",
                Email = "Oooozzeeee@nowhere.com",
                Phone = "413.263.1190",
                ProfileImage = "Ivan_Ooze.jpg",
                Tags = "fictional, villian"
            };

            var person271 = new Member
            {
                PersonId = 380,
                FirstName = "Darth",
                LastName = "Plagueis",
                Zip = "01014",
                State = "MA",
                City = "Chicopee",
                Address = "1434 Muun Road",
                Email = "Hego_Damask@nowhere.com",
                Phone = "413.263.0990",
                ProfileImage = "Darth_Plagueis.jpg",
                Tags = "author, animated, fictional, sci-fi, techie, villian"
            };

            var person272 = new Member
            {
                PersonId = 381,
                FirstName = "Toothy",
                LastName = "Beaver",
                Zip = "01014",
                State = "MA",
                City = "Chicopee",
                Address = "1434 Muun Road",
                Email = "HappyTreeFriends@nowhere.com",
                Phone = string.Empty,
                ProfileImage = "Toothy_Beaver.jpg",
                Tags = "animated, fictional"
            };

            var person273 = new Member
            {
                PersonId = 382,
                FirstName = "Anton",
                LastName = "Chigurh",
                Zip = "01014",
                State = "MA",
                City = "Chicopee",
                Address = "Parts Unknown",
                Email = string.Empty,
                Phone = string.Empty,
                ProfileImage = "Anton_Chigurh.jpg",
                Tags = "fictional, villian"
            };

            var person274 = new Member
            {
                PersonId = 383,
                FirstName = "Toucan",
                LastName = "Sam",
                Zip = "01014",
                State = "MA",
                City = "Chicopee",
                Address = "765 Rain Forest Dr.",
                Email = "FootLoopsFTW@nowhere.com",
                Phone = "413.234.6590",
                ProfileImage = "Toucan_Sam.jpg",
                Tags = string.Empty
            };

            var person275 = new Member
            {
                PersonId = 384,
                FirstName = "Ryan",
                LastName = "Dahl",
                Zip = "01014",
                State = "MA",
                City = "Chicopee",
                Address = "129 Javascript Server Dr.",
                Email = "InventedNodeJs@nowhere.com",
                Phone = "413.234.6980",
                ProfileImage = "Ryan_Dahl.jpg",
                Tags = "techie"
            };

            var person276 = new Member
            {
                PersonId = 385,
                FirstName = "Lucy",
                LastName = "Wilde",
                Zip = "01014",
                State = "MA",
                City = "Chicopee",
                Address = "247 Anti-Villain League St.",
                Email = "LucyWilde@nowhere.com",
                Phone = "413.234.3980",
                ProfileImage = "Lucy_Wilde.jpg",
                Tags = "animated, fictional, hero"
            };


            var person277 = new Member
            {
                PersonId = 386,
                FirstName = "Chinatsu",
                LastName = "Hattori",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "2345 Atlantic Bay Ct.",
                Email = "Chinatsu123@nowhere.com",
                Phone = "914.934.3980",
                ProfileImage = "Chinatsu_Hattori.jpg",
                Tags = string.Empty
            };

            var person278 = new Member
            {
                PersonId = 387,
                FirstName = "Kaho",
                LastName = "Gotou",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "554 West 2nd Ave",
                Email = "Chinatsu123@nowhere.com",
                Phone = "914.934.3180",
                ProfileImage = "Kaho_Gotou.jpg",
                Tags = string.Empty
            };

            var person279 = new Member
            {
                PersonId = 388,
                FirstName = "Miki",
                LastName = "Uchida",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "559 West 2nd Ave",
                Email = "Miki_Uchidag@nowhere.com",
                Phone = "914.934.6180",
                ProfileImage = "Miki_Uchida.jpg",
                Tags = string.Empty
            };

            var person280 = new Member
            {
                PersonId = 389,
                FirstName = "Business",
                LastName = "Cat",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "5249 All Business St.",
                Email = "AllBiznisAllDaTime@nowhere.com",
                Phone = "914.934.1170",
                ProfileImage = "Business_Cat.jpg",
                Tags = "cat"
            };

            var person281 = new Member
            {
                PersonId = 390,
                FirstName = "Epic",
                LastName = "Squirrel",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "5234 Save The Day St.",
                Email = "WhereverIsNeed@nowhere.com",
                Phone = "914.934.1270",
                ProfileImage = "Epic_Squirrel.jpg",
                Tags = "hero"
            };

            var person282 = new Member
            {
                PersonId = 391,
                FirstName = "Keyboard",
                LastName = "Cat",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "136 Play Em Off Dr.",
                Email = "KeyboardCat@nowhere.com",
                Phone = "914.934.1270",
                ProfileImage = "Keyboard_Cat.jpg",
                Tags = "cat"
            };

            var person283 = new Member
            {
                PersonId = 392,
                FirstName = "Techno",
                LastName = "Viking",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "1234 Give Me Water",
                Email = "TechnoDance@nowhere.com",
                Phone = "914.934.1272",
                ProfileImage = "Techno_Viking.jpg",
                Tags = string.Empty
            };

            var person284 = new Member
            {
                PersonId = 393,
                FirstName = "Edna",
                LastName = "Krabappel",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "744 Evergreen Terrace",
                Email = "EdnaK@SpringfieldElementary.com",
                Phone = "914.934.1299",
                ProfileImage = "Edna_Krabappel.jpg",
                Tags = "animated, fictional"
            };

            var person285 = new Member
            {
                PersonId = 394,
                FirstName = "Colonel",
                LastName = "Meow",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "723 Evergreen Terrace",
                Email = "Colonel_Meow@nowhere.com",
                Phone = "914.934.1899",
                ProfileImage = "Colonel_Meow.jpg",
                Tags = "cat"
            };

            var person286 = new Member
            {
                PersonId = 395,
                FirstName = "Colonel",
                LastName = "Klink",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "729 Stalag Thirteen Dr.",
                Email = "Colonel_Klink@nowhere.com",
                Phone = "914.914.1809",
                ProfileImage = "Colonel_Klink.jpeg",
                Tags = "fictional"
            };

            var person287 = new Member
            {
                PersonId = 396,
                FirstName = "Racer",
                LastName = "X",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "729 Speedway Road",
                Email = "RacerX@nowhere.com",
                Phone = "914.914.1009",
                ProfileImage = "Racer_X.jpg",
                Tags = "hero, racer"
            };

            var person288 = new Member
            {
                PersonId = 397,
                FirstName = "Jiro",
                LastName = "Horikoshi",
                Zip = "10702",
                State = "NY",
                City = "Yonkers",
                Address = "732 Mitsubishi Ave",
                Email = "Invented_Zero@nowhere.com",
                Phone = "914.914.1092",
                ProfileImage = "Jiro_Horikoshi.jpg",
                Tags = "techie"
            };

            var person289 = new Member
            {
                PersonId = 398,
                FirstName = "Mizuho",
                LastName = "Sugeno",
                Zip = "98382",
                State = "WA",
                City = "Sequim",
                Address = "732 Great Soil Valley Rd.",
                Email = "Mizuho_Sugeno@nowhere.com",
                Phone = "360.914.1092",
                ProfileImage = "Mizuho_Sugeno.jpg",
                Tags = "farmer"
            };

            var person290 = new Member
            {
                PersonId = 399,
                FirstName = "Junko",
                LastName = "Kajino",
                Zip = "98382",
                State = "WA",
                City = "Sequim",
                Address = "732 Sweet Valley Rd.",
                Email = "Mizuho_Sugeno@nowhere.com",
                Phone = "360.914.1662",
                ProfileImage = "Junko_Kajino.jpg",
                Tags = "farmer"
            };

            var person291 = new Member
            {
                PersonId = 400,
                FirstName = "Old",
                LastName = "McDonald",
                Zip = "98382",
                State = "WA",
                City = "Sequim",
                Address = "7387 Ee I E I O Ave.",
                Email = "AndOnThisFarmHeAd@nowhere.com",
                Phone = "360.914.0662",
                ProfileImage = "Old_McDonald.jpg",
                Tags = "farmer"
            };

            var person292 = new Member
            {
                PersonId = 401,
                FirstName = "Mutsuo",
                LastName = "Banba",
                Zip = "98382",
                State = "WA",
                City = "Sequim",
                Address = "738 Green Plant Dr.",
                Email = "Mutsuo_Banba@nowhere.com",
                Phone = "360.414.0362",
                ProfileImage = "Mutsuo_Banba.jpg",
                Tags = "farmer"
            };

            var person293 = new Member
            {
                PersonId = 402,
                FirstName = "Shigenori",
                LastName = "Goto",
                Zip = "98382",
                State = "WA",
                City = "Sequim",
                Address = "7328 West Valley Hwy",
                Email = "Shigenori_Goto@nowhere.com",
                Phone = "360.414.0362",
                ProfileImage = "Shigenori_Goto.jpg",
                Tags = "farmer"
            };

            var person294 = new Member
            {
                PersonId = 403,
                FirstName = "Chie",
                LastName = "Kawabata",
                Zip = "98382",
                State = "WA",
                City = "Sequim",
                Address = "6678 West Valley Hwy",
                Email = "Chie_Kawabata@nowhere.com",
                Phone = "360.414.7362",
                ProfileImage = "Chie_Kawabata.jpg",
                Tags = "farmer"
            };

            var person295 = new Member
            {
                PersonId = 404,
                FirstName = "Keiko",
                LastName = "Takeshita",
                Zip = "98382",
                State = "WA",
                City = "Sequim",
                Address = "578 Old Plantation Rd.",
                Email = "Keiko_Takeshita@nowhere.com",
                Phone = "360.414.7300",
                ProfileImage = "Keiko_Takeshita.jpg",
                Tags = "farmer"
            };

            var person296 = new Member
            {
                PersonId = 405,
                FirstName = "Shinobu",
                LastName = "Otake",
                Zip = "98382",
                State = "WA",
                City = "Sequim",
                Address = "338 Rich Valley Dr.",
                Email = "Shinobu_Otake@nowhere.com",
                Phone = "360.414.4440",
                ProfileImage = "Shinobu_Otake.jpg",
                Tags = "farmer"
            };

            var person297 = new Member
            {
                PersonId = 406,
                FirstName = "Morio",
                LastName = "Kazama",
                Zip = "98382",
                State = "WA",
                City = "Sequim",
                Address = "3354 Rich Valley Dr.",
                Email = "Morio_Kazama@nowhere.com",
                Phone = "360.414.42240",
                ProfileImage = "Morio_Kazama.jpg",
                Tags = "farmer"
            };

            var person298 = new Member
            {
                PersonId = 407,
                FirstName = "Chika",
                LastName = "Sakamoto",
                Zip = "98382",
                State = "WA",
                City = "Sequim",
                Address = "334 Growing Zone Hwy.",
                Email = "ChikaSakamoto@nowhere.com",
                Phone = "360.414.42240",
                ProfileImage = "Chika_Sakamoto.jpg",
                Tags = "farmer"
            };


            // --------------------------------------
            // Eden Prairie, MN 55346   Area Code 651
            // --------------------------------------


            var person299 = new Member
            {
                PersonId = 408,
                FirstName = "Burt",
                LastName = "Shavitz",
                Zip = "55346",
                State = "MN",
                City = "Eden Prairie",
                Address = "2345 Burt's Bees Road",
                Email = "BurtShavitz@nowhere.com",
                Phone = "360.414.42240",
                ProfileImage = "Burt_Shavitz.jpg",
                Tags = "farmer"
            };

            var person300 = new Member
            {
                PersonId = 409,
                FirstName = "Mizuho",
                LastName = "Sakaguchi",
                Zip = "55346",
                State = "MN",
                City = "Eden Prairie",
                Address = "2145 World Cup St.",
                Email = "MizuhoSakaguchi@nowhere.com",
                Phone = "360.414.0240",
                ProfileImage = "Mizuho_Sakaguchi.jpeg",
                Tags = "athlete"
            };

            var person301 = new Member
            {
                PersonId = 410,
                FirstName = "Saki",
                LastName = "Kumagai",
                Zip = "55346",
                State = "MN",
                City = "Eden Prairie",
                Address = "2147 World Cup St.",
                Email = "SakiKumagai@nowhere.com",
                Phone = "360.414.0240",
                ProfileImage = "Saki_Kumagai.JPG",
                Tags = "athlete"
            };

            var person302 = new Member
            {
                PersonId = 411,
                FirstName = "Azusa",
                LastName = "Iwashimizu",
                Zip = "55346",
                State = "MN",
                City = "Eden Prairie",
                Address = "2112 World Cup St.",
                Email = "AzusaIwashimizu@nowhere.com",
                Phone = "360.414.0990",
                ProfileImage = "Azusa_Iwashimizu.jpg",
                Tags = "athlete"
            };

            var person303 = new Member
            {
                PersonId = 412,
                FirstName = "Mana",
                LastName = "Iwabuchi",
                Zip = "55346",
                State = "MN",
                City = "Eden Prairie",
                Address = "2117 World Cup St.",
                Email = "ManaIwabuchiu@nowhere.com",
                Phone = "360.414.0990",
                ProfileImage = "Mana_Iwabuchi.jpg",
                Tags = "athlete"
            };

            var person304 = new Member
            {
                PersonId = 413,
                FirstName = "Homare",
                LastName = "Sawa",
                Zip = "55346",
                State = "MN",
                City = "Eden Prairie",
                Address = "2119 World Cup St.",
                Email = "HomareSawa@nowhere.com",
                Phone = "360.414.1992",
                ProfileImage = "Homare_Sawa.jpg",
                Tags = "athlete"
            };

            var person305 = new Member
            {
                PersonId = 414,
                FirstName = "Pippi",
                LastName = "Longstocking",
                Zip = "55346",
                State = "MN",
                City = "Eden Prairie",
                Address = "229 Starchy Hair St.",
                Email = "PigTails.com",
                Phone = "360.414.1442",
                ProfileImage = "Pippi_Longstocking.jpg",
                Tags = "fictional"
            };

            var person306 = new Member
            {
                PersonId = 415,
                FirstName = "Wicked",
                LastName = "Witch",
                Zip = "55346",
                State = "MN",
                City = "Eden Prairie",
                Address = "2241 Land of Oz St.",
                Email = "RulerOfTheWest@nowhere.com",
                Phone = "360.414.1242",
                ProfileImage = "Wicked_Witch.jpg",
                Tags = "fictional, villian"
            };

            var person307 = new Member
            {
                PersonId = 416,
                FirstName = "Princess",
                LastName = "Mononoke",
                Zip = "55346",
                State = "MN",
                City = "Eden Prairie",
                Address = "2113 Forest Spirits Way",
                Email = "MonsterPrincess@nowhere.com",
                Phone = "360.414.9242",
                ProfileImage = "Princess_Mononoke.gif",
                Tags = "animated, fictional, hero"
            };

            var person308 = new Member
            {
                PersonId = 417,
                FirstName = "Doctor",
                LastName = "No",
                Zip = "95103",
                State = "CA",
                City = "San Jose",
                Address = "1 Jamaican Underground Ave.",
                Email = "DeathRay@nowhere.com",
                Phone = "669.879.9242",
                ProfileImage = "Doctor_No.jpg",
                Tags = "fictional, villian"
            };

            var person309 = new Member
            {
                PersonId = 418,
                FirstName = "Ernst",
                LastName = "Blofeld",
                Zip = "95103",
                State = "CA",
                City = "San Jose",
                Address = "1 Doctor Evil Road",
                Email = "ErnstStavroBlofeld@nowhere.com",
                Phone = "669.879.9212",
                ProfileImage = "Ernst_Blofeld.jpg",
                Tags = "fictional, villian"
            };

            var person310 = new Member
            {
                PersonId = 419,
                FirstName = "The",
                LastName = "Architect",
                Zip = "95103",
                State = "CA",
                City = "San Jose",
                Address = "234 Matrix Core Rd.",
                Email = "PerfectMatrix@nowhere.com",
                Phone = "669.879.9252",
                ProfileImage = "The_Architect.jpg",
                Tags = "fictional, villian"
            };

            var person311 = new Member
            {
                PersonId = 420,
                FirstName = "Madam",
                LastName = "Mim",
                Zip = "95103",
                State = "CA",
                City = "San Jose",
                Address = "232 Black Forest Rd.",
                Email = "MadMadam@nowhere.com",
                Phone = "669.879.9252",
                ProfileImage = "Madam_Mim.jpg",
                Tags = "animated, cat, fictional, villian"
            };

            var person312 = new Member
            {
                PersonId = 421,
                FirstName = "Petunia",
                LastName = "Pig",
                Zip = "95103",
                State = "CA",
                City = "San Jose",
                Address = "223 Hog Farm Road",
                Email = "Petunia123@nowhere.com",
                Phone = "669.879.9212",
                ProfileImage = "Petunia_Pig.jpg",
                Tags = "animated, farmer"
            };

            var person313 = new Member
            {
                PersonId = 422,
                FirstName = "Rosie",
                LastName = "Riveter",
                Zip = "95103",
                State = "CA",
                City = "San Jose",
                Address = "7783 Buy Bonds Lane",
                Email = "V_For_Victory@nowhere.com",
                Phone = "669.879.1212",
                ProfileImage = "Rosie_Riveter.jpg",
                Tags = string.Empty
            };

            var person314 = new Member
            {
                PersonId = 423,
                FirstName = "Wavy",
                LastName = "Gravy",
                Zip = "95103",
                State = "CA",
                City = "San Jose",
                Address = "23 Hog Farm Rd.",
                Email = "HughRomney@nowhere.com",
                Phone = "669.879.1232",
                ProfileImage = "Wavy_Gravy.jpg",
                Tags = string.Empty
            };

            var person315 = new Member
            {
                PersonId = 424,
                FirstName = "Lord",
                LastName = "Zedd",
                Zip = "95103",
                State = "CA",
                City = "San Jose",
                Address = "2245 Dominator Blvd.",
                Email = "LordZedd@nowhere.com",
                Phone = "669.879.9932",
                ProfileImage = "Lord_Zedd.jpg",
                Tags = "fictional, villian"
            };

            var person316 = new Member
            {
                PersonId = 425,
                FirstName = "Mrs.",
                LastName = "Tweedy",
                Zip = "95103",
                State = "CA",
                City = "San Jose",
                Address = "22345 Chicken Run Blvd.",
                Email = "PotPies@nowhere.com",
                Phone = "669.879.9012",
                ProfileImage = "Mrs_Tweedy.jpg",
                Tags = "farmer, fictional, villian"
            };

            var person317 = new Member
            {
                PersonId = 426,
                FirstName = "Bonesaw",
                LastName = "McGraw",
                Zip = "95103",
                State = "CA",
                City = "San Jose",
                Address = "3 Minutes Playtime St.",
                Email = "MachoManRandySavage@nowhere.com",
                Phone = "669.879.9062",
                ProfileImage = "Randy_Savage.jpg",
                Tags = "athlete"
            };

            var person318 = new Member
            {
                PersonId = 427,
                FirstName = "Alan",
                LastName = "Turing",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "1 Father of Computer Sc.",
                Email = "AlanTuring@nowhere.com",
                Phone = "715.422.9062",
                ProfileImage = "Alan_Turing.jpg",
                Tags = "author, techie"
            };

            var person319 = new Member
            {
                PersonId = 428,
                FirstName = "Dot",
                LastName = "Warner",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "1233 Water Tower Road",
                Email = "WarnerSisters@nowhere.com",
                Phone = "715.422.9022",
                ProfileImage = "Dot_Warner.jpg",
                Tags = "animated, cat, fictional"
            };

            var person320 = new Member
            {
                PersonId = 429,
                FirstName = "Bullwinkle",
                LastName = "Moose",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "122 Frostbite Falls Hwy",
                Email = "BullwinkleJMoose@nowhere.com",
                Phone = "715.422.9332",
                ProfileImage = "Bullwinkle_Moose.jpg",
                Tags = "animated, fictional"
            };

            var person321 = new Member
            {
                PersonId = 430,
                FirstName = "Rocky",
                LastName = "Squirrel",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "122 Frostbite Falls Hwy",
                Email = "RockyPSquirrel@nowhere.com",
                Phone = "715.422.9331",
                ProfileImage = "Rocky_P_Squirrel.jpg",
                Tags = "animated, fictional"
            };

            var person322 = new Member
            {
                PersonId = 431,
                FirstName = "Felix",
                LastName = "Cat",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "122 Frostbite Falls Hwy",
                Email = "RockyPSquirrel@nowhere.com",
                Phone = "715.421.6781",
                ProfileImage = "Felix_Cat.jpg",
                Tags = "animated, cat, fictional"
            };

            var person323 = new Member
            {
                PersonId = 432,
                FirstName = "Peter",
                LastName = "Benchley",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "124 Amity Island Rd.",
                Email = "JawsAuthor@nowhere.com",
                Phone = "715.421.0081",
                ProfileImage = "Peter_Benchley.jpg",
                Tags = "author"
            };

            var person324 = new Member
            {
                PersonId = 433,
                FirstName = "Paul",
                LastName = "Bunyan",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "124 Northwoods Dr.",
                Email = "LumberJack4Eva@nowhere.com",
                Phone = string.Empty,
                ProfileImage = "Paul_Bunyan.jpg",
                Tags = "fictional"
            };

            var person325 = new Member
            {
                PersonId = 434,
                FirstName = "Lich",
                LastName = "King",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "2334 Frozen Throne Rd.",
                Email = "TheScourge@nowhere.com",
                Phone = "715.421.9781",
                ProfileImage = "Lich_King.jpg",
                Tags = "fictional, video-game, villian"
            };

            var person326 = new Member
            {
                PersonId = 435,
                FirstName = "Moppet",
                LastName = "Girl",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "2034 Litwak's Arcade Dr.",
                Email = "GamerGurl23@nowhere.com",
                Phone = "715.421.9711",
                ProfileImage = "Moppet_Girl.jpg",
                Tags = "animated, fictional, video-game"
            };

            var person327 = new Member
            {
                PersonId = 436,
                FirstName = "Wreckit",
                LastName = "Ralph",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "2023 Fixit Felix St.",
                Email = "GimmeAnAward@nowhere.com",
                Phone = "715.421.2911",
                ProfileImage = "Wreckit_Ralph.jpg",
                Tags = "animated, fictional, hero, video-game, villian"
            };

            var person328 = new Member
            {
                PersonId = 437,
                FirstName = "Big",
                LastName = "Gene",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "2 Top Floor Suite St.",
                Email = "BigGene@nowhere.com",
                Phone = "715.421.2991",
                ProfileImage = "Big_Gene.jpg",
                Tags = "animated, fictional, video-game"
            };

            var person329 = new Member
            {
                PersonId = 438,
                FirstName = "Fixit",
                LastName = "Felix",
                Zip = "54016",
                State = "WI",
                City = "Hudson",
                Address = "1 Top Floor Suite St.",
                Email = "FixitFast@nowhere.com",
                Phone = "715.421.2649",
                ProfileImage = "Fixit_Felix.jpg",
                Tags = "animated, fictional, hero, video-game"
            };

            var person330 = new Member
            {
                PersonId = 439,
                FirstName = "Solid",
                LastName = "Snake",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "2223 Metal Gear Ave.",
                Email = "ImInABox@nowhere.com",
                Phone = "651.528.9849",
                ProfileImage = "Solid_Snake.jpg",
                Tags = "animated, fictional, hero, video-game"
            };

            var person331 = new Member
            {
                PersonId = 440,
                FirstName = "Samus",
                LastName = "Aran",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "2023 Metroid Prime Ave.",
                Email = "GurlPower876@nowhere.com",
                Phone = "651.528.0849",
                ProfileImage = "Samus_Aran.jpg",
                Tags = "animated, fictional, hero, video-game"
            };

            var person332 = new Member
            {
                PersonId = 441,
                FirstName = "Donkey",
                LastName = "Kong",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "223 Jungle Land Dr.",
                Email = "DKDonkeyKong@nowhere.com",
                Phone = "651.528.9848",
                ProfileImage = "Donkey_Kong.jpg",
                Tags = "animated, fictional, hero, video-game"
            };

            var person333 = new Member
            {
                PersonId = 442,
                FirstName = "Princess",
                LastName = "Peach",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "222 Castle Ave.",
                Email = "PrincessPeach@nowhere.com",
                Phone = "651.528.9831",
                ProfileImage = "Princess_Peach.jpg",
                Tags = "animated, fictional, video-game"
            };

            var person334 = new Member
            {
                PersonId = 443,
                FirstName = "Rtas",
                LastName = "Vadi",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "224 Covenant Way",
                Email = "ShadowOfIntent@nowhere.com",
                Phone = "651.528.9031",
                ProfileImage = "Rtas_Vadum.jpg",
                Tags = "animated, fictional, video-game"
            };

            var person335 = new Member
            {
                PersonId = 444,
                FirstName = "Tali",
                LastName = "Zorah",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "224 Mass Affect Dr.",
                Email = "Normandy_Tal@nowhere.com",
                Phone = "651.528.9231",
                ProfileImage = "Tali_Zorah.jpg",
                Tags = "animated, fictional, hero, video-game"
            };

            var person336 = new Member
            {
                PersonId = 445,
                FirstName = "Mordin",
                LastName = "Solus",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "226 Mass Affect Dr.",
                Email = "Genophage_Mordin@nowhere.com",
                Phone = "651.528.9239",
                ProfileImage = "Mordin_Solus.png",
                Tags = "animated, fictional, video-game"
            };

            var person337 = new Member
            {
                PersonId = 446,
                FirstName = "Illusive",
                LastName = "Man",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "Unknown",
                Email = "IllusiveMan@nowhere.com",
                Phone = "651.528.9229",
                ProfileImage = "Illusive_Man.jpg",
                Tags = "animated, fictional, video-game"
            };

            var person338 = new Member
            {
                PersonId = 447,
                FirstName = "Andrew",
                LastName = "Ryan",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "987 Rapture Capsule 12",
                Email = "NoKingNoGodsOnlyMan@nowhere.com",
                Phone = "651.528.9029",
                ProfileImage = "Andrew_Ryan.jpg",
                Tags = "animated, fictional, politician, video-game"
            };

            var person339 = new Member
            {
                PersonId = 448,
                FirstName = "Zachary",
                LastName = "Comstock",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "923 Floating Fortress Way",
                Email = "TheProphet@nowhere.com",
                Phone = "651.528.9029",
                ProfileImage = "Zachary_Hale_Comstock.jpg",
                Tags = "animated, fictional, politician, video-game, villian"
            };

            var person340 = new Member
            {
                PersonId = 449,
                FirstName = "Erik",
                LastName = "Lensherr",
                Zip = "55115",
                State = "MN",
                City = "Mahtomedi",
                Address = "924 Mutants United Road",
                Email = "Magneto@nowhere.com",
                Phone = "651.528.9029",
                ProfileImage = "Erik_Lensherr.jpg",
                Tags = "animated, fictional, video-game, villian"
            };

            var person341 = new Member
            {
                PersonId = 450,
                FirstName = "Grumpy",
                LastName = "Cat",
                Zip = "96087",
                State = "CA",
                City = "Shasta",
                Address = "923 I don't like it Dr.",
                Email = "GrumpyCat@nowhere.com",
                Phone = "530.908.9029",
                ProfileImage = "Grumpy_Cat.jpg",
                Tags = "cat"
            };

            var person342 = new Member
            {
                PersonId = 451,
                FirstName = "Tinker",
                LastName = "Bell",
                Zip = "96087",
                State = "CA",
                City = "Shasta",
                Address = "923 Neverland Dr.",
                Email = "Tink@nowhere.com",
                Phone = "530.908.9429",
                ProfileImage = "Tinker_Bell.jpg",
                Tags = "animated, fictional"
            };

            var person343 = new Member
            {
                PersonId = 452,
                FirstName = "Eric",
                LastName = "Bidelman",
                Zip = "96087",
                State = "CA",
                City = "Shasta",
                Address = "233 Polymer R.",
                Email = "EricLovesPolymer@nowhere.com",
                Phone = "530.908.9419",
                ProfileImage = "Eric_Bidelman.jpg",
                Tags = "techie"
            };

            var person344 = new Member
            {
                PersonId = 453,
                FirstName = "Princess",
                LastName = "Bubblegum",
                Zip = "96087",
                State = "CA",
                City = "Shasta",
                Address = "2876 Adventure Time St.",
                Email = "Bubblegum@nowhere.com",
                Phone = "530.908.2419",
                ProfileImage = "Princess_Bubblegum.png",
                Tags = "animated, fictional"
            };

            var person345 = new Member
            {
                PersonId = 454,
                FirstName = "Betty",
                LastName = "Grof",
                Zip = "96087",
                State = "CA",
                City = "Shasta",
                Address = "2879 Adventure Time St.",
                Email = "BettyGrof@nowhere.com",
                Phone = "530.908.2099",
                ProfileImage = "Betty_Grof.jpg",
                Tags = "animated, fictional"
            };

            var person346 = new Member
            {
                PersonId = 455,
                FirstName = "Captain",
                LastName = "Knuckles",
                Zip = "96087",
                State = "CA",
                City = "Shasta",
                Address = "979 Flapjack Bay",
                Email = "Captain_Knuckles.png",
                Phone = "530.902.2019",
                ProfileImage = "Captain_Knuckles.jpg",
                Tags = "animated, fictional"
            };

            var person347 = new Member
            {
                PersonId = 456,
                FirstName = "Sally",
                LastName = "Syrup",
                Zip = "96087",
                State = "CA",
                City = "Shasta",
                Address = "981 Flapjack Bay",
                Email = "SallySyrup@nowhere.com",
                Phone = "530.902.2013",
                ProfileImage = "Sally_Syrup.jpg",
                Tags = "animated, fictional"
            };

            var person348 = new Member
            {
                PersonId = 457,
                FirstName = "Candy",
                LastName = "Wife",
                Zip = "96087",
                State = "CA",
                City = "Shasta",
                Address = "981 Candy Barrel Rd",
                Email = "CandyAndLarry@nowhere.com",
                Phone = "530.902.1013",
                ProfileImage = "Candy_wife.jpg",
                Tags = "animated, fictional"
            };

            var person349 = new Member
            {
                PersonId = 458,
                FirstName = "Fairy",
                LastName = "Godmother",
                Zip = "96087",
                State = "CA",
                City = "Shasta",
                Address = "981 Potion Store Dr.",
                Email = "YourPotions@nowhere.com",
                Phone = "530.902.1015",
                ProfileImage = "Fairy_Godmother.jpg",
                Tags = "animated, fictional, villian"
            };

            var person350 = new Member
            {
                PersonId = 459,
                FirstName = "Gingerbread",
                LastName = "Man",
                Zip = "96087",
                State = "CA",
                City = "Shasta",
                Address = "981 Drury Lane",
                Email = "EatMe@nowhere.com",
                Phone = "530.902.1015",
                ProfileImage = "Gingerbread_Man.jpg",
                Tags = "animated, fictional, hero"
            };

            // ----------------------------------------
            // Clearwater, FL 33756         Area code  727
            // ----------------------------------------


            var person351 = new Member
            {
                PersonId = 460,
                FirstName = "General",
                LastName = "Mandible",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "927 War Road",
                Email = "TheWeakMustDie@nowhere.com",
                Phone = "727.632.1015",
                ProfileImage = "General_Mandible.jpg",
                Tags = "animated, fictional, villian"
            };

            var person352 = new Member
            {
                PersonId = 461,
                FirstName = "Princess",
                LastName = "Bala",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "981 Drury Lane",
                Email = "SugarAnt@nowhere.com",
                Phone = "727.632.1016",
                ProfileImage = "Princess_Bala.jpg",
                Tags = "animated, fictional"
            };

            var person353 = new Member
            {
                PersonId = 462,
                FirstName = "Vanessa",
                LastName = "Bloome",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "7631 Beekeepers Lane",
                Email = "LoveBees@nowhere.com",
                Phone = "727.632.0016",
                ProfileImage = "Vanessa_Bloome.jpg",
                Tags = "animated, fictional"
            };

            var person354 = new Member
            {
                PersonId = 463,
                FirstName = "Barry",
                LastName = "Binson",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "7631 Beekeepers Lane",
                Email = "LoveBees2@nowhere.com",
                Phone = "727.632.0017",
                ProfileImage = "Barry_B_Binson.jpg",
                Tags = "animated, fictional"
            };

            var person355 = new Member
            {
                PersonId = 464,
                FirstName = "Brad",
                LastName = "Green",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "2731 Angular 2.0 Team Rd.",
                Email = "GoogleEngineer@nowhere.com",
                Phone = "727.632.0017",
                ProfileImage = "Brad_Green.jpg",
                Tags = "techie"
            };

            var person356 = new Member
            {
                PersonId = 465,
                FirstName = "Ryan",
                LastName = "Schmukler",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "7831 Angular 2.0 Team Rd.",
                Email = "Angular-Mterial@nowhere.com",
                Phone = "727.632.0017",
                ProfileImage = "Ryan_Schmukler.jpg",
                Tags = "techie"
            };

            var person357 = new Member
            {
                PersonId = 466,
                FirstName = "Alex",
                LastName = "Mark",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "2331 Material CSS St.",
                Email = "MaterializeFTW@nowhere.com",
                Phone = "727.632.0065",
                ProfileImage = "Alex_Mark.jpg",
                Tags = "techie"
            };

            var person358 = new Member
            {
                PersonId = 467,
                FirstName = "Alvin",
                LastName = "Wang",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "2381 Material CSS St.",
                Email = "MaterializeRoks@nowhere.com",
                Phone = "727.632.0065",
                ProfileImage = "Alvin_Wang.png",
                Tags = "techie"
            };

            var person359 = new Member
            {
                PersonId = 468,
                FirstName = "Blue",
                LastName = "Fairy",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "2334 Real Boii Rd.",
                Email = "Navi@nowhere.com",
                Phone = "727.632.0955",
                ProfileImage = "Blue_Fairy.jpg",
                Tags = "animated, fictional"
            };

            var person360 = new Member
            {
                PersonId = 469,
                FirstName = "Lady",
                LastName = "Tremaine",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "234 Count's Manor Rd.",
                Email = "LadyT@nowhere.com",
                Phone = "727.632.0951",
                ProfileImage = "Lady_Tremaine.jpg",
                Tags = "animated, fictional, villian"
            };

            var person361 = new Member
            {
                PersonId = 470,
                FirstName = "Morticia",
                LastName = "Addams",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "001 Cemetery Lane",
                Email = "MorticiaAddams@nowhere.com",
                Phone = "727.632.9951",
                ProfileImage = "Morticia_Addams.jpg",
                Tags = "fictional"
            };

            var person362 = new Member
            {
                PersonId = 471,
                FirstName = "Gomez",
                LastName = "Addams",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "001 Cemetery Lane",
                Email = "MorticiaAddams@nowhere.com",
                Phone = "727.632.9951",
                ProfileImage = "Gomez_Addams.jpg",
                Tags = "fictional"
            };

            var person363 = new Member
            {
                PersonId = 472,
                FirstName = "Lance",
                LastName = "Bailles",
                Zip = "33756",
                State = "FL",
                City = "Clearwater",
                Address = "479 Hanchey Road",
                Email = "BiggPOCs@nowhere.com",
                Phone = "727.632.9950",
                ProfileImage = "Lance_Bailles.jpg", /* Itsa MEEEEEEE ! */
                Tags = "techie"
            };


            // Tags = "author, athlete, artist, animated, cat, chef, explorer, farmer, fictional, hero, politician, racer, sci-fi, techie, video-game, villian"

            // -------------------------------------------
            // Celebration, FL
            // http://pixar.wikia.com/Category:Toy_Story_3_Characters

            // -------------------------------------------
            // Huntsville, AL 35802         Area code  256
            // --------------------------------------------

            // Prolly time for 10 more Japanese only ! (Nintendo wiki will bring up a ton)

            // Satoru Iwata Satoru_Iwata .jpg - former president of Nintendo, deceased.
            // Shigeru Miyamoto Shigeru_Miyamoto.jpg - Inventor of the many major Nintendo francises

            // ----------------------------------------
            // ssssss, ss 00000         Area code  000
            // ----------------------------------------

            // John Papa
            // Papa John
            // Robin (from batman) dick grayson
            // Marvel Universe should be good for ten people, here.
            // More food mascots ?  Tony Tiger, Sta Puff, Famous Dave, Sarah Lee, Dolly Madison

            // ---------------------------------------
            // ssssssss, ss 00000       Area code 000
            // ---------------------------------------

            // would not be difficult to take 10+ characters off of the ghibli / Miyazake wiki

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
            people.Add(person13);
            people.Add(person14);
            people.Add(person15);
            people.Add(person16);
            people.Add(person17);
            people.Add(person18);
            people.Add(person19);
            people.Add(person20);
            people.Add(person21);
            people.Add(person22);
            people.Add(person23);
            people.Add(person24);
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
            people.Add(person55);
            people.Add(person56);
            people.Add(person57);
            people.Add(person58);
            people.Add(person59);
            people.Add(person60);
            people.Add(person61);
            people.Add(person62);
            people.Add(person63);
            people.Add(person64);
            people.Add(person65);
            people.Add(person66);
            people.Add(person67);
            people.Add(person68);
            people.Add(person69);
            people.Add(person70);
            people.Add(person71);
            people.Add(person72);
            people.Add(person73);
            people.Add(person74);
            people.Add(person75);
            people.Add(person76);
            people.Add(person77);
            people.Add(person78);
            people.Add(person79);
            people.Add(person80);
            people.Add(person81);
            people.Add(person82);
            people.Add(person83);
            people.Add(person84);
            people.Add(person85);
            people.Add(person86);
            people.Add(person87);
            people.Add(person88);
            people.Add(person89);
            people.Add(person90);
            people.Add(person91);
            people.Add(person92);
            people.Add(person93);
            people.Add(person94);
            people.Add(person95);
            people.Add(person96);
            people.Add(person97);
            people.Add(person98);
            people.Add(person99);
            people.Add(person100);
            people.Add(person101);
            people.Add(person103);
            people.Add(person104);
            people.Add(person105);
            people.Add(person106);
            people.Add(person107);
            people.Add(person108);
            people.Add(person109);
            people.Add(person110);
            people.Add(person111);
            people.Add(person112);
            people.Add(person113);
            people.Add(person114);
            people.Add(person115);
            people.Add(person116);
            people.Add(person117);
            people.Add(person118);
            people.Add(person121);
            people.Add(person123);
            people.Add(person124);
            people.Add(person125);
            people.Add(person126);
            people.Add(person127);
            people.Add(person128);
            people.Add(person130);
            people.Add(person132);
            people.Add(person133);
            people.Add(person134);
            people.Add(person135);
            people.Add(person136);
            people.Add(person137);
            people.Add(person138);
            people.Add(person139);
            people.Add(person140);
            people.Add(person141);
            people.Add(person142);
            people.Add(person143);
            people.Add(person144);
            people.Add(person145);
            people.Add(person146);
            people.Add(person147);
            people.Add(person148);
            people.Add(person149);
            people.Add(person150);
            people.Add(person151);
            people.Add(person152);
            people.Add(person153);
            people.Add(person154);
            people.Add(person155);
            people.Add(person156);
            people.Add(person157);
            people.Add(person158);
            people.Add(person160);
            people.Add(person161);
            people.Add(person162);
            people.Add(person163);
            people.Add(person164);
            people.Add(person165);
            people.Add(person166);
            people.Add(person167);
            people.Add(person168);
            people.Add(person169);
            people.Add(person170);
            people.Add(person171);
            people.Add(person172);
            people.Add(person173);
            people.Add(person174);
            people.Add(person175);
            people.Add(person176);
            people.Add(person177);
            people.Add(person178);
            people.Add(person179);
            people.Add(person180);
            people.Add(person181);
            people.Add(person182);
            people.Add(person183);
            people.Add(person184);
            people.Add(person185);
            people.Add(person186);
            people.Add(person187);
            people.Add(person188);
            people.Add(person189);
            people.Add(person190);
            people.Add(person191);
            people.Add(person192);
            people.Add(person193);
            people.Add(person194);
            people.Add(person195);
            people.Add(person196);
            people.Add(person197);
            people.Add(person198);
            people.Add(person199);
            people.Add(person200);
            people.Add(person201);
            people.Add(person202);
            people.Add(person203);
            people.Add(person204);
            people.Add(person205);
            people.Add(person206);
            people.Add(person207);
            people.Add(person208);
            people.Add(person209);
            people.Add(person210);
            people.Add(person211);
            people.Add(person212);
            people.Add(person213);
            people.Add(person214);
            people.Add(person215);
            people.Add(person216);
            people.Add(person217);
            people.Add(person218);
            people.Add(person219);
            people.Add(person220);
            people.Add(person221);
            people.Add(person222);
            people.Add(person223);
            people.Add(person224);
            people.Add(person225);
            people.Add(person226);
            people.Add(person227);
            people.Add(person228);
            people.Add(person229);
            people.Add(person230);
            people.Add(person231);
            people.Add(person232);
            people.Add(person233);
            people.Add(person234);
            people.Add(person235);
            people.Add(person236);
            people.Add(person237);
            people.Add(person238);
            people.Add(person239);
            people.Add(person240);
            people.Add(person241);
            people.Add(person242);
            people.Add(person243);
            people.Add(person244);
            people.Add(person245);
            people.Add(person246);
            people.Add(person247);
            people.Add(person248);
            people.Add(person249);
            people.Add(person250);
            people.Add(person251);
            people.Add(person252);
            people.Add(person253);
            people.Add(person254);
            people.Add(person255);
            people.Add(person256);
            people.Add(person257);
            people.Add(person258);
            people.Add(person259);
            people.Add(person260);
            people.Add(person261);
            people.Add(person262);
            people.Add(person263);
            people.Add(person264);
            people.Add(person265);
            people.Add(person266);
            people.Add(person267);
            people.Add(person268);
            people.Add(person269);
            people.Add(person270);
            people.Add(person271);
            people.Add(person272);
            people.Add(person273);
            people.Add(person274);
            people.Add(person275);
            people.Add(person276);
            people.Add(person277);
            people.Add(person278);
            people.Add(person279);
            people.Add(person280);
            people.Add(person281);
            people.Add(person282);
            people.Add(person283);
            people.Add(person284);
            people.Add(person285);
            people.Add(person286);
            people.Add(person287);
            people.Add(person288);
            people.Add(person289);
            people.Add(person290);
            people.Add(person291);
            people.Add(person292);
            people.Add(person293);
            people.Add(person294);
            people.Add(person295);
            people.Add(person296);
            people.Add(person297);
            people.Add(person298);
            people.Add(person299);
            people.Add(person300);
            people.Add(person301);
            people.Add(person302);
            people.Add(person303);
            people.Add(person304);
            people.Add(person305);
            people.Add(person306);
            people.Add(person307);
            people.Add(person308);
            people.Add(person309);
            people.Add(person310);
            people.Add(person311);
            people.Add(person312);
            people.Add(person313);
            people.Add(person314);
            people.Add(person315);
            people.Add(person316);
            people.Add(person317);
            people.Add(person318);
            people.Add(person319);
            people.Add(person320);
            people.Add(person321);
            people.Add(person322);
            people.Add(person323);
            people.Add(person324);
            people.Add(person325);
            people.Add(person326);
            people.Add(person327);
            people.Add(person328);
            people.Add(person329);
            people.Add(person330);
            people.Add(person331);
            people.Add(person332);
            people.Add(person333);
            people.Add(person334);
            people.Add(person335);
            people.Add(person336);
            people.Add(person337);
            people.Add(person338);
            people.Add(person339);
            people.Add(person340);
            people.Add(person341);
            people.Add(person342);
            people.Add(person343);
            people.Add(person344);
            people.Add(person345);
            people.Add(person346);
            people.Add(person347);
            people.Add(person348);
            people.Add(person349);
            people.Add(person350);
            people.Add(person351);
            people.Add(person352);
            people.Add(person353);
            people.Add(person354);
            people.Add(person355);
            people.Add(person356);
            people.Add(person357);
            people.Add(person358);
            people.Add(person359);
            people.Add(person360);
            people.Add(person361);
            people.Add(person362);
            people.Add(person363);

            return people;
        }

        #endregion

    }
}
