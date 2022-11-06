namespace SiriusFuture.Quiz.Game
{
    public class QuizRoundResult
    {
        public QuizRoundResult(QuizRoundCompleteStatus completeStatus)
        {
            CompleteStatus = completeStatus;
        }

        public QuizRoundCompleteStatus CompleteStatus { get; }
    }
}