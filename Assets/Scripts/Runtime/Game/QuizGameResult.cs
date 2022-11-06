namespace SiriusFuture.Quiz.Game
{
    public class QuizGameResult
    {
        public QuizGameResult(QuizGameCompleteStatus completeStatus)
        {
            CompleteStatus = completeStatus;
        }

        public QuizGameCompleteStatus CompleteStatus { get; }
    }
}