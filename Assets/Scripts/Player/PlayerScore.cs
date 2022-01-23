using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]

public class PlayerScore : MonoBehaviour
{
    private int _score;
    private Player _player;

    public event UnityAction<int> Counted;

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _player.ChangedScore += AddScore;
        _player.Restarted += Restart;
    }

    private void OnDisable()
    {
        _player.ChangedScore -= AddScore;
        _player.Restarted -= Restart;
    }

    private void Restart()
    {
        _score = 0;
        Counted?.Invoke(_score);
    }

    private void AddScore(int score)
    {
        _score += score;
        Counted?.Invoke(_score);
    }
}
