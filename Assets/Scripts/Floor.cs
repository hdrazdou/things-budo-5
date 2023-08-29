using UnityEngine;

namespace Things
{
    public class Floor : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameService _gameService;
        [SerializeField] private AudioService _audioService;
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