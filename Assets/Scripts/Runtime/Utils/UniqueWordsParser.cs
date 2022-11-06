using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace SiriusFuture.Quiz.Utils
{
    public class UniqueWordsParser
    {
        private readonly bool _toLower;
        private readonly Regex _regex;
        private readonly int _minWordLength;
        private readonly char[] _splitChars;

        public UniqueWordsParser(string ignoreWordsPattern, bool toLower, int minWordLength, char[] splitChars)
        {
            _regex = new Regex(ignoreWordsPattern, RegexOptions.Compiled);
            _toLower = toLower;
            _minWordLength = minWordLength;
            _splitChars = splitChars;
        }

        public string[] Parse(string text)
        {
            var splitText = _toLower
                ? text.ToLower()
                : text;
            var allWords = splitText.Split(_splitChars);
            var wordsSet = new HashSet<string>();
            foreach (var word in allWords)
            {
                if (string.IsNullOrEmpty(word)) continue;
                if (word.Length < _minWordLength) continue;
                if (_regex.IsMatch(word)) continue;
                if (wordsSet.Contains(word)) continue;
                wordsSet.Add(word);
            }
            return wordsSet.ToArray();
        }
    }
}