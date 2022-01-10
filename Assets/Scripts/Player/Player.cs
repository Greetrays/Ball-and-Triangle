using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _hit;
    [SerializeField] private UnityEvent _usedHeart;

    private int _currentHealth;

    public event UnityAction Died;
    public event UnityAction ChangedHealth;

    public int CurrentHealth => _currentHealth;

    private void OnValidate()
    {
        if (_maxHealth == 0)
        {
            _maxHealth = 3;
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        ChangedHealth?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            ChangeHealth(enemy.Damage * -1);

            if (_currentHealth <= 0)
            {
                Die();
                return;
            }

            _hit?.Invoke();
        }

        if (collision.TryGetComponent(out Heart heart))
        {
            if (_currentHealth < _maxHealth)
            {
                ChangeHealth(heart.Count);
            }

            _usedHeart?.Invoke();
        }

        if (collision.TryGetComponent(out Money money))
        {

        }
    }

    private void ChangeHealth(int health)
    {
        _currentHealth += health;
        ChangedHealth?.Invoke();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
