

namespace BiggResponsive.Domain.Interfaces
{
    public interface ICard
    {
        int CardId { get; set; }
        string Suit { get; set; }
        string SuitColor { get; set; }
        int SuitOrder { get; set; }
        string DisplayValue { get; set; } // 'Jack'
        string DisplayName { get; set; } // 'Jack of Clubs'
        bool IsNumber { get; set; }
        bool IsAce { get; set; }
        bool IsFace { get; set; }
        bool IsJoker { get; set; }
        string Image { get; set; }
        int BlackJackValue { get; set; } 
    }
}
