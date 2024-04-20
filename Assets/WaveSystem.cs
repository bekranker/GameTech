using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private List<WaveDataSCB> _waves;
    public int CurrentWave;



    public void SpawnEnemies()
    {
        if (_waves == null) return;
        if (_waves[CurrentWave].Enemies.Count == 0) return;

        for (int i = 0; i < _waves[CurrentWave].Enemies.Count; i++)
        {
            Instantiate(_waves[CurrentWave].Enemies[i], transform.position, Quaternion.identity);
        }
    }
    public void NextWave()
    {
        
    }
}