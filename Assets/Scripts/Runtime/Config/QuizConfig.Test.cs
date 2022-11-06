using System.Text;
using UnityEngine;

namespace SiriusFuture.Quiz.Config
{
    public partial class QuizConfig
    {
        public void TestParse()
        {
            var words = _parserConfig.Parse(_text.text, _minWordLength);
            var wordsText = new StringBuilder();
            foreach (var word in words)
            {
                wordsText.Append(word);
                wordsText.Append(" ");
            }
            Debug.Log(wordsText.ToString());
        }
    }
}