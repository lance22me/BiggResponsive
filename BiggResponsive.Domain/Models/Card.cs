using BiggResponsive.Domain.Interfaces;

namespace BiggResponsive.Domain.Models
{
    public class Card : ICard
    {
        public int CardId { get; set; }
        public string Suit { get; set; }
        public string SuitColor { get; set; }
        public int SuitOrder { get; set; }
        public string DisplayValue { get; set; }
        public string DisplayName { get; set; }
        public bool IsNumber { get; set; }
        public bool IsAce { get; set; }
        public bool IsFace { get; set; }
        public bool IsJoker { get; set; }
        public string Image { get; set; }
        public int BlackJackValue { get; set; }
        public string Tags { get; set; }
    }
}
