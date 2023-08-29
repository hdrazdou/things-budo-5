using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Things
{
    public class SpawnService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Vector2 _xLimitation;
        [SerializeField] private Vector2 _yLimitation;

        [SerializeField] private SpawnData[] _things;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            InvokeRepeating("CreateThing", 1.0f, 1.0f);
        }

        private void OnValidate()
        {
            if (_things == null)
            {
                return;
            }

            foreach (SpawnData spawndata in _things)
            {
                spawndata.OnValidate();
            }
        }

        #endregion

        #region Private methods

        private void CreateThing()
        {
            Vector2 randomPosition = GetRandomPosition();
            Thing randomThing = GetRandomThingByWeight();

            Instantiate(randomThing, randomPosition, Quaternion.identity);
        }

        private Vector2 GetRandomPosition()
        {
            float x = Random.Range(_xLimitation.x, _xLimitation.y);
            float y = Random.Range(_yLimitation.x, _yLimitation.y);

            return new Vector2(x, y);
        }

        private Thing GetRandomThingByWeight()
        {
            int totalWeight = 0;

            foreach (SpawnData spawnData in _things)
            {
                totalWeight += spawnData.SpawnWeight;
            }

            int randomWeight = Random.Range(0, totalWeight + 1);

            int currentWeight = 0;

            for (int i = 0; i < _things.Length; i++)
            {
                currentWeight += _things[i].SpawnWeight;

                if (currentWeight >= randomWeight)
                {
                    return _things[i].ThingPrefab;
                }
            }

            return null;
        }

        #endregion

        #region Local data

        [Serializable]
        private class SpawnData
        {
            #region Variables

            [HideInInspector]
            public string Name;
            public int SpawnWeight;
            public Thing ThingPrefab;

            #endregion

            #region Public methods

            public void OnValidate()
            {
                Name = $"{ThingPrefab} : {SpawnWeight}";
            }

            #endregion
        }

        #endregion
    }
}