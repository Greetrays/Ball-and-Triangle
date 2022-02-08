using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Pool
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private GameObject _template;

    private float _delay;
    private float _currentTime;

    private void Start()
    {
        _delay = Random.Range(_minDelay, _maxDelay);
        Initialize(_template);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        
        if (_currentTime >= _delay)
        {
            if (TryGetObject(out GameObject obj))
            {
                Spawn(obj);
                _currentTime = 0;
                _delay = Random.Range(_minDelay, _maxDelay);
            }
        }    
    }

    private void Spawn(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.position = transform.position;
        DisableObjectAbroadScreen();
    }
}
