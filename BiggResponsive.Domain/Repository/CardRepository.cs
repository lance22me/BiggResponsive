using System.Collections.Generic;
using System.Linq;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;

namespace BiggResponsive.Domain.Repository
{
    public class CardRepository : ICardRepository
    {

        public CardRepository()
        {
            // stubbed
        }

        public IEnumerable<Card> GetAll()
        {
            return this.AllCards();
        }

        public IEnumerable<Card> GetMany(int numberOfCards)
        {
            return this.AllCards().Take(numberOfCards);
        }



        private IEnumerable<Card> AllCards()
        {
            List<Card> deck = new List<Card>();

            #region Spades

            var card1 = new Card
            {
                CardId = 1,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 1,
                DisplayValue = "Ace",
                DisplayName = "Ace of Spades",
                IsNumber = false,
                IsAce = true,
                IsFace = false,
                IsJoker = false,
                Image = "SpadesAce.png",
                Tags = "Ace, Spades, Black"
            };

            var card2 = new Card
            {
                CardId = 2,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 2,
                DisplayValue = "2",
                DisplayName = "Two of Spades",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "SpadesTwo.png",
                Tags = "Number, Spades, 2, Black"
            };

            var card3 = new Card
            {
                CardId = 3,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 3,
                DisplayValue = "3",
                DisplayName = "Three of Spades",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "SpadesThree.png",
                Tags = "Number, Spades, 3, Black"
            };

            var card4 = new Card
            {
                CardId = 4,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 4,
                DisplayValue = "4",
                DisplayName = "Four of Spades",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "SpadesFour.png",
                Tags = "Number, Spades, 4, Black"
            };

            var card5 = new Card
            {
                CardId = 5,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 5,
                DisplayValue = "5",
                DisplayName = "Five of Spades",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "SpadesFive.png",
                Tags = "Number, Spades, 5, Black"
            };

            var card6 = new Card
            {
                CardId = 6,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 6,
                DisplayValue = "6",
                DisplayName = "Six of Spades",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "SpadesSix.png",
                Tags = "Number, Spades, 6, Black"
            };

            var card7 = new Card
            {
                CardId = 7,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 7,
                DisplayValue = "7",
                DisplayName = "Seven of Spades",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "SpadesSeven.png",
                Tags = "Number, Spades, 7, Black"
            };

            var card8 = new Card
            {
                CardId = 8,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 8,
                DisplayValue = "8",
                DisplayName = "Eight of Spades",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "SpadesEight.png",
                Tags = "Number, Spades, 8, Black"
            };

            var card9 = new Card
            {
                CardId = 9,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 9,
                DisplayValue = "9",
                DisplayName = "Nine of Spades",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "SpadesNine.png",
                Tags = "Number, Spades, 9, Black"
            };

            var card10 = new Card
            {
                CardId = 10,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 10,
                DisplayValue = "10",
                DisplayName = "Ten of Spades",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "SpadesTen.png",
                Tags = "Number, Spades, 10, Black"
            };

            var card11 = new Card
            {
                CardId = 11,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 11,
                DisplayValue = "Jack",
                DisplayName = "Jack of Spades",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "SpadesJack.png",
                Tags = "Face, Spades, Jack, Black"
            };

            var card12 = new Card
            {
                CardId = 12,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 12,
                DisplayValue = "Queen",
                DisplayName = "Queen of Spades",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "SpadesQueen.png",
                Tags = "Face, Spades, Queen, Black"
            };

            var card13 = new Card
            {
                CardId = 13,
                Suit = "Spades",
                SuitColor = "Black",
                SuitOrder = 12,
                DisplayValue = "King",
                DisplayName = "King of Spades",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "SpadesKing.png",
                Tags = "Face, Spades, King, Black"
            };

            #endregion

            #region Hearts

            var card14 = new Card
            {
                CardId = 14,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 1,
                DisplayValue = "Ace",
                DisplayName = "Ace of Hearts",
                IsNumber = false,
                IsAce = true,
                IsFace = false,
                IsJoker = false,
                Image = "HeartsAce.png",
                Tags = "Ace, Hearts, Red"
            };

            var card15 = new Card
            {
                CardId = 15,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 2,
                DisplayValue = "2",
                DisplayName = "Two of Hearts",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "HeartsTwo.png",
                Tags = "Number, Hearts, 2, Red"
            };

            var card16 = new Card
            {
                CardId = 16,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 3,
                DisplayValue = "3",
                DisplayName = "Three of Hearts",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "HeartsThree.png",
                Tags = "Number, Hearts, 3, Red"
            };

            var card17 = new Card
            {
                CardId = 17,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 4,
                DisplayValue = "4",
                DisplayName = "Four of Hearts",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "HeartsFour.png",
                Tags = "Number, Hearts, 4, Red"
            };

            var card18 = new Card
            {
                CardId = 18,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 5,
                DisplayValue = "5",
                DisplayName = "Five of Hearts",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "HeartsFive.png",
                Tags = "Number, Hearts, 5, Red"
            };

            var card19 = new Card
            {
                CardId = 19,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 6,
                DisplayValue = "6",
                DisplayName = "Six of Hearts",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "HeartsSix.png",
                Tags = "Number, Hearts, 6, Red"
            };

            var card20 = new Card
            {
                CardId = 20,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 7,
                DisplayValue = "7",
                DisplayName = "Seven of Hearts",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "HeartsSeven.png",
                Tags = "Number, Hearts, 7, Red"
            };

            var card21 = new Card
            {
                CardId = 21,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 8,
                DisplayValue = "8",
                DisplayName = "Eight of Hearts",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "HeartsEight.png",
                Tags = "Number, Hearts, 8, Red"
            };

            var card22 = new Card
            {
                CardId = 22,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 9,
                DisplayValue = "9",
                DisplayName = "Nine of Hearts",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "HeartsNine.png",
                Tags = "Number, Hearts, 9, Red"
            };

            var card23 = new Card
            {
                CardId = 23,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 10,
                DisplayValue = "10",
                DisplayName = "Ten of Hearts",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "HeartsTen.png",
                Tags = "Number, Hearts, 10, Red"
            };

            var card24 = new Card
            {
                CardId = 24,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 11,
                DisplayValue = "Jack",
                DisplayName = "Jack of Hearts",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "HeartsJack.png",
                Tags = "Face, Hearts, Jack, Red"
            };

            var card25 = new Card
            {
                CardId = 25,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 12,
                DisplayValue = "Queen",
                DisplayName = "Queen of Hearts",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "HeartsQueen.png",
                Tags = "Face, Hearts, Queen, Red"
            };

            var card26 = new Card
            {
                CardId = 26,
                Suit = "Hearts",
                SuitColor = "Red",
                SuitOrder = 12,
                DisplayValue = "King",
                DisplayName = "King of Hearts",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "HeartsKing.png",
                Tags = "Face, Hearts, King, Red"
            };

            #endregion

            #region Clubs

            var card27 = new Card
            {
                CardId = 27,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 1,
                DisplayValue = "Ace",
                DisplayName = "Ace of Clubs",
                IsNumber = false,
                IsAce = true,
                IsFace = false,
                IsJoker = false,
                Image = "ClubsAce.png",
                Tags = "Ace, Clubs, Black"
            };

            var card28 = new Card
            {
                CardId = 28,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 2,
                DisplayValue = "2",
                DisplayName = "Two of Clubs",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "ClubsTwo.png",
                Tags = "Number, Clubs, 2, Black"
            };

            var card29 = new Card
            {
                CardId = 29,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 3,
                DisplayValue = "3",
                DisplayName = "Three of Clubs",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "ClubsThree.png",
                Tags = "Number, Clubs, 3, Black"
            };

            var card30 = new Card
            {
                CardId = 30,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 4,
                DisplayValue = "4",
                DisplayName = "Four of Clubs",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "ClubsFour.png",
                Tags = "Number, Clubs, 4, Black"
            };

            var card31 = new Card
            {
                CardId = 31,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 5,
                DisplayValue = "5",
                DisplayName = "Five of Clubs",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "ClubsFive.png",
                Tags = "Number, Clubs, 5, Black"
            };

            var card32 = new Card
            {
                CardId = 32,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 6,
                DisplayValue = "6",
                DisplayName = "Six of Clubs",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "ClubsSix.png",
                Tags = "Number, Clubs, 6, Black"
            };

            var card33 = new Card
            {
                CardId = 33,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 7,
                DisplayValue = "7",
                DisplayName = "Seven of Clubs",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "ClubsSeven.png",
                Tags = "Number, Clubs, 7, Black"
            };

            var card34 = new Card
            {
                CardId = 34,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 8,
                DisplayValue = "8",
                DisplayName = "Eight of Clubs",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "ClubsEight.png",
                Tags = "Number, Clubs, 8, Black"
            };

            var card35 = new Card
            {
                CardId = 35,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 9,
                DisplayValue = "9",
                DisplayName = "Nine of Clubs",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "ClubsNine.png",
                Tags = "Number, Clubs, 9, Black"
            };

            var card36 = new Card
            {
                CardId = 36,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 10,
                DisplayValue = "10",
                DisplayName = "Ten of Clubs",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "ClubsTen.png",
                Tags = "Number, Clubs, 10, Black"
            };

            var card37 = new Card
            {
                CardId = 37,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 11,
                DisplayValue = "Jack",
                DisplayName = "Jack of Clubs",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "ClubsJack.png",
                Tags = "Face, Clubs, Jack, Black"
            };

            var card38 = new Card
            {
                CardId = 38,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 12,
                DisplayValue = "Queen",
                DisplayName = "Queen of Clubs",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "ClubsQueen.png",
                Tags = "Face, Clubs, Queen, Black"
            };

            var card39 = new Card
            {
                CardId = 39,
                Suit = "Clubs",
                SuitColor = "Black",
                SuitOrder = 12,
                DisplayValue = "King",
                DisplayName = "King of Clubs",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "ClubsKing.png",
                Tags = "Face, Clubs, King, Black"
            };

            #endregion

            #region Diamonds

            var card40 = new Card
            {
                CardId = 40,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 1,
                DisplayValue = "Ace",
                DisplayName = "Ace of Diamonds",
                IsNumber = false,
                IsAce = true,
                IsFace = false,
                IsJoker = false,
                Image = "DiamondsAce.png",
                Tags = "Ace, Diamonds, Red"
            };

            var card41 = new Card
            {
                CardId = 41,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 2,
                DisplayValue = "2",
                DisplayName = "Two of Diamonds",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "DiamondsTwo.png",
                Tags = "Number, Diamonds, 2, Red"
            };

            var card42 = new Card
            {
                CardId = 42,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 3,
                DisplayValue = "3",
                DisplayName = "Three of Diamonds",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "DiamondsThree.png",
                Tags = "Number, Diamonds, 3, Red"
            };

            var card43 = new Card
            {
                CardId = 43,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 4,
                DisplayValue = "4",
                DisplayName = "Four of Diamonds",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "DiamondsFour.png",
                Tags = "Number, Diamonds, 4, Red"
            };

            var card44 = new Card
            {
                CardId= 44,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 5,
                DisplayValue = "5",
                DisplayName = "Five of Diamonds",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "DiamondsFive.png",
                Tags = "Number, Diamonds, 5, Red"
            };

            var card45 = new Card
            {
                CardId = 45,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 6,
                DisplayValue = "6",
                DisplayName = "Six of Diamonds",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "DiamondsSix.png",
                Tags = "Number, Diamonds, 6, Red"
            };

            var card46 = new Card
            {
                CardId = 46,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 7,
                DisplayValue = "7",
                DisplayName = "Seven of Diamonds",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "DiamondsSeven.png",
                Tags = "Number, Diamonds, 7, Red"
            };

            var card47 = new Card
            {
                CardId= 47,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 8,
                DisplayValue = "8",
                DisplayName = "Eight of Diamonds",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "DiamondsEight.png",
                Tags = "Number, Diamonds, 8, Red"
            };

            var card48 = new Card
            {
                CardId = 48,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 9,
                DisplayValue = "9",
                DisplayName = "Nine of Diamonds",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "DiamondsNine.png",
                Tags = "Number, Diamonds, 9, Red"
            };

            var card49 = new Card
            {
                CardId = 49,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 10,
                DisplayValue = "10",
                DisplayName = "Ten of Diamonds",
                IsNumber = true,
                IsAce = false,
                IsFace = false,
                IsJoker = false,
                Image = "DiamondsTen.png",
                Tags = "Number, Diamonds, 10, Red"
            };

            var card50 = new Card
            {
                CardId = 50,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 11,
                DisplayValue = "Jack",
                DisplayName = "Jack of Diamonds",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "DiamondsJack.png",
                Tags = "Face, Diamonds, Jack, Red"
            };

            var card51 = new Card
            {
                CardId = 51,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 12,
                DisplayValue = "Queen",
                DisplayName = "Queen of Diamonds",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "DiamondsQueen.png",
                Tags = "Face, Diamonds, Queen, Red"
            };

            var card52 = new Card
            {
                CardId = 52,
                Suit = "Diamonds",
                SuitColor = "Red",
                SuitOrder = 12,
                DisplayValue = "King",
                DisplayName = "King of Diamonds",
                IsNumber = false,
                IsAce = false,
                IsFace = true,
                IsJoker = false,
                Image = "DiamondsKing.png",
                Tags = "Face, Diamonds, King, Red"
            };


            #endregion

            #region Jokers

            var card53 = new Card
            {
                CardId= 53,
                Suit = "Joker",
                SuitColor = "Red",
                SuitOrder = 14,
                DisplayValue = "Joker",
                DisplayName = "Joker (Red)",
                IsNumber = false,
                IsAce = false,
                IsFace = false,
                IsJoker = true,
                Image = "DeckJokerRed.png",
                Tags = "Joker, Red"
            };

            var card54 = new Card
            {
                CardId = 54,
                Suit = "Joker",
                SuitColor = "Red",
                SuitOrder = 14,
                DisplayValue = "Joker",
                DisplayName = "Joker (Black)",
                IsNumber = false,
                IsAce = false,
                IsFace = false,
                IsJoker = true,
                Image = "DeckJokerBlack.png",
                Tags = "Joker, Black"
            };

            #endregion

            deck.Add(card1);
            deck.Add(card2);
            deck.Add(card3);
            deck.Add(card4);
            deck.Add(card5);
            deck.Add(card6);
            deck.Add(card7);
            deck.Add(card8);
            deck.Add(card9);
            deck.Add(card10);
            deck.Add(card11);
            deck.Add(card12);
            deck.Add(card13);
            deck.Add(card14);
            deck.Add(card15);
            deck.Add(card16);
            deck.Add(card17);
            deck.Add(card18);
            deck.Add(card19);
            deck.Add(card20);
            deck.Add(card21);
            deck.Add(card22);
            deck.Add(card23);
            deck.Add(card24);
            deck.Add(card25);
            deck.Add(card26);
            deck.Add(card27);
            deck.Add(card28);
            deck.Add(card29);
            deck.Add(card30);
            deck.Add(card31);
            deck.Add(card32);
            deck.Add(card33);
            deck.Add(card34);
            deck.Add(card35);
            deck.Add(card36);
            deck.Add(card37);
            deck.Add(card38);
            deck.Add(card39);
            deck.Add(card40);
            deck.Add(card41);
            deck.Add(card42);
            deck.Add(card43);
            deck.Add(card44);
            deck.Add(card45);
            deck.Add(card46);
            deck.Add(card47);
            deck.Add(card48);
            deck.Add(card49);
            deck.Add(card50);
            deck.Add(card51);
            deck.Add(card52);
            deck.Add(card53);
            deck.Add(card54);

            return deck;
        }

    }
}
