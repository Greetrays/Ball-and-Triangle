using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameplayScreen _gameplayScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _gameplayScreen.Paused += Stop;
        _playerHealth.Died += Stop;
        _menuScreen.Started += Restart;
        _pauseScreen.ClickContinueButton += Play;
        _pauseScreen.ClickRestartButton += Restart;
        _gameOverScreen.ClickRestartButton += Restart;
    }

    private void OnDisable()
    {
        _gameplayScreen.Paused -= Stop;
        _playerHealth.Died -= Stop;
        _menuScreen.Started -= Restart;
        _pauseScreen.ClickContinueButton -= Play;
        _pauseScreen.ClickRestartButton -= Restart;
        _gameOverScreen.ClickRestartButton -= Restart;
    }

    private void Start()
    {
        Restart();
        Stop();
    }

    private void Restart()
    {
        _player.Restart();
        _spawner.Restart();
        Play();
    }

    private void Play()
    {
        Time.timeScale = 1;
    }

    private void Stop()
    {
        Time.timeScale = 0;
    }
}
