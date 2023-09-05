using System.Collections.Generic;
using Things.Game.Things;
using UnityEngine;

namespace Things.Game.Services
{
    public class LevelService : MonoBehaviour
    {
        #region Variables

        private readonly List<Thing> _things = new();

        #endregion

        #region Properties

        public List<Thing> Things => _things;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            Thing.OnCreated += AddThing;
        }

        private void OnDestroy()
        {
            Thing.OnDestroyed -= RemoveThing;
        }

        #endregion

        #region Private methods

        private void AddThing(Thing thing)
        {
            _things.Add(thing);
        }

        private void RemoveThing(Thing thing)
        {
            _things.Remove(thing);
        }

        #endregion
    }
}