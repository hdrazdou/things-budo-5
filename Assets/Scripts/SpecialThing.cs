using UnityEngine;

namespace Things
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

            _gameService.ChangeHp(_hp);
        }

        #endregion
    }
}