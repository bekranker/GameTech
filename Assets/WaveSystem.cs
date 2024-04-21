using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private List<WaveDataSCB> _waves;
    [SerializeField] private List<Spawner> _spawners;
    public int CurrentWave;
    public List<Enemy> SpawnedEnemies;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject WinScreen;
    public bool TheySpawned;


    public void SpawnEnemies()
    {
        if (_waves == null) return;
        if (_waves[CurrentWave].Enemies.Count == 0) return;

        StartCoroutine(delayedSpawn());
    }
    private IEnumerator delayedSpawn()
    {
        for (int i = 0; i < _waves[CurrentWave].Enemies.Count; i++)
        {
            Enemy spawnedEnemy = Instantiate(_waves[CurrentWave].Enemies[i], TakeSpawner(), Quaternion.identity);
            SpawnedEnemies.Add(spawnedEnemy);
            yield return new WaitForSeconds(1f);
        }
        TheySpawned = true;
        _cameraFollow.SetTarget(_player.transform);
    }
    private Vector3 TakeSpawner()
    {
        for (int i = 0; i < _spawners.Count; i++)
        {
            if (_spawners[i].Spawned == false)
            {
                _spawners[i].Spawned = true;
                return _spawners[i].transform.position;
            }
        }
        return Vector3.zero;
    }
    public void NextWave()
    {
        if(CurrentWave + 1 == _waves.Count) 
        {
            WinScreen.SetActive(true);
            return;
        }
        CurrentWave++;
        SpawnedEnemies.ForEach((enemy)=> {enemy._arrived = false;});
        for (int i = 0; i < _spawners.Count; i++)
        {
            _spawners[i].Spawned = false;
        }
    }

    public void RemoveEmpties()
    {
        SpawnedEnemies.RemoveAll(item => item == null);
    }
}