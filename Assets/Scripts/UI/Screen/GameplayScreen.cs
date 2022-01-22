using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class GameplayScreen : Screen
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Button _pauseButton;

    private AudioSource _audioSource;

    public event UnityAction Paused
    {
        add => _pauseButton.onClick.AddListener(value);
        remove => _pauseButton.onClick.RemoveListener(value);
    }

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(Pause);
        _menuScreen.Started += Open;
        _pauseScreen.ClickContinueButton += Open;
        _gameOverScreen.ClickRestartButton += Open;
        _player.Died += Close;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Close();
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(Pause);
        _menuScreen.Started -= Open;
        _pauseScreen.ClickContinueButton -= Open;
        _gameOverScreen.ClickRestartButton -= Open;
        _player.Died -= Close;
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

    private void Pause()
    {
        base.Close();
        _audioSource.Pause();
    }
}
