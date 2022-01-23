using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class MenuScreen : Screen
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _infoButton;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private AudioSource _audioSource;

    public event UnityAction Started
    {
        add => _startButton.onClick.AddListener(value);
        remove => _startButton.onClick.RemoveListener(value);
    }

    public event UnityAction PressedInfo
    {
        add => _infoButton.onClick.AddListener(value);
        remove => _infoButton.onClick.RemoveListener(value);
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(Close);
        _exitButton.onClick.AddListener(ExitGame);
        _pauseScreen.ClickBackToMenuButton += Open;
        _gameOverScreen.ClickBackToMenuButton += Open;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(Close);
        _exitButton.onClick.RemoveListener(ExitGame);
        _pauseScreen.ClickBackToMenuButton -= Open;
        _gameOverScreen.ClickBackToMenuButton -= Open;
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

    private void ExitGame()
    {
        Application.Quit();
    }
}
