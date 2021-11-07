using System;

namespace ProjectPartB_B1
{
    public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
    {
        public PlayingCardColor Color { get; init; }
        public PlayingCardValue Value { get; init; }

        public PlayingCard(PlayingCardColor color, PlayingCardValue value)
        {
            Color = color;
            Value = value;
        }
        #region IComparable Implementation
        //Need only to compare value in the project

        public int CompareTo(PlayingCard card)
        {
            return Value.CompareTo(card.Value);
        }
        #endregion

        #region ToString() related
        public string ShortDescription
        {
            get
            {
                char c = Color switch
                {
                    PlayingCardColor.Clubs => '\u2663',
                    PlayingCardColor.Spades => '\u2660',
                    PlayingCardColor.Hearts => '\u2665',
                    _ => '\u2666'
                };
                return $"{c} {Value.ToString(),-7}";
            }
        }
        public override string ToString() => ShortDescription;
        #endregion
    }
}
