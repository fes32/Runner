using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private Transform _spawnPoint;

    private float _timeAfterLastSpawn = 0;
    private float _currentRandomDelay = 0;

    private void Start()
    {
        Initialize(_template);
        _currentRandomDelay = Random.Range(_minDelay, _maxDelay);
    }

    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn > _currentRandomDelay)
            SpawnSpike();
    }

    private void SpawnSpike()
    {
        if(TryGetObject(out GameObject spike))
        {
             _timeAfterLastSpawn = 0;
            _currentRandomDelay = Random.Range(_minDelay, _maxDelay);
            spike.SetActive(true);
            spike.transform.position = _spawnPoint.position;
            DisableObjectAboardScreen();
        }
    }
}