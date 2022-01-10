using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private GameObject _template;

    private float _delay;
    private float _currentTime;

    private void OnEnable()
    {
        _delay = Random.Range(_minDelay, _maxDelay);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _delay)
        {
            Spawn();
            _currentTime = 0;
            _delay = Random.Range(_minDelay, _maxDelay);
        }
    }

    private void Spawn()
    {
        Instantiate(_template, transform);
    }
}
