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

        [Header("Services")]
        [SerializeField] private GameService _gameService;
        [SerializeField] private FallingSpeedService _fallingSpeedService;

        [Header("Components")]
        [SerializeField] protected Rigidbody2D _rb;

        #endregion

        #region Events

        public static event Action<Thing> OnCreated;
        public static event Action<Thing> OnDestroyed;

        #endregion

        #region Properties

        protected GameService gameService => _gameService;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
            _fallingSpeedService = FindObjectOfType<FallingSpeedService>();
            _rb.gravityScale = _fallingSpeedService.GetActualGravityScale();
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

        #region Protected methods

        protected virtual void PerformActions()
        {
            _gameService.ChangeScore(_scoreForThing);
        }

        #endregion

        #region Private methods

        public void ChangeGravity(float changedGravityScale)
        {
            _rb.gravityScale = changedGravityScale;
        }

        #endregion
    }
}