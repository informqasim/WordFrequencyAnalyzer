using WordFrequencyAnalyzer.Interfaces;

namespace WordFrequencyAnalyzer.Implementations
{
    public class WordFrequency : IWordFrequency
    {
        public string Word { get; set; }
        public int Frequency { get; set; }
    }
}
