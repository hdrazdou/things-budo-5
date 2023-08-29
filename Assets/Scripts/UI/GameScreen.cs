using System.Collections.Generic;
using Things.Game.Services;
using TMPro;
using UnityEngine;

namespace Things
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;
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

        private void CreateHearts(int hp)
        {
            for (int i = 0; i < hp; i++)
            {
                _hpHearts.Add(Instantiate(_hpPrefab, _HpCounter));
            }
        }

        private void UpdateHp(int hp)
        {
            if (hp > _hpHearts.Count)
            {
                CreateHearts(hp);
            }

            for (int i = 0; i < _hpHearts.Count; i++)
            {
                if (i < hp)
                {
                    _hpHearts[i].gameObject.SetActive(true);
                }
                else
                {
                    _hpHearts[i].SetActive(false);
                }
            }
        }

        private void UpdateScore(int score)
        {
            _scoreLabel.text = $"Score: {score}";
        }

        #endregion
    }
}