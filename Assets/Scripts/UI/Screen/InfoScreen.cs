using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreen : Screen
{
    [SerializeField] private Button _backToMenu;
    [SerializeField] private MenuScreen _menuScreen;

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
