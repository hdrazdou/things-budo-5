using System;
using Things.Game.Things;
using UnityEngine;

namespace Things.Game.Services
{
    public class FallingSpeedService : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [Range(1f, 100f)]
        [SerializeField] private int _percentMultiplier;
        [SerializeField] private float _currentGravityScale;
        [SerializeField] private float _limitGravityScale = 1f;
        
        [Header("Settings")]
        [SerializeField] private LevelService _levelService;

        

        private float _realMultiplier;

        #endregion

        #region Events

        public event Action<float> OnGravityChanged;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _realMultiplier = _percentMultiplier / 100f + 1;
            InvokeRepeating("IncreaseSpeed", 1.0f, 1.0f);
        }

        #endregion

        #region Public methods

        public float GetActualGravityScale()
        {
            return _currentGravityScale;
        }

        #endregion

        #region Private methods

        private void IncreaseSpeed()
        {
            _currentGravityScale *= _realMultiplier;
            _currentGravityScale = Mathf.Clamp(_currentGravityScale, 0f, _limitGravityScale);

            foreach (Thing thing in _levelService.Things)
            {
                thing.ChangeGravity(_currentGravityScale);
            }
        }

        #endregion
    }
}