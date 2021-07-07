using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _template;
    [SerializeField] private int _amount;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();


    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;
        for (int i = 0; i < _amount; i++)
        {
            var entity = Instantiate(prefab, _template);
            entity.SetActive(false);
            _pool.Add(entity);
        }
    }
    protected bool TryGetEntity(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    protected void DisableObjectAboardScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5F));

        foreach (var item in _pool)
        {
            if(item.activeSelf==true)
                if (item.transform.position.x < disablePoint.x)
                    item.SetActive(false);
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
