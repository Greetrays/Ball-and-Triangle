using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InfoScreen : Screen
{
    [SerializeField] private Button _backToMenu;
    [SerializeField] private MenuScreen _menuScreen;

    public event UnityAction PressedBackToMenu
    {
        add => _backToMenu.onClick.AddListener(value);
        remove => _backToMenu.onClick.RemoveListener(value);
    }

    private void OnEnable()
    {
        _menuScreen.PressedInfo += Open;
        _backToMenu.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _menuScreen.PressedInfo -= Open;
        _backToMenu.onClick.RemoveListener(Close);
    }
}
