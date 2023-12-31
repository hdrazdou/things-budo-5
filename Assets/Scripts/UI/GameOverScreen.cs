using Things.Game;
using Things.Game.Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Things
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [Header("Services")]
        [SerializeField] private GameService _gameService;
        [SerializeField] private PauseService _pauseService;

        [Header("Components")]
        [SerializeField] private TMP_Text _gameOverScoreLabel;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameObject _gameOverUi;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _gameOverUi.SetActive(false);
            _gameService.OnGameOver += ShowGameOver;
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnDestroy()
        {
            _gameService.OnGameOver -= ShowGameOver;
        }

        #endregion

        #region Private methods

        private void OnExitButtonClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void OnRestartButtonClicked()
        {
            _pauseService.DisablePause();
            SceneManager.LoadScene(Scenes.StartScene);
        }

        private void ShowGameOver(int score)
        {
            _pauseService.EnablePause();
            _gameOverUi.SetActive(true);
            _gameOverScoreLabel.text = $"Your Score: {score}";
        }

        #endregion
    }
}