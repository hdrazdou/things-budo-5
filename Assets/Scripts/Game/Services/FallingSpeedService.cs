using System.Collections;
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

        private float _realMultiplier;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _realMultiplier = _percentMultiplier / 100f + 1;

            StartCoroutine(IncreaseSpeed());
        }

        #endregion

        #region Public methods

        public float GetActualGravityScale()
        {
            return _currentGravityScale;
        }

        #endregion

        #region Private methods

        private IEnumerator IncreaseSpeed()
        {
            GameService gameService = FindObjectOfType<GameService>();
            LevelService levelService = FindObjectOfType<LevelService>();

            yield return new WaitForSeconds(1f);

            while (!gameService.IsGameOver)
            {
                _currentGravityScale *= _realMultiplier;
                _currentGravityScale = Mathf.Clamp(_currentGravityScale, 0f, _limitGravityScale);

                if (levelService.Things != null)
                {
                    foreach (Thing thing in levelService.Things)
                    {
                        thing.ChangeGravity(_currentGravityScale);
                    }
                }

                yield return new WaitForSeconds(1.1f);
            }
        }

        #endregion
    }
}