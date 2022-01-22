using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerHealth))]

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _hit;
    [SerializeField] private UnityEvent _usedHeart;
    
    private PlayerHealth _playerHealth;
    
    public event UnityAction<int> ChangedHealth;
    public event UnityAction<int> ChangedScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            ChangedHealth?.Invoke(enemy.Damage * -1);
            _hit?.Invoke();
        }

        if (collision.TryGetComponent(out Heart heart))
        {
            if (_playerHealth.CurrentHealth < _playerHealth.MaxHealth)
            {
                ChangedHealth?.Invoke(heart.Count);
            }
            
            _usedHeart?.Invoke();
        }

        if (collision.TryGetComponent(out ScoreTrigger scoreTrigger))
        {
            ChangedScore?.Invoke(scoreTrigger.Reward);
        }
    }

    public void Reset()
    {
        

    }
}
