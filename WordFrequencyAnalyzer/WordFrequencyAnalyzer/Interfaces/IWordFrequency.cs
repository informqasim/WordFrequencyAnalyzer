using System;

namespace WordFrequencyAnalyzer.Interfaces
{
    public interface IWordFrequency
    {
        string Word { get; set; }
        int Frequency { get; set; }
    }
}