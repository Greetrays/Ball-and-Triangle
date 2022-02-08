using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;
    [SerializeField] private Camera _camera;

    private List<GameObject> PoolObj = new List<GameObject>();

    public void Restart()
    {
        foreach (var item in PoolObj)
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
            PoolObj.Add(spawnedObj);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = PoolObj.First(obj => obj.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector2 _disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0));

        foreach (var item in PoolObj)
        {
            if (item.transform.position.x <= _disablePoint.x)
            {
                item.SetActive(false);
            }
        }
    }
}
