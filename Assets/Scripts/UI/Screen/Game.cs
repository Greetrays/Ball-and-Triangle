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
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _pauseScreen.ClickContinueButton += Stop;
    }

    private void Restart()
    {

    }

    private void Stop()
    {
        Time.timeScale = 0;
    }
}
