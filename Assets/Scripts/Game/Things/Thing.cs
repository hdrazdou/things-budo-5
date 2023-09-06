using System;
using Things.Game.Services;
using UnityEngine;

namespace Things.Game.Things
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Thing : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private int _scoreForThing;

        [Header("Components")]
        [SerializeField] private Rigidbody2D _rb;

        #endregion

        #region Events

        public static event Action<Thing> OnCreated;
        public static event Action<Thing> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
            SetGravityScale();
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
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

        #region Public methods

        public void ChangeGravity(float changedGravityScale)
        {
            if (this == null)
            {
                return;
            }

            _rb.gravityScale = changedGravityScale;
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            GameService gameService = FindObjectOfType<GameService>();
            gameService.ChangeScore(_scoreForThing);
        }

        #endregion

        #region Private methods

        private void SetGravityScale()
        {
            FallingSpeedService fallingSpeedService = FindObjectOfType<FallingSpeedService>();
            _rb.gravityScale = fallingSpeedService.GetActualGravityScale();
        }

        #endregion
    }
}