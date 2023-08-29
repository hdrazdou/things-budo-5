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

            gameService.ChangeHp(_hp);
        }

        #endregion
    }
}