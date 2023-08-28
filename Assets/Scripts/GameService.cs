using System;
using UnityEngine;

namespace Things
{
    public class GameService : MonoBehaviour
    {
        #region Variables

        private static int _cachedHp;
        private static int _cachedScore;
        [SerializeField] private int _initHp = 3;

        #endregion

        #region Events

        public static event Action<int> OnHpChanged;

        public static event Action<int> OnScoreChanged;

        #endregion

        #region Properties

        public static int Hp
        {
            get => _cachedHp;

            private set
            {
                bool needNotify = _cachedHp != value;
                _cachedHp = value;

                if (needNotify)
                {
                    OnHpChanged?.Invoke(_cachedHp);
                }
            }
        }

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

        public void ChangeScore(int score)
        {
            TotalScore += score;
        }

        #endregion

        #region Private methods

        private void SetInitScores()
        {
            TotalScore = 0;
            Hp = _initHp;
        }

        #endregion
    }
}