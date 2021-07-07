using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private int _timeBetweenSpawn = 3;

    private float _elapsedTime = 2;

    private void Start()
    {
        Initialize(_prefab);
    }
    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime > _timeBetweenSpawn)
        {
            if(TryGetEntity(out GameObject pipe))
            {
                _elapsedTime = 0;
                pipe.SetActive(true);
                float _spawnPositionY = Random.Range(_minHeight, _maxHeight);
                Vector3 spawnPoint = new Vector3(transform.position.x, _spawnPositionY, transform.position.z);
                pipe.transform.position = spawnPoint;

                DisableObjectAboardScreen();
            }
        }
    }
}
