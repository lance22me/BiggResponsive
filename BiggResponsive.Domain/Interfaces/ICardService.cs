using System.Collections.Generic;
using BiggResponsive.Domain.Models;

namespace BiggResponsive.Domain.Interfaces
{
    public interface ICardService
    {
        IEnumerable<Card> GetAllCards();
        IEnumerable<Card> GetSomeCards(int numberOfCards);
    }
}
