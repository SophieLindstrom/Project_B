using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        #region Pick and Add related
        public void Add(PlayingCard card)
        {
           cards.Add(card);
        }
        #endregion
        public override void Clear()
        {
            cards.Clear();
        }
        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {
                Sort();
                PlayingCard highest = cards[^1];
                return highest;
                
            }
         }
        public PlayingCard Lowest
        {
            get
            {
                Sort();
                PlayingCard lowest = cards[0];
                return lowest;
            }
        }
        public override string ToString() 
        { string sRet = ""; for (int i = 0; i < cards.Count; i++) 
            { sRet += $"{cards[i]}"; } 
            return sRet; }
        #endregion
    }
}
