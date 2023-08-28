using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Things
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private TMP_Text _hpLabel;
        [SerializeField] private Transform _HpCounter;
        [SerializeField] private GameObject _hpPrefab;
        private readonly List<GameObject> _hpHearts = new();

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            GameService.OnScoreChanged += UpdateScore;
            GameService.OnHpChanged += UpdateHp;

            UpdateScore(GameService.TotalScore);
            UpdateHp(GameService.Hp);
        }

        private void OnDestroy()
        {
            GameService.OnScoreChanged -= UpdateScore;
            GameService.OnHpChanged -= UpdateHp;
        }

        #endregion

        #region Private methods

        private void CreateHearts()
        {
            for (int i = 0; i < GameService.Hp; i++)
            {
                _hpHearts.Add(Instantiate(_hpPrefab, _HpCounter));
            }
        }

        private void UpdateHp(int hp)
        {
            _hpLabel.text = $"HP: {hp}";
            CreateHearts();
        }

        private void UpdateScore(int score)
        {
            _scoreLabel.text = $"Score: {score}";
        }

        #endregion
    }
}