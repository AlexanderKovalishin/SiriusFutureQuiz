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
        [SerializeField] private UIQuizGameStatistics _gameStatistics;

        private string[] _wordsSet;
        
        private void Awake()
        {
            _wordsSet = _quizConfig.CreateWordsSet();
        }

        private async void Start()
        {
            var wordsSetShuffle = _wordsSet.Take(_quizConfig.RoundsCount).ToArray();
            var roundsCount = Mathf.Min(_quizConfig.RoundsCount, _wordsSet.Length);
            var gameStatistics = new QuizGameStatistics(_quizConfig.AttemptsCount, roundsCount);
            _gameStatistics.SetStatistics(gameStatistics);
            while (true)
            {
                await _gameStartController.StartGame();
                gameStatistics.Reset();
                wordsSetShuffle.Shuffle();
                await _gameController.RunGame(wordsSetShuffle.Take(roundsCount).ToArray(), _quizConfig.MaxLettersCount, gameStatistics);
            }
        }
    }
}