using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool;

    private void Start()
    {
        _pool = new List<GameObject>();
    }

    protected void Initialize(GameObject tamplate) 
    {
        for (int i = 0; i < _capacity; i++)
        {
            var spawnedObj = Instantiate(tamplate, _container);
            spawnedObj.SetActive(false);
            _pool.Add(spawnedObj);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.First(obj => obj.activeSelf == false);

        return result != null;
    }
}
