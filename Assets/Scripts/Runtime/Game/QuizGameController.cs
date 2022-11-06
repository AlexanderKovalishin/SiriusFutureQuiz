using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizGameController : MonoBehaviour
    {
        [SerializeField] private QuizRoundController _roundController;

        public async ValueTask<QuizGameResult> RunGame(string[] wordsSet)
        {
            var wordsQueue = new Queue<string>(wordsSet);
            while (wordsQueue.Count > 0)
            {
                var word = wordsQueue.Dequeue();
                var roundResult = await _roundController.RunRound(word);
                switch (roundResult.CompleteStatus)
                {
                    case QuizRoundCompleteStatus.Fail:
                        return new QuizGameResult(QuizGameCompleteStatus.Fail);
                    case QuizRoundCompleteStatus.Break:
                        return new QuizGameResult(QuizGameCompleteStatus.Break);
                }
            }

            return new QuizGameResult(QuizGameCompleteStatus.Success);
        }
    }
}