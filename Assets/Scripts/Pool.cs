using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;
    [SerializeField] private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
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

    protected void DisableObjectAbroadScreen()
    {
        Vector2 _disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0));

        foreach (var item in _pool)
        {
            if (item.transform.position.x <= _disablePoint.x)
            {
                item.SetActive(false);
            }
        }
    }
}
