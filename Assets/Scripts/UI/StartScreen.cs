using Things.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Things
{
    public class StartScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _startButton;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
        }

        #endregion

        #region Private methods

        private void OnStartButtonClicked()
        {
            SceneManager.LoadScene(Scenes.GameScene);
        }

        #endregion
    }
}