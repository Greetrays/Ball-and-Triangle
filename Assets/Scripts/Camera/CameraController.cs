using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CameraController : MonoBehaviour
{
    [SerializeField] private MenuScreen _menuScreen;
    //[SerializeField] private GameOverScreen _gameOverScreen;
    //[SerializeField] private PauseScreen _pauseScreen;
   // [SerializeField] private PlayerHealth _player;
    //[SerializeField] private GameplayScreen _gameplayScreen;

    private Animator _animator;

    private void OnEnable()
    {
        _menuScreen.Started += OnClickStartButton;
        //_pauseScreen.ClickRestartButton += OnClickStartButton;
       // _gameOverScreen.ClickRestartButton += OnClickStartButton;
       // _pauseScreen.ClickContinueButton += OnClickStartButton;
       // _gameplayScreen.Paused += OnClickPauseButton;
       // _player.Died += OnClickPauseButton;
    }

    private void OnDisable()
    {
        _menuScreen.Started -= OnClickStartButton;
        //_pauseScreen.ClickRestartButton -= OnClickStartButton;
       // _gameOverScreen.ClickRestartButton -= OnClickStartButton;
       // _pauseScreen.ClickContinueButton -= OnClickStartButton;
       // _gameplayScreen.Paused -= OnClickPauseButton;
      //  _player.Died -= OnClickPauseButton;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnClickStartButton()
    {
        _animator.Play(CameraAnimatorController.State.ZoomOut);
    }

    private void OnClickPauseButton()
    {
        _animator.Play(CameraAnimatorController.State.Zoom);
    }
}
