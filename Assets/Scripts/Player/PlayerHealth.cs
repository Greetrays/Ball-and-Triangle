using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    
    private int _currentHealth;
    private Player _player;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public event UnityAction Died;
    public event UnityAction ChangingHealth;

    private void OnValidate()
    {
        if (_maxHealth == 0)
        {
            _maxHealth = 3;
        }
    }

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _player.ChangedHealth += ChangeHealth;
        _player.Restarted += Restart;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= ChangeHealth;
        _player.Restarted -= Restart;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Restart()
    {
        _currentHealth = _maxHealth;
        ChangingHealth?.Invoke();
    }

    private void ChangeHealth(int health)
    {
        _currentHealth += health;
        ChangingHealth?.Invoke();

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {       
        Died?.Invoke();
    }
}
