using UnityEngine;

namespace Things.Game
{
    public class PauseService : MonoBehaviour
    {
        #region Public methods

        public void DisablePause()
        {
            Time.timeScale = 1;
        }

        public void EnablePause()
        {
            Time.timeScale = 0;
        }

        #endregion
    }
}