using System;
using System.Collections.Generic;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;

namespace BiggResponsive.Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository repository;

        public CardService(ICardRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Card> GetAllCards()
        {
            var cards = this.repository.GetAll();
            return cards;
        }

        public IEnumerable<Card> GetSomeCards(int numberOfCards)
        {
            var cards = this.repository.GetMany(numberOfCards);
            return cards;
        }

    }
}