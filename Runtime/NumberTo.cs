using System;
using System.Text;

namespace BBUnity.Conversion {

    /// <summary>
    /// Conversion methods from integers to common string representations.
    /// </summary>
    public static class NumberTo {

        /// <summary>
        /// Converts an integer to a Roman numeral string using standard subtractive notation.
        /// </summary>
        /// <param name="number">An integer between 1 and 3999 inclusive.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="number"/> is less than 1 or greater than 3999.
        /// </exception>
        public static string RomanNumeral(int number) {
            if(number < 1 || number > 3999) {
                throw new ArgumentOutOfRangeException("number", "Number must be between 1 and 3999 inclusive.");
            }

            return NumberToRomanNumerals.Convert(number);
        }

        /// <summary>
        /// Converts a non-negative integer to its uppercase hexadecimal string representation.
        /// </summary>
        /// <param name="number">A non-negative integer.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="number"/> is negative.
        /// </exception>
        public static string Hex(int number) {
            if(number < 0) {
                throw new ArgumentOutOfRangeException("number", "Number must be non-negative.");
            }

            return number.ToString("X");
        }

        /// <summary>
        /// Converts a non-negative integer to a zero-padded retro score string.
        /// </summary>
        /// <param name="score">A non-negative integer score.</param>
        /// <param name="places">
        /// The number of leading zeroes to prepend. Must be at least 1. Defaults to 10.
        /// When the score has more digits than the available padding capacity the padding
        /// is automatically reduced to fit.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="score"/> is negative or <paramref name="places"/> is less than 1.
        /// </exception>
        public static string RetroScore(int score, int places = 10) {
            if(score < 0) {
                throw new ArgumentOutOfRangeException("score", "Score must be non-negative.");
            }
            if(places < 1) {
                throw new ArgumentOutOfRangeException("places", "Places must be at least 1.");
            }

            return NumberToRetroScore.Convert(score, places);
        }
    }

    internal static class NumberToRetroScore {
        private static readonly StringBuilder Builder = new StringBuilder(10);

        internal static string Convert(int number, int places) {
            int remainingPlaces = 10 - NumberOfDigits(number);
            places = places < remainingPlaces ? places : remainingPlaces;

            Builder.Clear();

            for(int i = 0; i < places; ++i) {
                Builder.Append("0");
            }

            Builder.Append(number);

            return Builder.ToString();
        }

        private static int NumberOfDigits(int number) {
            if(number < 10)        return 1;
            if(number < 100)       return 2;
            if(number < 1000)      return 3;
            if(number < 10000)     return 4;
            if(number < 100000)    return 5;
            if(number < 1000000)   return 6;
            if(number < 10000000)  return 7;
            if(number < 100000000) return 8;
            if(number < 1000000000) return 9;

            return 10;
        }
    }

    internal static class NumberToRomanNumerals {
        private static readonly int[]    Values  = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static readonly string[] Symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        internal static string Convert(int number) {
            var result = new StringBuilder();

            for(int i = 0; i < Values.Length; i++) {
                while(number >= Values[i]) {
                    result.Append(Symbols[i]);
                    number -= Values[i];
                }
            }

            return result.ToString();
        }
    }
}
