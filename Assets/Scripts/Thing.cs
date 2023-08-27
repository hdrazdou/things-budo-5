using UnityEngine;

namespace Things
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Thing : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _scoreForThing;
        [SerializeField] private GameService _gameService;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                PerformActions();
            }

            Destroy(gameObject);
        }

        #endregion

        #region Private methods

        private void PerformActions()
        {
            _gameService.AddScore(_scoreForThing);
        }

        #endregion
    }
}