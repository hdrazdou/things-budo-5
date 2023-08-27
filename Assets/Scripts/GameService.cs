using System;
using UnityEngine;

namespace Things
{
    public class GameService : MonoBehaviour
    {
        #region Variables

        private static int _cachedScore;

        #endregion

        #region Events

        public static event Action<int> OnScoreChanged;

        #endregion

        #region Properties

        public static int TotalScore
        {
            get => _cachedScore;

            private set
            {
                bool needNotify = _cachedScore != value;
                _cachedScore = value;

                if (needNotify)
                {
                    OnScoreChanged?.Invoke(_cachedScore);
                }
            }
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            SetInitScores();
        }

        #endregion

        #region Public methods

        public void AddScore(int score)
        {
            TotalScore += score;
        }

        #endregion

        #region Private methods

        private void SetInitScores()
        {
            TotalScore = 0;
        }

        #endregion
    }
}