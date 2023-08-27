using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Things
{
    public class SpawnService : MonoBehaviour
    {
        private void Start()
        {
            InvokeRepeating("CreateThing", 1.0f, 1.0f);
        }

        #region Variables

        [SerializeField] private Vector2 _xLimitation;
        [SerializeField] private Vector2 _yLimitation;
        [SerializeField] private Thing[] _thingPrefabs;

        #endregion

        #region Private methods

        private void CreateThing()
        {
            Vector2 randomPosition = GetRandomPosition();
            int randomThingIndex = Random.Range(0, _thingPrefabs.Length);
            Instantiate(_thingPrefabs[randomThingIndex], randomPosition, quaternion.identity);
        }

        private Vector2 GetRandomPosition()
        {
            float x = Random.Range(_xLimitation.x, _xLimitation.y);
            float y = Random.Range(_yLimitation.x, _yLimitation.y);


            return new Vector2(x, y);
        }

        #endregion
    }
}