using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LinqFaroShuffle

{

    public static class Extensions

    {
        /// <summary> 
        /// Pass to enums that are to be interleaved
        /// </summary>
        /// <param name="first">
        ///  The enumerator that initially utilises this function is passed as first, the first half that is to be interleaved
        /// </param> 
        /// <param name="second">
        ///  The enumerator that is passed as a paramter the second half that is to be interleaved
        /// </param> 
        /// <returns>Return Each object in the interleaved enum</returns>
        public static IEnumerable<T> InterleaveSequenceWith<T> (this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current;
                yield return secondIter.Current;
            }
        }

        /// <summary> 
        /// Check if the two parameter sequences are equal 
        /// </summary>
        /// <param name="first">
        /// Refrencing the class that called this method 
        /// </param> 
        /// <param name="second">
        /// The sequence that is passed as a parameter
        /// </param> 

        public static bool SequenceEquals<T>
            (this IEnumerable<T> first, IEnumerable<T> second)
            {
                var firstIter = first.GetEnumerator();
                var secondIter = second.GetEnumerator();
                while (firstIter.MoveNext() && secondIter.MoveNext())
                {
                    if (!firstIter.Current.Equals(secondIter.Current))
                    {
                        return false;
                    }
                }
                return true;
            }
        public static IEnumerable<T> LogQuery<T>
            (this IEnumerable<T> sequence, string tag)
            {
                // File.AppendText creates a new file if the file doesn't exist.
                using (var writer = File.AppendText("debug.log"))
                {
                    writer.WriteLine($"Executing Query {tag}");
                }

                return sequence;
            }

    }
}
