using System;
using System.Collections.Generic;

namespace PDFTemplate
{
    /// <summary>
    /// String class extender
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Split string extension.
        /// Modified from the original version using IEnumerable<string> result and 'yeld return'.
        /// </summary>
        /// <param name="text">String to be split</param>
        /// <param name="chunk_length">Length of chunk</param>
        /// <returns>Splitted enumerable set</returns>
        public static string[] Split(this string text, int chunk_length)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException();

            if (chunk_length < 1)
                throw new ArgumentException();

            int _n_chunks = (int)Math.Ceiling((double)(text.Length) / (double)(chunk_length));
            
            string[] _chunks = new string[_n_chunks];

            for (int _i = 0; _i < _n_chunks; _i++)
            {
                int _start_index = 0, _len = 0;

                _start_index = chunk_length * _i;
                _len = text.Length - (_start_index);

                _chunks[_i] = text.Substring(_start_index, Math.Min(chunk_length, _len));
            }

            return _chunks;
        }
    }
}
