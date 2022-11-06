using System;
using System.Threading.Tasks;
using SiriusFuture.Quiz.Core;
using UnityEngine;

namespace SiriusFuture.Quiz.Game
{
    public class QuizMetaGameStartController : MonoBehaviour
    {
        [SerializeField] private QuizMetaGameStartDialog _gameStartDialog;
        public async ValueTask StartGame()
        {
            await _gameStartDialog.ShowDialog(VoidType.Empty);
        }
    }
}