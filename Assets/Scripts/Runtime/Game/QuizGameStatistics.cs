using System;

namespace SiriusFuture.Quiz.Game
{
    public class QuizGameStatistics
    {
        private readonly int _attemptsOrigin;
        public int Score { get; private set; }
        public int Attempts { get; private set; }

        public event Action Change;

        public bool HasAttempts => Attempts > 0;
        public int RoundIndex { get; set; }
        public int RoundsCount { get; }

        public QuizGameStatistics(int attempts, int roundsCount)
        {
            _attemptsOrigin = attempts;
            RoundsCount = roundsCount;
        }

        public void ReportFail()
        {
            Attempts--;
            Change?.Invoke();
        }
        
        public void ReportVictory()
        {
            Score += Attempts;
            Change?.Invoke();
        }
        
        public void ReportRoundComplete()
        {
            RoundIndex++;
            Change?.Invoke();
        }
        
        public void Reset()
        {
            Score = 0;
            Attempts = _attemptsOrigin;
            RoundIndex = 0;
            Change?.Invoke();
        }
        
        public void ResetAttempts()
        {
            Attempts = _attemptsOrigin;
            Change?.Invoke();
        }

    }
}