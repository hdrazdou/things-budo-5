using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Things
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gameOverScoreLabel;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _gameOverUi;
        [SerializeField] private GameService _gameService;

        private void Start()
        {
            _gameOverUi.SetActive(false);
            _gameService.OnGameOver += ShowGameOver;
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            SceneManager.LoadScene(Scenes.StartScene);
        }

        private void OnDestroy()
        {
            _gameService.OnGameOver -= ShowGameOver;
        }

        private void ShowGameOver(int score)
        {
            _gameOverUi.SetActive(true);
            _gameOverScoreLabel.text = $"Your Score: {score}";
        }
    }
}