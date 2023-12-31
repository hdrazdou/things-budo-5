using UnityEngine;

namespace Things.Game
{
    public class Platform : MonoBehaviour
    {
        #region Unity lifecycle

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

        private void SetPosition(Vector3 mousePosition)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = mousePosition.x;
            transform.position = currentPosition;
        }

        #endregion
    }
}