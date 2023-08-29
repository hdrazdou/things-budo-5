using UnityEngine;

namespace Things
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
                Debug.Log($"Floor OnTriggerEnter2D GoodThing gravityScale {other.attachedRigidbody.gravityScale}");
                _gameService.ChangeHp(-1);
                _audioService.PlaySound(_goodThingAudioClip);
            }

            Destroy(other.gameObject);
        }

        #endregion
    }
}