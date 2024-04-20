using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WaveData", fileName = "CreateWaveData", order = 1)]
public class WaveDataSCB : ScriptableObject
{
    public int WaveNumber;
    public List<Enemy> Enemies;
}