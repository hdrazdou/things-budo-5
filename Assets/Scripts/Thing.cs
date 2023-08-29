using UnityEngine;

namespace Things
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Thing : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _scoreForThing;
        [SerializeField] protected GameService _gameService;
        [SerializeField] protected Rigidbody2D _rb;
        [SerializeField] private FallingSpeedService _fallingSpeedService;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _fallingSpeedService = FindObjectOfType<FallingSpeedService>();
            _rb.gravityScale = _fallingSpeedService.GetActualGravityScale();
            _fallingSpeedService.OnGravityChanged += ChangeGravity;
        }

        private void OnDestroy()
        {
            _fallingSpeedService.OnGravityChanged -= ChangeGravity;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                PerformActions();
                Destroy(gameObject);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            _gameService.ChangeScore(_scoreForThing);
        }

        #endregion

        #region Private methods

        private void ChangeGravity(float changedGravityScale)
        {
            _rb.gravityScale = changedGravityScale;
        }

        #endregion
    }
}