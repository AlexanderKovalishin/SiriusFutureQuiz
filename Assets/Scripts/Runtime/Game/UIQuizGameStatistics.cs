using TMPro;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class UIQuizGameStatistics : MonoBehaviour
    {
        [SerializeField] private string _scoreFormat = "Score: {0}";
        [SerializeField] private string _roundFormat = "Round: {0}/{1}";
        [SerializeField] private string _attemptsFormat = "Attempts: {0}";
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _roundText;
        [SerializeField] private TMP_Text _attemptsText;

        private QuizGameStatistics _statistics; 
        public void SetStatistics(QuizGameStatistics statistics)
        {
            if (_statistics != null)
            {
                _statistics.Change -= StatisticsOnChange;
            }

            _statistics = statistics;
            if (_statistics != null)
            {
                _statistics.Change += StatisticsOnChange;
            }
        }

        private void StatisticsOnChange()
        {
            _scoreText.SetText(string.Format(_scoreFormat, _statistics.Score));
            _attemptsText.SetText(string.Format(_attemptsFormat, _statistics.Attempts));
            _roundText.SetText(string.Format(_roundFormat, _statistics.RoundIndex + 1, _statistics.RoundsCount));
        }
    }
}