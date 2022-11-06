using System.Linq;
using SiriusFuture.Quiz.Config;
using SiriusFuture.Quiz.Core.Collections;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizMetaGameController : MonoBehaviour
    {
        [SerializeField] private QuizConfig _quizConfig;
        [SerializeField] private QuizGameController _gameController;
        [SerializeField] private QuizMetaGameStartController _gameStartController;
        
        private string[] _wordsSet;
        
        private void Awake()
        {
            _wordsSet = _quizConfig.CreateWordsSet();
        }

        private async void Start()
        {
            while (true)
            {
                await _gameStartController.StartGame();
                var wordsSetShuffle = _wordsSet.Take(_quizConfig.RoundsCount).ToArray();
                wordsSetShuffle.Shuffle();
                var roundsCount = Mathf.Min(_quizConfig.RoundsCount, _wordsSet.Length);
                await _gameController.RunGame(wordsSetShuffle.Take(roundsCount).ToArray());
            }
        }
    }
}