using Assignment7.Models;

namespace Assignment7.ViewModels
{
    public class PunctuationWrongAnswer
    {
        public string OriginalText { get; set; }
        public string EnteredText { get; set; }
        public Score Score { get; set; }
    }
}