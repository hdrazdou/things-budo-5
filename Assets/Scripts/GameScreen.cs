using TMPro;
using UnityEngine;

namespace Things
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            GameService.OnScoreChanged += UpdateScore;
            UpdateScore(GameService.TotalScore);
        }

        private void OnDestroy()
        {
            GameService.OnScoreChanged -= UpdateScore;
        }

        #endregion

        #region Private methods

        private void UpdateScore(int score)
        {
            _scoreLabel.text = $"Score: {score}";
        }

        #endregion
    }
}