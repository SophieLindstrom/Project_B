using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

        public PlayingCard() { }
        //public PlayingCard() : this(PlayingCardColor.Clubs, PlayingCardValue.Two) { }
        public PlayingCard(PlayingCardColor color, PlayingCardValue value)
        {
            Color = color;
            Value = value;
        }
        #region IComparable Implementation
        //Need only to compare value in the project

        public bool Equals(PlayingCard card) => (this.Value, this.Color) == (card.Value, card.Color);

        public override int GetHashCode() => (Value, Color).GetHashCode();
        public override bool Equals(object obj) => Equals(obj as PlayingCard);

        #region operator overloading
        public static bool operator ==(PlayingCard card1, PlayingCard card2) => card1.Equals(card2);
        public static bool operator !=(PlayingCard card1, PlayingCard card2) => !card1.Equals(card2);
        #endregion

        public int CompareTo(PlayingCard card)
        {
            if (this.Value < card.Value ) return -1;
            else if (this.Value == card.Value ) return 0;
            else return 1;

            //return (this.Value, this.Color).CompareTo((card1.Value, card1.Color));
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
                return $"{c} {Value.ToString(), -7}";
            }
        }
        public override string ToString() => ShortDescription;
        #endregion
    }
}
