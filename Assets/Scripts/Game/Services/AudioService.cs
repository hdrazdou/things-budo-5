using UnityEngine;

namespace Things
{
    public class AudioService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AudioSource _audioSource;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        #endregion

        #region Public methods

        public void PlaySound(AudioClip audioClip)
        {
            if (audioClip == null)
            {
                return;
            }

            _audioSource.PlayOneShot(audioClip);
        }

        #endregion
    }
}