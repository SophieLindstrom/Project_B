using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public PlayingCard this[int idx] => cards[idx];
        public int Count => cards.Count;
        #endregion
        #region ToString() related
        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < cards.Count; i++)
            {
                sRet += $"{cards[i]}";
                if ((i+1) % 13 == 0)
                {
                    sRet = sRet + "\n";
                }
            }
            return sRet;
            
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {
            var rnd = new Random();
            int nrOfShuffles = rnd.Next(100, 100000);
            for (int shuffle = 0; shuffle < nrOfShuffles; shuffle++)
            {
                //Swap to random cards with each other
                int loCard = rnd.Next(0, 52);
                int hiCard = rnd.Next(0, 52);

                (cards[loCard], cards[hiCard]) = (cards[hiCard], cards[loCard]);
            }
        }
        //{
        //    Random rnd = new Random();
        //    for (int i = 0; i < cards.Count; i++)
        //    {
        //        int k = rnd.Next(0, i);
        //        PlayingCard value = cards[k];
        //        cards[k] = cards[i];
        //        cards[i] = value;
        //    }

        public void Sort()
        {
            cards.Sort((x, y) => x.Value.CompareTo(y.Value));
            
        }
        #endregion
        #region Creating a fresh Deck
        public void Clear()
        {
            cards.Clear(); 
        }
        public void CreateFreshDeck()
        {
            for (PlayingCardColor color = PlayingCardColor.Clubs; color <= PlayingCardColor.Spades; color++)
            {
                for (PlayingCardValue value = PlayingCardValue.Two; value <= PlayingCardValue.Ace; value++)
                {
                    cards.Add(new PlayingCard(color, value));
                    cards[] 
                  
                    
                }
            }
           
        }
        #endregion
        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            PlayingCard temp1 = cards[^1];
            cards = cards.Take(cards.Count() - 1).ToList();
            return temp1;
            
               
            


        }
        #endregion
    }
}
