using UnityEngine;

namespace SiriusFuture.Quiz.Config
{
    [CreateAssetMenu(menuName = "SiriusFuture/Quiz/QuizConfig", fileName = "QuizConfig", order = 0)]
    public partial class QuizConfig : ScriptableObject
    {
        [Header("Game")]
        [SerializeField] private int _minWordLength = 3;
        [SerializeField] private int _maxWordLength = 10;
        [SerializeField] private int _roundsCount = 10;
        [SerializeField] private int _maxLettersCount = 16;
        [SerializeField] private int _attemptsCount = 16;
        [Header("System")]
        [SerializeField] private TextAsset _text;
        [SerializeField] private UniqueWordsParserConfig _parserConfig;

        public int RoundsCount => _roundsCount;
        public int MaxLettersCount => _maxLettersCount;
        public int AttemptsCount => _attemptsCount;
        
        public string[] CreateWordsSet()
        {
            return _parserConfig.Parse(_text.text, _minWordLength, _maxWordLength);
        }
    }
}
