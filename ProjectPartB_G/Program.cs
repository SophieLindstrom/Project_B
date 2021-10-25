using System;

namespace ProjectPartB_B1
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayingCard card1 = new PlayingCard { Value = PlayingCardValue.Five, Color = PlayingCardColor.Clubs };
            PlayingCard card2 = new PlayingCard { Value = PlayingCardValue.Three, Color = PlayingCardColor.Spades };
            PlayingCard card3 = new PlayingCard { Value = PlayingCardValue.Three, Color = PlayingCardColor.Spades };
            
            DeckOfCards myDeck = new DeckOfCards();

            
            Console.WriteLine(card1.Equals(card2));
            Console.WriteLine(card2.Equals(card3));
            Console.WriteLine(card1.CompareTo(card2)); 
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            int NrOfRounds = 0;
            bool Continue = TryReadNrOfCards(out int NrOfCards) &&
                            TryReadNrOfRounds(out NrOfRounds);

            if (!Continue)
            {
                return;
            }

            //int i = 0;
            //while (NrOfRounds > i) 
            //{
            //    Console.WriteLine((i+1));
            //    i++;
            //}
            //Console.ReadKey();



            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();

            //Your code to play the game comes here
        }

        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            Console.Clear();
            string sInput;
            do
            {
                Console.WriteLine("Let's play a game of highest card with two players");
                Console.WriteLine("How many cards to deal to each player? (1-5 or Q to quit)");

                sInput = Console.ReadLine();
                if (int.TryParse(sInput, out NrOfCards) && NrOfCards >= 1 && NrOfCards <= 5)
                {
                    return true;
                }
                else if (sInput != "Q" && sInput != "q")
                {
                    
                    Console.WriteLine($"Wrong input, try again");
                }
            } while ((sInput != "Q" && sInput != "q"));
            NrOfCards = 0;
            return false;
        }

        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {
            Console.Clear();
            string sInput;
            do
            {

                Console.WriteLine("How many rounds should be play? (1-5 or Q to quit)");

                sInput = Console.ReadLine();
                if (int.TryParse(sInput, out NrOfRounds) && NrOfRounds >= 1 && NrOfRounds <= 5)
                {
                    return true;
                }
                else if (sInput != "Q" && sInput != "q")
                {
                   
                    Console.WriteLine($"\"{sInput}\" is wrong input, please try again.\n");
                }
            } while ((sInput != "Q" && sInput != "q"));
            NrOfRounds = 0;
            return false;
        }
        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            PlayingCard pc = myDeck.RemoveTopCard();
            player1.Add(pc);

        }
        
        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        { }
    }
}
