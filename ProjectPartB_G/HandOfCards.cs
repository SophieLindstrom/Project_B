using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        List<PlayingCard> hand = new List<PlayingCard>();
        #region Pick and Add related
        public void Add(PlayingCard card)
        {
          hand.Add(card);
        }
        #endregion
        public new void Sort() 
        {
            hand.Sort((x, y) => x.Value.CompareTo(y.Value));
            //hand.Sort();
        }
        public override void Clear()
        {
            hand.Clear();
        }
        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {
                Sort();
                PlayingCard highest = hand[^1];
                return highest;
                
            }
         }
        public PlayingCard Lowest
        {
            get
            {
                Sort();
                PlayingCard lowest = hand[0];
                return lowest;
            }
        }
        public override string ToString() 
        { string sRet = ""; for (int i = 0; i < hand.Count; i++) 
            { sRet += $"{hand[i]}"; } 
            return sRet; }
        #endregion
    }
}
