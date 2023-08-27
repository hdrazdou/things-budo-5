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

        private void Update()
        {
            MoveWithMouse();
        }

        #endregion

        #region Private methods

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            SetPosition(worldMousePosition);
        }

        private void OnStartButtonClicked()
        {
            SceneManager.LoadScene(Scenes.GameScene);
        }

        private void SetPosition(Vector3 mousePosition)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = mousePosition.x;
            transform.position = currentPosition;
        }

        #endregion
    }
}