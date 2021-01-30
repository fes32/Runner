using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _firstSpawnPoint;

    private float _timeAfterLastSpawn = 0;

    private void Start()
    {
        Initialize(_template);
            SpawnGroundOnPosition(_firstSpawnPoint);
    }

    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >=_delay)
            SpawnGround();
    }

    private void SpawnGround()
    {
        if (TryGetObject(out GameObject ground))
        {
            _timeAfterLastSpawn = 0;
            ground.SetActive(true);
            ground.transform.position= _spawnPoint.position;
            DisableObjectAboardScreen();
        }
    }

    private void SpawnGroundOnPosition(Transform spawnPoint)
    {
        if (TryGetObject(out GameObject ground))
        {
            ground.SetActive(true);
            ground.transform.position = spawnPoint.position;
            DisableObjectAboardScreen();
        }
    }
}