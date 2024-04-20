using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WaveSystem _waveSystem;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private Player _player;

    void Start()
    {
        _waveSystem.SpawnEnemies();
    }

    public void NextTurn()
    {
        StartCoroutine(nextTurnIE());
    }
    private IEnumerator nextTurnIE()
    {
        //_waveSystem.RemoveEmpties();
        //kamera dusmanlarda
        //dusmanlar sirayla yurur ya da dusman yakinimizda ise bize saldirir
        for (int i = 0; i < _waveSystem.SpawnedEnemies.Count;)
        {
            print("waiting");
            _waveSystem.SpawnedEnemies[i].EnemyAction();
            yield return new WaitUntil(() => _waveSystem.SpawnedEnemies[i]._arrived == true);
            i++;
            print("Finish");
        }
        //kamera bize geri gelir
        _cameraFollow.SetTarget(_player.transform);
        //kamera bizde biraz bekler
        yield return new WaitForSeconds(1f);
        //dusmanlar sirayla spawn olmaya baslar
        //kamera yeni spawn olan dusmanlara gider
        _waveSystem.NextWave();
        yield return new WaitWhile(() => _waveSystem.SpawnEnemies() == true);
        //spawn bittikten sonra kamera bize geri gelir
        _cameraFollow.SetTarget(_player.transform);
        yield return new WaitForSeconds(1f);
        //kamera bizde biraz bekler ve eger kaybetmediysek yukari da ki bar saga ilerler 
        //next Turn Effecti gelir.
    }
}
