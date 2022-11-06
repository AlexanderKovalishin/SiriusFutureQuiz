using UnityEngine;

namespace SiriusFuture.Quiz.Config
{
    [CreateAssetMenu(menuName = "SiriusFuture/Quiz/QuizConfig", fileName = "QuizConfig", order = 0)]
    public partial class QuizConfig : ScriptableObject
    {
        [Header("Game")]
        [SerializeField] private int _minWordLength = 3;
        [SerializeField] private int _roundsCount = 10;
        [Header("System")]
        [SerializeField] private TextAsset _text;
        [SerializeField] private UniqueWordsParserConfig _parserConfig;

        public int RoundsCount => _roundsCount;
        
        public string[] CreateWordsSet()
        {
            return _parserConfig.Parse(_text.text, _minWordLength);
        }
    }
}
