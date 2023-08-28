using UnityEngine;

namespace Things
{
    public class Floor : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameService _gameService;

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
            }

            Destroy(other.gameObject);
        }

        #endregion
    }
}