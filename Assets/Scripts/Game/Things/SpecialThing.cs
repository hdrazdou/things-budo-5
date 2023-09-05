using Things.Game.Services;
using UnityEngine;

namespace Things.Game.Things
{
    public class SpecialThing : Thing
    {
        #region Variables

        [SerializeField] private int _hp;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService gameService = FindObjectOfType<GameService>();
            gameService.ChangeHp(_hp);
        }

        #endregion
    }
}