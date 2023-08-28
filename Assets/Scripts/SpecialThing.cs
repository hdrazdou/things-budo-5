using UnityEngine;

namespace Things
{
    public class SpecialThing : Thing
    {
        [SerializeField] private int _hp;
        protected override void PerformActions()
        {
            base.PerformActions();

            _gameService.ChangeHp(_hp);
        }
    }
}