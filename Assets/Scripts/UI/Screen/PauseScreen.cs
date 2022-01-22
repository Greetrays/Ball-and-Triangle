using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseScreen : Screen
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private GameplayScreen _gamePlayScreen;

    public event UnityAction ClickRestartButton
    {
        add => _restartButton.onClick.AddListener(value);
        remove => _restartButton.onClick.RemoveListener(value);
    }

    public event UnityAction ClickContinueButton
    {
        add => _continueButton.onClick.AddListener(value);
        remove => _continueButton.onClick.RemoveListener(value);
    }

    public event UnityAction ClickBackToMenuButton
    {
        add => _backToMenuButton.onClick.AddListener(value);
        remove => _backToMenuButton.onClick.RemoveListener(value);
    }

    private void OnEnable()
    { 
        _restartButton.onClick.AddListener(Close);
        _continueButton.onClick.AddListener(Close);
        _backToMenuButton.onClick.AddListener(Close);
        _gamePlayScreen.Paused += Open;
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Close);
        _continueButton.onClick.RemoveListener(Close);
        _backToMenuButton.onClick.RemoveListener(Close);
        _gamePlayScreen.Paused -= Open;
    }

    private void Start()
    {
        Close();
    }
}
