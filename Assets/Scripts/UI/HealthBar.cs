using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] TMP_Text _healthText;

    private void Start()
    {
        _healthText.text = _player.CurrentHealth.ToString();
    }

    private void OnEnable()
    {
        _player.ChangingHealth += OnChangedHealth;
    }

    private void OnDisable()
    {
        _player.ChangingHealth -= OnChangedHealth;
    }

    private void OnChangedHealth()
    {
        _healthText.text = _player.CurrentHealth.ToString();
    }
}
