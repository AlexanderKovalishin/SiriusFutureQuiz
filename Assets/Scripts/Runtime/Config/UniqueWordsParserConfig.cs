using SiriusFuture.Quiz.Utils;
using UnityEngine;

namespace SiriusFuture.Quiz.Config
{
    [CreateAssetMenu(menuName = "SiriusFuture/Quiz/UniqueWordsParserConfig", fileName = "UniqueWordsParserConfig", order = 0)]
    public partial class UniqueWordsParserConfig : ScriptableObject
    {
        [SerializeField] private string _ignoreWordsPattern = "[^a-z]";
        [SerializeField] private bool _toLower = true;
        [SerializeField] private char[] _splitChars = { ' ', '\n', '\r' };
        
        public string[] Parse(string text, int minWordLength, int maxWordLength)
        {
            var parser = new UniqueWordsParser(_ignoreWordsPattern, _toLower, minWordLength, maxWordLength, _splitChars);
            return parser.Parse(text);
        }
    }
}