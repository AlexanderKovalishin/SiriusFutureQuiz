using System.Collections.Generic;
using System.Threading.Tasks;
using SiriusFuture.Quiz.Core;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizGameController : MonoBehaviour
    {
        [SerializeField] private QuizRoundController _roundController;
        [SerializeField] private UIBlackout _blackout;
        [SerializeField] private UIQuizGameOverDialog _gameOverDialog;
        [SerializeField] private UIQuizVictoryDialog _completeRoundDialog;
        [SerializeField] private UIQuizVictoryDialog _completeGameDialog;
        
        public async ValueTask<QuizGameResult> RunGame(string[] wordsSet, int maxLettersCount, QuizGameStatistics statistics)
        {
            var wordsQueue = new Queue<string>(wordsSet);
            while (wordsQueue.Count > 0)
            {
                var word = wordsQueue.Dequeue();
                var roundResult = await _roundController.RunRound(word, maxLettersCount, statistics);
                switch (roundResult.CompleteStatus)
                {
                    case QuizRoundCompleteStatus.Fail:
                        using (_blackout.Show())
                        {
                            await _gameOverDialog.ShowDialog(VoidType.Empty);
                        }
                        return new QuizGameResult(QuizGameCompleteStatus.Fail);
                    case QuizRoundCompleteStatus.Break:
                        return new QuizGameResult(QuizGameCompleteStatus.Break);
                }
                statistics.ResetAttempts();
                using (_blackout.Show())
                {
                    if (wordsQueue.Count > 0)
                    {
                        await _completeRoundDialog.ShowDialog(statistics);
                        statistics.ReportRoundComplete();
                    }
                    else
                    {
                        await _completeGameDialog.ShowDialog(statistics);
                    }
                }
            }
            return new QuizGameResult(QuizGameCompleteStatus.Success);
        }
    }
}