using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private List<WaveDataSCB> _waves;
    public int CurrentWave;
    public List<Enemy> SpawnedEnemies;
    [SerializeField] private CameraFollow _cameraFollow;
    private bool _theySpawned;


    public bool SpawnEnemies()
    {
        if (_waves == null) return false;
        if (_waves[CurrentWave].Enemies.Count == 0) return false;

        StartCoroutine(delayedSpawn());
        return _theySpawned;
    }
    private IEnumerator delayedSpawn()
    {
        for (int i = 0; i < _waves[CurrentWave].Enemies.Count; i++)
        {
            yield return new WaitForSeconds(1f);
            Enemy spawnedEnemy = Instantiate(_waves[CurrentWave].Enemies[i], transform.position, Quaternion.identity);
            SpawnedEnemies.Add(spawnedEnemy);
            _cameraFollow.SetTarget(spawnedEnemy.transform);
        }
        _theySpawned = true;
    }
    public void NextWave()
    {
        CurrentWave++;
    }

    public void RemoveEmpties()
    {
        SpawnedEnemies.RemoveAll(item => item == null);
    }
}