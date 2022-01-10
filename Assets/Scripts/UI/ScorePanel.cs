using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private ScoreCollider _scoreCollider;
    [SerializeField] private TMP_Text _scoreText;

    private int _currentScore;

    private void OnEnable()
    {
        _scoreCollider.Counted += OnCounted;
        _scoreText.text = _currentScore.ToString();
    }

    private void OnDisable()
    {
        _scoreCollider.Counted -= OnCounted;
    }

    private void OnCounted(int score)
    {
        _currentScore += score;
        _scoreText.text = _currentScore.ToString();
    }
}
