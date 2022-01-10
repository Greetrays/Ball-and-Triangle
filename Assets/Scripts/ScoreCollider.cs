using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCollider : MonoBehaviour
{
    public event UnityAction<int> Counted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            Counted?.Invoke(enemy.Reward);
        }
    }
}
