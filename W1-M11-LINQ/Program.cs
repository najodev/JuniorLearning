using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqFaroShuffle

{

    class Program {
        static void Main(string[] args)
        {
            /// <summary> 
            /// Contains all the cards in order in a deck of cards
            /// </summary>
            var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                from r in Ranks()
                .LogQuery("Rank Generation")
                select new { Suit = s, Rank = r })
                .LogQuery("Starting Deck");

            /// <summary> 
            /// Amount of itteration until the deck is the same
            /// </summary>
            var times = 0;

            var shuffle = startingDeck;

            /// <summary> 
            /// Prints out the shuffled deck
            /// </summary>
            foreach (var c in shuffle)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();

            /// <summary> 
            /// Simpler code to do the same things
            /// </summary>
            shuffle = startingDeck;

            /// <summary> 
            /// Count how many times it takes for the deck to become unshufled
            /// </summary>
            do
            {
                shuffle = shuffle.Skip(26)
                    .LogQuery("Bottom Half")
                    .InterleaveSequenceWith(
                            shuffle.Take(26)
                            .LogQuery("Top Half"))
                    .LogQuery("Shuffle")
                    .ToArray();

                foreach (var card in shuffle)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
                times++;

            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }

        /// <summary> 
        /// Suits function
        /// </summary>
        /// <returns>Returns the next suit in the sequence</returns>
        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return  "hearts";
            yield return "spades";
        }

        /// <summary> 
        /// Ranks function
        /// </summary>
        /// <returns>Returns the next rank in the sequence</returns>
        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }

    }

}


