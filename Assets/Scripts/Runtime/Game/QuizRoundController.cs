using System;
using System.Threading.Tasks;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizRoundController: MonoBehaviour
    {
        [SerializeField] private QuizAnswer _answer;
        
        private TaskCompletionSource<QuizRoundResult> _completion;
        public async ValueTask<QuizRoundResult> RunRound(string word)
        {
            Debug.Log(word);
            _answer.SetAnswer(word);
            _completion = new TaskCompletionSource<QuizRoundResult>();
            await _completion.Task;
            return new QuizRoundResult(QuizRoundCompleteStatus.Success);
        }
    }
}