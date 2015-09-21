using System.Collections.Generic;
using BiggResponsive.Domain.Models;

namespace BiggResponsive.Domain.Interfaces
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAll();
        IEnumerable<Card> GetMany(int numberOfCards);
    }
}
