using System;
using System.Collections.Generic;


namespace WordFrequencyAnalyzer.Interfaces
{
    public interface IWordFrequencyAnalyzer
    {
        int CalculateHighestFrequency(string text);
        int CalculateFrequencyForWord(string text, string word);
        IList<IWordFrequency> CalculateMostFrequentWords(string text, int number);
    }
}
