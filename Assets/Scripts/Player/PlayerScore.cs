using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
    private int _score;

    public event UnityAction<int> Counted;

    private void Start()
    {
        Counted?.Invoke(_score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreTrigger scoreTrigger))
        {
            _score += scoreTrigger.Reward;
            Counted?.Invoke(_score);
        }
    }
}
