using Things.Game.Services;
using UnityEngine;

namespace Things.Game
{
    public class Floor : MonoBehaviour
    {
        #region Variables

        [Header("Services")]
        [SerializeField] private GameService _gameService;
        [SerializeField] private AudioService _audioService;

        [Header("Settings")]
        [SerializeField] private AudioClip _goodThingAudioClip;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.GoodThing))
            {
                _gameService.ChangeHp(-1);
                _audioService.PlaySound(_goodThingAudioClip);
            }

            Destroy(other.gameObject);
        }

        #endregion
    }
}