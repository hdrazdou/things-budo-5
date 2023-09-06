using System;
using System.Collections;
using Things.Game.Things;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Things.Game.Services
{
    public class SpawnService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _spawnPadding;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private SpawnData[] _things;

        private float _heightLimit;
        private float _widthLimit;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            CalculateSpawnLimits();
            StartCoroutine(CreateThing());
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

        private void CalculateSpawnLimits()
        {
            float cameraSize = Camera.main.orthographicSize;
            float cameraHalfWidth = Camera.main.aspect * cameraSize;

            _widthLimit = cameraHalfWidth - _spawnPadding;
            _heightLimit = cameraSize - _spawnPadding;
        }

        private IEnumerator CreateThing()
        {
            GameService gameService = FindObjectOfType<GameService>();

            yield return new WaitForSeconds(_spawnDelay);

            while (!gameService.IsGameOver)
            {
                Vector2 randomPosition = GetRandomPosition();
                Thing randomThing = GetRandomThingByWeight();
                Instantiate(randomThing, randomPosition, Quaternion.identity);

                yield return new WaitForSeconds(_spawnDelay);
            }
        }

        private Vector2 GetRandomPosition()
        {
            float x = Random.Range(-_widthLimit, _widthLimit);
            float y = Random.Range(0, _heightLimit);

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