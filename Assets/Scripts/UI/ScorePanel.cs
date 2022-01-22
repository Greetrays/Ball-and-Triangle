using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _playerScore.Counted += OnCounted;
    }

    private void OnDisable()
    {
        _playerScore.Counted -= OnCounted;
    }

    private void OnCounted(int score)
    {
        _scoreText.text = score.ToString();
    }
}
