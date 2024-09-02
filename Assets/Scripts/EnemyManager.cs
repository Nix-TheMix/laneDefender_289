using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float _startTime;
    [SerializeField] private float _timeBeforeSpawn;
    [SerializeField] private GameObject[] enemies;
    void Update()
    {
        if (_timeBeforeSpawn <= 0)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
            _timeBeforeSpawn = _startTime;
        }
        else
        {
            _timeBeforeSpawn -= Time.deltaTime;
        }
    }
}
