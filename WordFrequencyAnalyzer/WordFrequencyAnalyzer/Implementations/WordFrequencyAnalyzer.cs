using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WordFrequencyAnalyzer.Interfaces;

namespace WordFrequencyAnalyzer.Implementations
{
    public class WordFrequencyAnalyzerImpl : IWordFrequencyAnalyzer
    {
        /// Processes the input text to calculate the frequency of each word.
        private Dictionary<string, int> GetWordFrequencies(string text)
        {
            var wordFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (Regex.IsMatch(word, "^[a-zA-Z]+$"))
                {
                    var lowerWord = word.ToLower();
                    if (wordFrequency.ContainsKey(lowerWord))
                    {
                        wordFrequency[lowerWord]++;
                    }
                    else
                    {
                        wordFrequency[lowerWord] = 1;
                    }
                }
                else
                {
                    throw new ArgumentException("Input text contains invalid characters.");
                }
            }

            return wordFrequency;
        }

        /// Calculates the highest frequency of any word in the input text.
        public int CalculateHighestFrequency(string text)
        {
            var wordFrequency = GetWordFrequencies(text);
            return wordFrequency.Values.Max();
        }


        /// Calculates the frequency of a specific word in the input text.
        public int CalculateFrequencyForWord(string text, string word)
        {
            var wordFrequency = GetWordFrequencies(text);
            return wordFrequency.TryGetValue(word.ToLower(), out int frequency) ? frequency : 0;
        }

        /// Calculates the most frequent words in the input text, returning the specified number of top results.
        public IList<IWordFrequency> CalculateMostFrequentWords(string text, int number)
        {
            var wordFrequency = GetWordFrequencies(text);

            return wordFrequency
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key)
                .Take(number)
                .Select(kvp => new WordFrequency { Word = kvp.Key, Frequency = kvp.Value })
                .Cast<IWordFrequency>()
                .ToList();
        }
    }
}
