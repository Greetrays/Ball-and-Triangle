using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class GameOverScreen : Screen
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private GameplayScreen _gamePlayScreen;
    [SerializeField] private Player _player;

    private AudioSource _audioSource;

    public event UnityAction ClickRestartButton
    {
        add => _restartButton.onClick.AddListener(value);
        remove => _restartButton.onClick.RemoveListener(value);
    }

    public event UnityAction ClickBackToMenuButton
    {
        add => _backToMenuButton.onClick.AddListener(value);
        remove => _backToMenuButton.onClick.RemoveListener(value);
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(Close);
        _backToMenuButton.onClick.AddListener(Close);
        _player.Died += Open;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Close();
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Close);
        _backToMenuButton.onClick.RemoveListener(Close);
        _player.Died -= Open;
    }

    protected override void Open()
    {
        base.Open();
        _audioSource.Play();
    }

    protected override void Close()
    {
        base.Close();
        _audioSource.Stop();
    }
}
