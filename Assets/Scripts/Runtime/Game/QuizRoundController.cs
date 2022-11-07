using System.Threading.Tasks;
using SiriusFuture.Quiz.Core;
using SiriusFuture.Quiz.Core.Service;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SiriusFuture.Quiz.Game
{
    public class QuizRoundController: MonoBehaviour
    {
        [SerializeField] private QuizAnswer _answer;
        [SerializeField] private QuizLettersChooser _lettersChooser;
        [SerializeField] private float _completeAnimationDelay = 0.5f;
        [SerializeField] private float _completeRoundDelay = 0.5f;
        [SerializeField] private Physics2DRaycaster _raycaster;
        
        private TaskCompletionSource<QuizRoundResult> _completion;
        private Timeline _timeline; // inject
        private QuizGameStatistics _gameStatistics;
        private void Awake()
        {
            _timeline = ServiceLocator.Locate<Timeline>();
            _lettersChooser.ClickLetter += LettersChooserOnClickLetter;
        }

        private void LettersChooserOnClickLetter(char letterValue)
        {
            var isLetterOpened = _answer.OpenLetter(letterValue);
            if (isLetterOpened)
            {
                _lettersChooser.SuccessLetters(letterValue);
            }
            else
            {
                _lettersChooser.FailLetters(letterValue);
                _gameStatistics.ReportFail();

                if (!_gameStatistics.HasAttempts)
                {
                    _raycaster.enabled = false;
                    _timeline.PosyDelayed(_completeRoundDelay, HideLettersChooser, QuizRoundCompleteStatus.Fail);
                    return;
                }

            }

            if (_answer.IsComplete())
            {
                _raycaster.enabled = false;
                _timeline.PosyDelayed(_completeRoundDelay, HideLettersChooser, QuizRoundCompleteStatus.Success);
            }
        }

        public async ValueTask<QuizRoundResult> RunRound(string word, int maxLettersCount, QuizGameStatistics gameStatistics)
        {
            _gameStatistics = gameStatistics;
            
            Debug.Log(word);
            _answer.SetAnswer(word);
            _lettersChooser.CreateLetters(word, maxLettersCount);
            _completion = new TaskCompletionSource<QuizRoundResult>();
            return await _completion.Task;
        }

        private void HideLettersChooser(QuizRoundCompleteStatus status)
        {
            _lettersChooser.HideAllLetters();
            _answer.HideAllLetters();
            _timeline.PosyDelayed(_completeAnimationDelay, CompleteRound, status);
        }

        private void CompleteRound(QuizRoundCompleteStatus status)
        {
            _raycaster.enabled = true;
            _gameStatistics.ReportVictory();
            _completion.SetResult(new QuizRoundResult(status));
        }
    }
}