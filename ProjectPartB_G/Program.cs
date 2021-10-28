﻿using System;

namespace ProjectPartB_B1
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();

            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();

            #region Playing the game

            int _NrOfCards = 0;
            int _NrOfRounds = 0;
            bool Continue = TryReadNrOfCards(out _NrOfCards) &&
                            TryReadNrOfRounds(out _NrOfRounds);

            if (!Continue)
            {
                return;
            }

            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();


            for (int i = 0; i < _NrOfRounds; i++)
            {
                //Informing the user what round is being played.
                Console.WriteLine($"Playing round {i + 1} out of {_NrOfRounds}\n------------------------");

                //Deal the cards from the top of the deck to player 1 and player 2.
                Deal(myDeck, _NrOfCards, player1, player2);

                //Amount of cards given and amount of cards left in deck.
                Console.WriteLine($"Gave {_NrOfCards} card(s) each to the players from the top of the deck. Deck has now {myDeck.Count} card(s).\n");

                Console.WriteLine($"Player1 hand with {_NrOfCards} cards");
                Console.WriteLine($"Lowest card in hand is: {player1.Lowest}");
                Console.WriteLine($"Highest card in hand is: {player1.Highest}");
                Console.WriteLine($"{player1}\n");

                Console.WriteLine($"Player2 hand with {_NrOfCards} cards");
                Console.WriteLine($"Lowest card in hand is: {player2.Lowest}");
                Console.WriteLine($"Highest card in hand is: {player2.Highest}");
                Console.WriteLine($"{player2}\n");

                DetermineWinner(player1, player2);
                player1.Clear();
                player2.Clear();

            }
            #endregion

        }
        /// <summary>}
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            Console.Clear();
            Console.WriteLine("Let's play a game of highest card with two players.");
            string sInput;
            NrOfCards = 0;
            do
            {
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
            NrOfRounds = 0;
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

                    Console.WriteLine($"Wrong input, try again");
                }
            } while ((sInput != "Q" && sInput != "q"));
            
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
            for (int i = 0; i < nrCardsToPlayer; i++)
            {

                player1.Add(myDeck.RemoveTopCard());
                player2.Add(myDeck.RemoveTopCard());
                
            }


        }

        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {

            string WinningCard = player1.Highest.CompareTo(player2.Highest) switch
            {
                1 => "Player1 wins!",
                0 => "It's a tie!",
                -1 => "Player2 wins!",
                _ => throw new NotImplementedException()
            };
            Console.WriteLine($"{WinningCard}\n");

            
        }
    }
}